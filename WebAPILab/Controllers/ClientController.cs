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

            using (var context = new Entity())
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
                        Email = ClientItem.Email

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
            using (var context = new Entity())
            {
                context.Client
                .Add(new Client()
                {
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

    }
}