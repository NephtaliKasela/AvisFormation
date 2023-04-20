using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IContactRepository
    {
        public void SaveMessage(string name, string email, string message);
    }

    public class ContactRepository: IContactRepository
    {
        MonDBContext _context;
        public ContactRepository(MonDBContext context)
        {
            _context = context;
        }

        public void SaveMessage(string name, string email, string message)
        {
            var msg = new ContactMessage();
            msg.Name = name;
            msg.Email = email;
            msg.Message = message;

            _context.Messages.Add(msg);
            _context.SaveChanges();
        }
    }

    
}
