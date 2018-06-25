using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Bioinformatics.Web.Models
{
    public class SequenceAlignerModel
    {
        [DisplayName("Sequence 1")]
        public string Sequence1 { get; set; }
        [DisplayName("Sequence 2")]
        public string Sequence2 { get; set; }
        [DisplayName("Sequence Aligned")]
        public string Sequence1Aligned { get; set; }
        public string Sequence2Aligned { get; set; }
    }
}
