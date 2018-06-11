using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Message.API.Models
{
    public class MessageForUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Message { get; set; }
    }
}
