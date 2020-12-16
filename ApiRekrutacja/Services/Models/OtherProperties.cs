using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Services.Models
{
    public class OtherProperties
    {
        public int Id { get; set; }
        public bool HasJob { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        
    }
}
