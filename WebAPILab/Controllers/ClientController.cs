using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class ClientController : ApiController
    {
        //Listar clientes
        public IHttpActionResult GetAll()
        {
            //Lista de tipo iterador
            IList<ClientModel> clients = null;

            using (var context = new Entities())
            {
                clients = context.Client
                    .Select(ClientItem => new ClientModel()
                    {
                        Id = ClientItem.Id,
                        Name = ClientItem.Name,
                        FirstSurname = ClientItem.FirstSurname,
                        SecondSurname = ClientItem.SecondSurname,
                        Address = ClientItem.Address,
                        Phone = ClientItem.Phone,
                        SecondContact = ClientItem.SecondContact,
                        Email = ClientItem.Email,
                        PhoneService = ClientItem.PhoneService,
                        TelevisionService = ClientItem.TelevisionService,
                        CellPhoneService = ClientItem.CellPhoneService,
                        InternetService = ClientItem.InternetService
                    }).ToList<ClientModel>();
            }
            if (clients.Count == 0)
            {

                return NotFound();
            }

            return Ok(clients);
        }

        //Registar nuevo cliente
        public IHttpActionResult Post(ClientModel newClient)
        {
            using (var context = new Entities())
            {
                context.Client
                .Add(new Client()
                {
                    Id = newClient.Id,
                    Name = newClient.Name,
                    FirstSurname = newClient.FirstSurname,
                    SecondSurname = newClient.SecondSurname,
                    Address = newClient.Address,
                    Phone = newClient.Phone,
                    SecondContact = newClient.SecondContact,
                    Email = newClient.Email,
                    Password = newClient.Password,
                    PhoneService = newClient.PhoneService,
                    TelevisionService = newClient.TelevisionService,
                    CellPhoneService = newClient.CellPhoneService,
                    InternetService = newClient.InternetService
                }) ;

                context.SaveChanges();
            }

            return Ok();
        }



        public IHttpActionResult GetById(int id)
        {
            //Lista de tipo iterador
            ClientModel client = null;

            using (var context = new Entities())
            {
                client = context.Client
                    .Where(ClientItem => ClientItem.Id == id)
                    .Select(ClientItem => new ClientModel()
                    {
                        Id = ClientItem.Id,
                        Name = ClientItem.Name,
                        FirstSurname = ClientItem.FirstSurname,
                        SecondSurname = ClientItem.SecondSurname,
                        Address = ClientItem.Address,
                        Phone = ClientItem.Phone,
                        SecondContact = ClientItem.SecondContact,
                        Email = ClientItem.Email,
                        PhoneService = ClientItem.PhoneService,
                        TelevisionService = ClientItem.TelevisionService,
                        CellPhoneService = ClientItem.CellPhoneService,
                        InternetService = ClientItem.InternetService,
                        Issue = ClientItem.Issue

                    }).FirstOrDefault<ClientModel>();
            }
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        //Update Client
        public IHttpActionResult Put(ClientModel client)
        {
            using (var context = new Entities())
            {
                var existindClient = context.Client
                .Where(cl => cl.Id == client.Id).FirstOrDefault<Client>();

                if (existindClient != null)
                {

                    existindClient.Name = client.Name;
                    existindClient.FirstSurname = client.FirstSurname;
                    existindClient.SecondSurname = client.SecondSurname;
                    existindClient.Address = client.Address;
                    existindClient.Phone = client.Phone;
                    existindClient.SecondContact = client.SecondContact;
                    existindClient.Email = client.Email;
                    existindClient.PhoneService = client.PhoneService;
                    existindClient.TelevisionService = client.TelevisionService;
                    existindClient.CellPhoneService = client.CellPhoneService;
                    existindClient.InternetService = client.InternetService;

                    context.SaveChanges();
                }

            }

            return Ok();
        }

        //Delete Client
        public IHttpActionResult Delete(int id)
        {
            using (var context = new Entities())
            {
                var client = context.Client
                    .Where(clientItem => clientItem.Id == id).FirstOrDefault();

                context.Entry(client).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return Ok();
        }
    }
}