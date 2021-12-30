using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logger.Model
{
    [Table("JobState")]
    public class JobState
    {
        [Key]
        public int Id { get; set; }

		public string DeviceAddress { get; set; }

		public DateTime DateTime { get; set; }

		public string JobKey { get; set; }

		public string ArticleKey { get; set; }

		public string RejectReason { get; set; }

		public string Text { get; set; }
	}
}
