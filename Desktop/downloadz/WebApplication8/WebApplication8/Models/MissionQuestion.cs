using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    [Table("MissionQuestion")]
    public class MissionQuestion
    {
            [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int missionQuestionID { get; set; }
            public int missionID { get; set; }
            public int userID { get; set; }
            public string question { get; set; }
            public string answer { get; set; }
    }
}
