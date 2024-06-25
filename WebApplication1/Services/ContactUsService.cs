﻿using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepo repo;

        public ContactUsService(IContactUsRepo repo)
        {
            this.repo = repo;
        }
        public int AddMessage(ContactUs contactus)
        {
            return repo.AddMessage(contactus);
        }

        public int DeleteMessage(int id)
        {
            return repo.DeleteMessage(id);
        }

        public IEnumerable<ContactUs> GetAllMessages()
        {
            return repo.GetAllMessages();
        }

        public ContactUs GetMessageById(int id)
        {
            return repo.GetMessageById(id);
        }
    }
}
