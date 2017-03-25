using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactList_Challenge.Data;
using ContactList_Challenge.Models;

namespace ContactList_Challenge.Tests.Data
{
    [TestClass]
    public class ContactsDbTests
    {
        // Quick Sanity Check
        [TestMethod]
        public void ContactsDbShouldHaveContacts()
        {
            var db = new ContactsDb();

            Assert.IsNotNull(db);
            Assert.IsNotNull(db.Contacts);
            Assert.AreEqual(8, db.Contacts.Count);
        }
    }
}
