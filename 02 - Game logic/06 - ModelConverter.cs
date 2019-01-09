using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class ModelConverter
    {
        public UserModel ToUserModel(User currentUser)
        {
            UserModel newUser = new UserModel
            {
                firstName = currentUser.FirstName,
                lastName = currentUser.LastName,
                birthDate = currentUser.BirthDate.Value,
                registerDate = currentUser.RegisterDate.Value,
                username = currentUser.Username,
                password = currentUser.Password,
                id = currentUser.ID,
                email = currentUser.Email
            };
            return newUser;
        }

        public User ToUser(UserModel currentUser)
        {
            User newUser = new User
            {
                FirstName = currentUser.firstName,
                LastName = currentUser.lastName,
                BirthDate = currentUser.birthDate,
                RegisterDate = currentUser.registerDate,
                Username = currentUser.username,
                Password = currentUser.password,
                ID = currentUser.id,
                Email = currentUser.email
            };
            return newUser;
        }

        public ImageModel ToImageModel(Image currentImage)
        {
            ImageModel newUser = new ImageModel
            {
                id = currentImage.ID,
                name = currentImage.Name
            };
            return newUser;
        }

        public List<ImageModel> ImageListToImageModel(List<Image> currentImages)
        {
            List<ImageModel> images = currentImages.Select(img => new ImageModel
            {
                id = img.ID,
                name = img.Name
            }).ToList();
            return images;
        }

        public List<FeedbackModel> FeedbacksToFeedbackModel(List<Feedback> currentFeedbacks)
        {
            List<FeedbackModel> feedbacks = currentFeedbacks.Select(fb => new FeedbackModel
            {
                id = fb.ID,
                username = fb.Username,
                date = fb.Date,
                subject = fb.Subject,
                content = fb.Content
            }).ToList();

            return feedbacks;
        }

        public Feedback ToFeedback(FeedbackModel feedback)
        {
            Feedback newFeedback = new Feedback
            {
                Username = feedback.username,
                Subject = feedback.subject,
                Content = feedback.content,
                Date = feedback.date
            };
            return newFeedback;
        }

        public List<ResultModel> ResultsToResultModelList(List<Result> results)
        {
            List<ResultModel> newResults = results.Select(res => new ResultModel
            {
                id = res.ID,
                userID = res.UserID,
                date = res.Date,
                duration = res.Duration,
                moveCount = res.MovesCount,
                score = res.Score,
                difficulty = res.Difficulty,
                username = res.Username,
                fullName = res.FullName
            }).ToList();

            return newResults;
        }

        public Result ToResult(ResultModel res)
        {
            DateTime duration = new DateTime();
            duration.AddMinutes(res.duration / 60);
            duration.AddSeconds(res.duration % 60);

            Result newResult = new Result
            {
                UserID = res.userID,
                Date = res.date,
                Duration = res.duration,
                MovesCount = res.moveCount,
                Score = res.score,
                Difficulty = res.difficulty,
                Username = res.username,
                FullName = res.fullName
            };
            return newResult;
        }

        public ContactMessage ToContactMessage(ContactMessageModel msg)
        {
            ContactMessage newMessage = new ContactMessage
            {
                Message = msg.message,
                PhoneNumber = msg.phoneNumber,
                Email = msg.email,
                Date = msg.date
            };
            return newMessage;
        }

        public ContactMessageModel ToContactMessageModel(ContactMessage msg)
        {
            ContactMessageModel newMessage = new ContactMessageModel
            {
                message = msg.Message,
                phoneNumber = msg.PhoneNumber,
                email = msg.Email,
                date = msg.Date,
                id = msg.ID
            };
            return newMessage;
        }
    }
      
}
