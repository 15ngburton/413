using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class MissionDetails
    {
        public List<User> User { get; set; }
        public List<MissionQuestion> MissionQuestion { get; set; }
        public Mission Mission { get; set; }
    }
}