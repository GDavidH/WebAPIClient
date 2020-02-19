using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class IssueController : ApiController
    {

        //Listar solicitudes
        public IHttpActionResult GetAll()
        {
            IList<IssueModel> Issues = null;

            using (var context = new Entity())
            {
                Issues = context.Issue
                    .Select(IssueItem => new IssueModel()
                    {
                        ReportNumber = IssueItem.ReportNumber,
                        Service = IssueItem.Service,
                        RegisterTimestamp = IssueItem.RegisterTimestamp,
                        Status = IssueItem.Status
                    }).ToList<IssueModel>();
            }
            if (Issues.Count == 0)
            {

                return NotFound();
            }
            return Ok(Issues);
        }


        //Registrar nueva  solicitud
        public IHttpActionResult Post(IssueModel newIssue)
        {
            DateTime today = DateTime.Today;
            using (var context = new Entity())
            {
                context.Issue
                .Add(new Issue()
                {

                    Description = newIssue.Description,
                    ContactPhone = newIssue.ContactPhone,
                    ReportNumber = newIssue.ReportNumber,//default
                    ContactEmail = newIssue.ContactEmail,
                    Address = newIssue.Address,
                    RegisterTimestamp = BitConverter.GetBytes(today.Ticks),//default
                    Service = newIssue.Service,
                    Status = newIssue.Status,//default
                    //SupportUserAssigned = newIssue.SupportUserAssigned

                });
                context.SaveChanges();

            }

            return Ok();
        }

    }
}