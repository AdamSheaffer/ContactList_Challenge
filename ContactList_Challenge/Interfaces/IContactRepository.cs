using System.Collections.Generic;
using ContactList_Challenge.Models;

namespace ContactList_Challenge.Interfaces
{
    public interface IContactRepository
    {
        Contact AddOrUpdate(Contact contact);
        Contact GetById(string id);
        ICollection<Contact> GetContacts();
        Contact Remove(string id);
    }
}