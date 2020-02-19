using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class CommentController : ApiController
    {

        //Registrar nueva  solicitud
        public IHttpActionResult Post(CommentModel newComment)
        {
            using (var context = new Entity())
            {
                context.Comment
                .Add(new Comment()
                {
                    Description = newComment.Description,
                    ComentTimestamp = newComment.ComentTimestamp//default

                });
                context.SaveChanges();

            }
            return Ok();
        }

    }
 }