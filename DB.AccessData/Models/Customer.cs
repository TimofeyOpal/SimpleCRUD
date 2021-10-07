using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.AccessData.Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email{get;set;}
        public DateTime BirthDate { get; set; }

    }
}
