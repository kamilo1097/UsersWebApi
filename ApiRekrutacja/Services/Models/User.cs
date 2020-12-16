using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name {get; set; }

        public string Surname { get; set; }

    }
}
