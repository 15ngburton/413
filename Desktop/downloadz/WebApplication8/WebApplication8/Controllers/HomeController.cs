using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication8.Models;
using System.Net;
using System.Data.Entity;
using WebApplication8.DAL;

namespace WebApplication8.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //Define Lists for all model objects
        private MissionContext db = new MissionContext();
        static int currentMission = 0;
        static int currentUser = 1;

        //Home page
        public ActionResult Index()
        {  
            return View();
        }

        //About page
        public ActionResult About()
        {
            return View();
        }

        //Contact page
        public ActionResult Contact()
        {
            List<String> menuItems = new List<String>();
            return View();
        }

        //Mission page
        public ActionResult Mission()
        {
            IEnumerable<Mission> missionModels = db.Database.SqlQuery<Mission>("SELECT * FROM Mission");
            return View(missionModels);
        }

        //Mission Details Page
        [Authorize]
        [HttpGet]
        public ActionResult MissionDetails(int menu)
        {
            //Define lists for loading
            List<MissionQuestion> questionList = new List<MissionQuestion>();
            List<User> userList = new List<User>();
            //Define other variables
            currentMission = menu;
            Mission mission = db.Missions.Find(menu);
            //Get all of the associated mission questions
            IEnumerable<MissionQuestion> missionQuestions = db.Database.SqlQuery<MissionQuestion>("SELECT * FROM MissionQuestion WHERE missionID = " + mission.missionID);
            //Get all of th users
            IEnumerable<User> users = db.Database.SqlQuery<User>("SELECT * FROM [User]");
            //Load the questionList wiht the missionQuestions IEnumerable
            foreach (MissionQuestion item in missionQuestions)
            {
                questionList.Add(item);
            }
            //Load the appropriate users into the userList (those associated with a mission question we loaded previously)
            foreach(User item in users)
            {
                for (int i = 0; i < questionList.Count; i++)
                {
                    if (questionList[i].userID == item.userID)
                    {
                        userList.Add(item);
                    }
                }
            }
            //Put together the mission details model
            MissionDetails missionDetails = new MissionDetails();
            missionDetails.Mission = mission;
            missionDetails.MissionQuestion = questionList;
            missionDetails.User = userList;
            return View(missionDetails);
        }

        [HttpPost]
        public ActionResult MissionDetails(string submit)
        {
            //What happens when the user tries to post a question.
            if (submit == "Post")
            {
                //Saves the question model information
                string qText = Request["questionText"];
                MissionQuestion missionQuestion = new MissionQuestion();
                missionQuestion.missionID = currentMission;
                missionQuestion.userID = currentUser;
                missionQuestion.question = qText;
                missionQuestion.answer = "";
                db.MissionQuestions.Add(missionQuestion);
                db.SaveChanges();
                return RedirectToAction("MissionDetails", new { menu = currentMission });
            }
            //What happens when a user tries to make a reply
            else
            {
                //changes the answer attribute of a selected question model
                int id = Convert.ToInt32(submit);
                MissionQuestion question = db.MissionQuestions.Find(id);
                string reply = Request["replyBox" + submit];
                question.answer = reply;
                db.SaveChanges();
                return RedirectToAction("MissionDetails", new { menu = currentMission });
            }
        }

        public ActionResult CurrentUser(int id, string url)
        {
            currentUser = id;
            return RedirectToLocal(url);
        }

        private ActionResult RedirectToLocal(string url)
        {
            throw new NotImplementedException();
        }

        // Homemade logins, my dear old man
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email"].ToString();
            String password = form["Password"].ToString();
            IEnumerable<User> userModels = db.Database.SqlQuery<User>("SELECT * FROM [User] WHERE userEmail = '" + email + "' AND userPassword = '" + password + "'");
            User user = null;

            foreach (User item in userModels)
            {
                    user = item;
            }

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                currentUser = user.userID;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }
    }
}