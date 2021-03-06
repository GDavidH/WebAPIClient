﻿using System;
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
                        Id = IssueItem.Id,
                        Description = IssueItem.Description,
                        RegisterTimestamp = IssueItem.RegisterTimestamp,
                        Address = IssueItem.Address,
                        ContactPhone = IssueItem.ContactPhone,
                        ContactEmail = IssueItem.ContactEmail,
                        Status = IssueItem.Status,
                        SupportUserAssigned = IssueItem.SupportUserAssigned,
                        IdClient = IssueItem.IdClient,
                        Service = IssueItem.Service
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
            DateTime today = DateTime.Now;
            using (var context = new Entity())
            {
                context.Issue
                .Add(new Issue()
                {

                    Description = newIssue.Description,                   
                    RegisterTimestamp = today,
                    Address = newIssue.Address,
                    ContactPhone = newIssue.ContactPhone,
                    ContactEmail = newIssue.ContactEmail,
                    Status = newIssue.Status,
                    SupportUserAssigned = newIssue.SupportUserAssigned,
                    IdClient = newIssue.IdClient,
                    Service = newIssue.Service

                });
                context.SaveChanges();

            }

            return Ok();
        }


        public IHttpActionResult GetById(int id)
        {
            //Lista de tipo iterador
            IssueModel issue = null;

            using (var context = new Entity())
            {
                issue = context.Issue
                    .Where(IssueItem => IssueItem.Id == id)
                    .Select(IssueItem => new IssueModel()
                    {
                        Id = IssueItem.Id,
                        Description = IssueItem.Description,
                        RegisterTimestamp = IssueItem.RegisterTimestamp,
                        Address = IssueItem.Address,
                        ContactPhone = IssueItem.ContactPhone,
                        ContactEmail = IssueItem.ContactEmail,
                        Status = IssueItem.Status,
                        SupportUserAssigned = IssueItem.SupportUserAssigned,
                        IdClient = IssueItem.IdClient,
                        Service = IssueItem.Service

                    }).FirstOrDefault<IssueModel>();
            }
            if (issue == null)
            {
                return NotFound();
            }

            return Ok(issue);
        }

        //Update Issue
        public IHttpActionResult Put(IssueModel issue)
        {

            using (var context = new Entity())
            {
                var existindIssue = context.Issue
                .Where(iss => iss.Id == issue.Id).FirstOrDefault<Issue>();

                if (existindIssue != null)
                {
                    existindIssue.Description = issue.Description;
                    existindIssue.Address = issue.Address;
                    existindIssue.ContactPhone = issue.ContactPhone;
                    existindIssue.ContactEmail = issue.ContactEmail;
                    existindIssue.Status = issue.Status;
                    existindIssue.SupportUserAssigned = issue.SupportUserAssigned;
                    existindIssue.IdClient = issue.IdClient;
                    existindIssue.Service = issue.Service;

                    context.SaveChanges();
                }

            }

            return Ok();
        }

        //Delete Issue
        public IHttpActionResult Delete(int id)
        {
            using (var context = new Entity())
            {
                var issue = context.Issue
                    .Where(issueItem => issueItem.Id == id).FirstOrDefault();

                context.Entry(issue).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return Ok();
        }

    }
}