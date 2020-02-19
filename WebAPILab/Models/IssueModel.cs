using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPILab.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Nullable<int> ReportNumber { get; set; }
        public byte[] RegisterTimestamp { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Status { get; set; }
        public Nullable<int> SupportUserAssigned { get; set; }
        public Nullable<int> IdClient { get; set; }
        public string Service { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }

    }
}