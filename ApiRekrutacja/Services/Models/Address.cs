using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Services.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressName { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
