using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class MailModel
    {
        [Required, EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}