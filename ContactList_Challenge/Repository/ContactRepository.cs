using System;
using System.Collections.Generic;
using System.Linq;
using ContactList_Challenge.Interfaces;
using ContactList_Challenge.Models;

namespace ContactList_Challenge.Repository
{
    public class ContactRepository : IContactRepository
    {
        private IContactsDb _db;

        public ContactRepository(IContactsDb db)
        {
            _db = db;
        }

        public ICollection<Contact> GetContacts()
        {
            return _db.Contacts;
        }

        public Contact GetById(string id)
        {
            var guid = Guid.Parse(id);
            return _db.Contacts.FirstOrDefault(c => c.Id == guid);
        }

        public Contact AddOrUpdate(Contact contact)
        {
            return contact.Id == Guid.Empty ? Add(contact) : Update(contact);
        }

        public Contact Remove(string id)
        {
            var guid = Guid.Parse(id);
            var index = Array.FindIndex(_db.Contacts.ToArray(), c => c.Id == guid);
            var contact = _db.Contacts[index];
            _db.Contacts.RemoveAt(index);
            return contact;
        }

        private Contact Add(Contact newContact)
        {
            newContact.Id = Guid.NewGuid();
            _db.Contacts.Add(newContact);
            return newContact;
        }

        private Contact Update(Contact newContact)
        {
            var index = Array.FindIndex(_db.Contacts.ToArray(), c => c.Id == newContact.Id);
            _db.Contacts[index] = newContact;
            return _db.Contacts[index];
        }
    }
}