using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    [Table("Mission")]
    public class Mission
    {       
            [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int missionID { get; set; }
            public string missionName { get; set; }
            public string missionPresidentName { get; set; }
            public string missionAddress { get; set; }
            public string missionLanguage { get; set; }
            public string missionClimate { get; set; }
            public string dominantReligion { get; set; }
            //This string should return an image
            public string missionSymbol { get; set; }
    }
}