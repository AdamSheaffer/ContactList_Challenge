using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using ContactList_Challenge.Controllers;
using ContactList_Challenge.Interfaces;
using ContactList_Challenge.Models;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace ContactList_Challenge.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTests
    {
        private ContactsController _controller;
        private Mock<IContactRepository> _repo;
        private Mock<IPhoneNumberService> _phoneService;

        [TestInitialize]
        public void Setup()
        {
            _repo = new Mock<IContactRepository>();
            _repo.Setup(r => r.GetContacts()).Returns(allContacts);
            _repo.Setup(r => r.GetById(It.IsNotNull<string>())).Returns(allContacts.First()); // GetById always returns first unless null is passed
            _repo.Setup(r => r.AddOrUpdate(It.IsAny<Contact>())).Returns(NewContact());
            _repo.Setup(r => r.Remove(It.IsAny<string>())).Returns(allContacts.First()); // Remove always returns first

            _phoneService = new Mock<IPhoneNumberService>();
            _phoneService.Setup(s => s.FormatPhoneNumber(It.IsAny<string>())).Returns("1234567890");
            _phoneService.Setup(s => s.IsValidNumber(It.IsAny<string>())).Returns(true);

            _controller = new ContactsController(_repo.Object, _phoneService.Object);
        }

        [TestMethod]
        public void ControllerShouldGetAllContacts()
        {
            var contacts = _controller.Get();

            Assert.AreEqual(allContacts, contacts);
        }

        [TestMethod]
        public void ControllerShouldGetByValidId()
        {
            var result = _controller.Get(allContacts.First().Id.ToString()) as OkNegotiatedContentResult<Contact>;

            Assert.AreEqual(allContacts.First(), result.Content);
        }

        [TestMethod]
        public void ControllerShouldNotFindInvalidId()
        {
            var result = _controller.Get(null);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
        
        [TestMethod]
        public void ControllerShouldPostNewContact()
        {
            var result = _controller.Post(NewContact()) as OkNegotiatedContentResult<Contact>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.FirstName, "First Name");
            Assert.AreEqual(result.Content.LastName, "Last Name");
        }

        private ICollection<Contact> allContacts = new List<Contact>
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

        private Contact NewContact()
        {
            return new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "First Name",
                LastName = "Last Name",
                PhoneNumber = "123-456-7891"
            };
        }

    }
}
