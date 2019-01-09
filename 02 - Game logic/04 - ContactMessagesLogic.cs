using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMMGame
{
    public class ContactMessagesLogic
    {
        public ModelConverter converter = new ModelConverter();

        private DAL dal = new DAL();

        public ContactMessageModel PostNewMessage(ContactMessageModel message)
        {
            if (message.message == "")
                return null;
            message.date = DateTime.Now;
            ContactMessage msg = converter.ToContactMessage(message);
            message = converter.ToContactMessageModel(dal.postContactMessage(msg));
            return message;
        }
    }
}
