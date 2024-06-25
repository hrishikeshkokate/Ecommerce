using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IContactUsService
    {
        IEnumerable<ContactUs> GetAllMessages();
        ContactUs GetMessageById(int id);
        int AddMessage(ContactUs contactus);

        int DeleteMessage(int id);
    }
}
