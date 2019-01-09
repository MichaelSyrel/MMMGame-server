using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class DAL : IDisposable
    {
        protected MMMGameEntities DB = new MMMGameEntities();
        //AFTER SETUP YOU MUST CHANGE THE SOURCE IN YOUR WEB CONFIG AND APP CONFIG TO YOUR SERVER NAME.
        public List<Image> GetImages()
        {
            List<Image> imageList = DB.Images.ToList();
            return imageList;
        }

        public User Login(string username, string password)
        {
            User currentUser = new User();

            currentUser = DB.Users.Where(prm => prm.Username == username && prm.Password == password).SingleOrDefault();

            return currentUser;
        }

        public User Register(User newUser)
        {
            DB.Users.Add(newUser);
            DB.SaveChanges();
            return newUser;
        }

        public Feedback PostFeedback(Feedback feedback)
        {
            DB.Feedbacks.Add(feedback);
            DB.SaveChanges();
            return feedback;
        }

        public List<Feedback> GetFeedbacks()
        {
            return DB.Feedbacks.ToList();
        }

        public List<Result> GetResults()
        {
            return DB.Results.ToList();
        }

        public void Dispose()
        {
            DB.Dispose();
        }

        public Result AddResult(Result res)
        {
            DB.Results.Add(res);
            DB.SaveChanges();
            return res;
        }

        public ContactMessage postContactMessage(ContactMessage msg)
        {
            DB.ContactMessages.Add(msg);
            DB.SaveChanges();
            return msg;
        }

        public List<Result> GetResultsByID(int id)
        {
            return DB.Results.Where(r => r.UserID == id).ToList();
        }
    }
}
