using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class FeedbackLogic
    {
        public ModelConverter converter = new ModelConverter();

        private DAL dal = new DAL();

        public List<FeedbackModel> GetFeedbacks()
        {
            List<FeedbackModel> feedbacks = converter.FeedbacksToFeedbackModel(dal.GetFeedbacks());
            return feedbacks;
        }

        public FeedbackModel PostFeedback(FeedbackModel feedback)
        {
            if (feedback.subject == "" || feedback.content == "" || feedback.date == null)
                return null;
            
            Feedback newFeedback = converter.ToFeedback(feedback);
            dal.PostFeedback(newFeedback);

            return feedback;
        }
    }
}
