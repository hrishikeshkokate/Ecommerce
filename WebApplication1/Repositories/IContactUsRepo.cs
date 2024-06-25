using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IContactUsRepo
    {
        IEnumerable<ContactUs> GetAllMessages();
        ContactUs GetMessageById(int id);
        int AddMessage(ContactUs contactus);

        int DeleteMessage(int id);
    }
}
