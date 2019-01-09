using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class UserLogic
    {
        private DAL dal = new DAL();

        public ModelConverter converter = new ModelConverter();

        public UserModel Login(UserModel user)
        {
            if (user.password == "" || user.password.Length < 8 || user.username == "" || user.username.Length < 6)
                return null;

            User userToCheck = dal.Login(user.username, user.password);
            if (userToCheck == null)
                return null;

            user = converter.ToUserModel(userToCheck);
            return user;
        }

        public UserModel Register(UserModel newUserDetails)
        {
            UserModel newUser;
            User verifiedUser;


            if (newUserDetails.firstName == "" || newUserDetails.lastName == "" || newUserDetails.password == "" && newUserDetails.password.Length < 8 || newUserDetails.username == "" || newUserDetails.username.Length < 6)
                return null;
          if (newUserDetails.email != "")
            {
                int emailCheck = EmailCheck(newUserDetails.email);
                if (emailCheck != 1)
                    return null;
            }

            verifiedUser = converter.ToUser(newUserDetails);

            verifiedUser.RegisterDate = DateTime.Now;

            verifiedUser = dal.Register(verifiedUser);
            newUser = converter.ToUserModel(verifiedUser);

            return newUser;
        }

        public int EmailCheck(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return 1;
            }
            catch (FormatException)
            {
                return 0;
            }
        }

        public ResultModel[] GetResultsByID(int id)
        {
            List<Result> resultList = dal.GetResultsByID(id);
            List<ResultModel> results = converter.ResultsToResultModelList(resultList);
            return results.ToArray();
        }
    }
}
