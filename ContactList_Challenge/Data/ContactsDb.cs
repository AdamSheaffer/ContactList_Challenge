using System;
using System.Collections.Generic;
using System.Linq;
using ContactList_Challenge.Models;
using ContactList_Challenge.Interfaces;

namespace ContactList_Challenge.Data
{
    public class ContactsDb: IContactsDb
    {
        private static IList<Contact> _contacts;

        static ContactsDb()
        {
            _contacts = new List<Contact>
            {
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jeffery",
                    LastName = "Lebowski",
                    Email = "ElDuderino@hotmail.com",
                    Address1 = "636 Nixon Ave",
                    City = "Los Angeles",
                    State = "CA",
                    PhoneNumber = "(917) 367-4789"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Maude",
                    LastName = "Lebowski",
                    Email = "Maude@zestyenterprise.net",
                    Address1 = "1045 Johnson Ave",
                    City = "Los Angeles",
                    State = "CA",
                    PhoneNumber = "(917) 678-4222"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jackie",
                    LastName = "Treehorn",
                    Email = "Logjammer@Treehorn.org",
                    Address1 = "1 Electronic Cir",
                    City = "Malibu",
                    State = "CA",
                    PhoneNumber = "(917) 298-9245"
                }
            };
        }

        public IList<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
        }
    }
}