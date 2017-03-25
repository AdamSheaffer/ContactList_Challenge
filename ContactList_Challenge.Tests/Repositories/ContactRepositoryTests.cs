using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList_Challenge.Repository;
using ContactList_Challenge.Models;
using ContactList_Challenge.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace ContactList_Challenge.Tests.Repositories
{
    [TestClass]
    public class ContactRepositoryTests
    {
        private ContactRepository _repo;
        private Mock<IContactsDb> _contactsDb;
        private IList<Contact> _contacts;

        private void BuildContactsList()
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

        [TestInitialize]
        public void Setup()
        {
            BuildContactsList();

            _contactsDb = new Mock<IContactsDb>();
            _contactsDb.Setup(db => db.Contacts).Returns(_contacts);
            _repo = new ContactRepository(_contactsDb.Object);
        }

        [TestMethod]
        public void RepoShouldGetAllContacts()
        {
            var contacts = _repo.GetContacts();

            Assert.AreEqual(_contacts, contacts);
        }

        [TestMethod]
        public void RepoShouldAttachGuidOnAdd()
        {
            var newContact = new Contact
            {
                Id = Guid.Empty,
                FirstName = "Foo",
                LastName = "Bar"
            };

            var contact = _repo.AddOrUpdate(newContact);

            Assert.AreNotEqual(contact.Id, Guid.Empty);
        }

        [TestMethod]
        public void RepoShouldAddContact()
        {
            var newContact = new Contact
            {
                Id = Guid.Empty,
                FirstName = "Foo",
                LastName = "Bar"
            };

            _repo.AddOrUpdate(newContact);

            var endingCount = _repo.GetContacts().Count;

            Assert.AreEqual(4, endingCount);
        }

        [TestMethod]
        public void RepoShouldUpdateAContact()
        {
            var contact = _contacts[0];
            var newName = "Walter";
            contact.FirstName = newName;

            _repo.AddOrUpdate(contact);

            var dbContact = _repo.GetContacts().FirstOrDefault(c => c.Id == contact.Id);
            var endingCount = _repo.GetContacts().Count;

            Assert.IsNotNull(dbContact);
            Assert.AreEqual(newName, dbContact.FirstName);
            Assert.AreEqual(3, endingCount);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RepoShouldThrowExceptionIfGettingByNonGuid()
        {
            _repo.GetById("Bad Id");
        }

        [TestMethod]
        public void RepoShouldReturnNullOnNotFoundGuid()
        {
            var contact = _repo.GetById(Guid.NewGuid().ToString());

            Assert.IsNull(contact);
        }

        [TestMethod]
        public void RepoShouldGetContactByValidId()
        {
            var contact = _contacts[1];
            var result = _repo.GetById(contact.Id.ToString());

            Assert.AreEqual(contact, result);
        }
    }

}
