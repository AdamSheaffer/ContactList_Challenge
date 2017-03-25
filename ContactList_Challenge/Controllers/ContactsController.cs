using System;
using System.Collections.Generic;
using System.Web.Http;
using ContactList_Challenge.Interfaces;
using ContactList_Challenge.Models;

namespace ContactList_Challenge.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactRepository _repo;
        private readonly IPhoneNumberService _phoneSrvc;

        public ContactsController(IContactRepository repo, IPhoneNumberService phoneSrvc)
        {
            _repo = repo;
            _phoneSrvc = phoneSrvc;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _repo.GetContacts();
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            try
            {
                var contact = _repo.GetById(id);

                if (contact == null) return NotFound();

                return Ok(contact);
            }
            catch (Exception)
            {
                return BadRequest("There was an error retrieving this contact");
            }
            
        }

        [HttpPost]
        public IHttpActionResult Post(Contact contact)
        {
            if (contact == null || !ModelState.IsValid || !_phoneSrvc.IsValidNumber(contact.PhoneNumber))
            {
                return BadRequest("Contact is invalid");
            }

            try
            {
                contact.PhoneNumber = _phoneSrvc.FormatPhoneNumber(contact.PhoneNumber);
                var newContact = _repo.AddOrUpdate(contact);
                return Ok(newContact);
            }
            catch (FormatException)
            {
                return BadRequest("The contact is invalid");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("The request is invalid");
            }
            catch (Exception)
            {
                return BadRequest("Something unexpected happened");
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var contact = _repo.Remove(id);
                return Ok(contact);
            }
            catch (FormatException)
            {
                return BadRequest("The contact is invalid");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("The request is invalid");
            }
            catch (Exception)
            {
                return BadRequest("Something unexpected happened");
            }
        }
    }
}