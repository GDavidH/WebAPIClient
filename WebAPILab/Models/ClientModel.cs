using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPILab.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Nullable<int> SecondContact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> PhoneService { get; set; }
        public Nullable<bool> TelevisionService { get; set; }
        public Nullable<bool> CellPhoneService { get; set; }
        public Nullable<bool> InternetService { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
    }
}