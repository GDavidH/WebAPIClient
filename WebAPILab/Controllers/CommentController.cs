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

        //List comment
        public IHttpActionResult GetAll()
        {
            //Lista de tipo iterador
            IList<CommentModel> comments = null;

            using (var context = new Entity())
            {
                comments = context.Comment
                    .Select(CommentItem => new CommentModel()
                    {
                        Id = CommentItem.Id,
                        IdIssue = CommentItem.IdIssue,
                        Description = CommentItem.Description,
                        ComentTimestamp = CommentItem.ComentTimestamp,


                    }).ToList<CommentModel>();
            }
            if (comments.Count == 0)
            {

                return NotFound();
            }

            return Ok(comments);
        }

        //newComment 
        public IHttpActionResult Post(CommentModel newComment)
        {
            DateTime today = DateTime.Now;
            using (var context = new Entity())
            {
                context.Comment
                .Add(new Comment()
                {
                    IdIssue = newComment.IdIssue,
                    Description = newComment.Description,
                    ComentTimestamp = today//default

                });
                context.SaveChanges();

            }
            return Ok();
        }



        public IHttpActionResult GetById(int id)
        {
            //Lista de tipo iterador
            ClientModel client = null;

            using (var context = new Entity())
            {
                client = context.Client
                    .Where(ClientItem => ClientItem.Id == id)
                    .Select(ClientItem => new ClientModel()
                    {


                    }).FirstOrDefault<ClientModel>();
            }
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        //Update Client
        public IHttpActionResult Put(CommentModel comment)
        {
            using (var context = new Entity())
            {
                var existindComment = context.Comment
                .Where(cmm => cmm.Id == comment.Id).FirstOrDefault<Comment>();

                if (existindComment != null)
                {


                    context.SaveChanges();
                }

            }

            return Ok();
        }

        //Delete Client
        public IHttpActionResult Delete(int id)
        {
            using (var context = new Entity())
            {
                var comment = context.Comment
                    .Where(commentItem => commentItem.Id == id).FirstOrDefault();

                context.Entry(comment).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

            return Ok();
        }

    }
 }