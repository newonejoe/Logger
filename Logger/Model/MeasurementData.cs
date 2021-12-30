using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logger.Model
{
    [Table("MeasurmentData")]
    public class MeasurementData
    {
        [Key]
        public int Id { get; set; }

        public string Job { get; set; }

        public string DeviceAddress { get; set; }

        public DateTime DateTimeStamp { get; set; }

        public string MeasureType { get; set; }

        public string WireKey { get; set; }

        public string TerminalKey { get; set; }

        public bool Result { get; set; }

        public double Measurement { get; set; }
    }
}
