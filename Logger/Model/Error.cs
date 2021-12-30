using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logger.Model
{
    [Table("Error")]
    public class Error
    {
        [Key]
        public int Id { get; set; }

        public string ErrorCategory { get; set; }

        public string ErrorText { get; set; }

        public string ErrorExtension { get; set; }

        public string DeviceAddress { get; set; }

        public DateTime DateTime { get; set; }

        public string ErrorKey { get; set; }
    }
}
