using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPILab.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public Nullable<int> IdIssue { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ComentTimestamp { get; set; }
        public virtual Issue Issue { get; set; }
    }
}