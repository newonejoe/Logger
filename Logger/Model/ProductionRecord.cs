using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Model
{
    [Table("ProductionRecord")]
    public class ProductionRecord
    {
        [Key]
        public Guid Id { get; set; }

        public string JobKey { get; set; }

        public string ArticleKey { get; set; }

        public DateTime DateTimeInWork { get; set; }

        public DateTime DateTimeEnd { get; set; }

        public string State { get; set; }

        public string TerminalSide1 { get; set; }

        public string TerminalSide2 { get; set; }

        public string SealSide1 { get; set; }

        public string SealSide2 { get; set; }

        public string CrimpToolSide1 { get; set; }

        public string CrimpToolSide2 { get; set; }

        public string WireKey { get; set; }

        // public string WireLength { get; set; }

        public int TotalGood { get; set; }

        public int NoGoodTerminalSide1 { get; set; }

        public int NoGoodTerminalSide2 { get; set; }

        public int NoGoodSealSide1 { get; set; }

        public int NoGoodSealSide2 { get; set; }

        public int NoGoodWireLength { get; set; }
    }
}
