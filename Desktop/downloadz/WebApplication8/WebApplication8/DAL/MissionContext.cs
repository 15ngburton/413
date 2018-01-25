using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication8.Models;

namespace WebApplication8.DAL
{
    public class MissionContext: DbContext
    {
        public MissionContext() : base("MissionContext")
        {

        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MissionQuestion> MissionQuestions { get; set; }
    }
}