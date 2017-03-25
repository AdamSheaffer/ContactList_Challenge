using System;
using System.Collections.Generic;
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
                    PhoneNumber = "9173674789"
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
                    PhoneNumber = "9176784222"
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
                    PhoneNumber = "9172989245"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bunny",
                    LastName = "Lebowski",
                    Email = "IOU@Treehorn.org",
                    Address1 = "15 Lebowski Ave",
                    City = "Malibu",
                    State = "CA",
                    PhoneNumber = "9176542945"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "The Dude",
                    Email = "The@Dude.gov",
                    Address1 = "1 Nixon Ct",
                    City = "Los Angeles",
                    State = "CA",
                    PhoneNumber = "9172349245"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Ulee",
                    LastName = "Kunkel",
                    Email = "Logjammer2@Treehorn.org",
                    Address1 = "1 Electronic Cir",
                    City = "Malibu",
                    State = "CA",
                    PhoneNumber = "9172889245"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Walter",
                    LastName = "Sobchak",
                    Email = "DirtyUndies@TheWhites.net",
                    Address1 = "456 Veterans Dr",
                    City = "Malibu",
                    State = "CA",
                    PhoneNumber = "9172879233"
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Brandt",
                    LastName = "??",
                    Email = "Brandt@unknown.com",
                    Address1 = "876 Lebowski Dr",
                    City = "Malibu",
                    State = "CA",
                    PhoneNumber = "9172879233"
                },
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