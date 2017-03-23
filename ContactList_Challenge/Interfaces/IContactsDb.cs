using ContactList_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList_Challenge.Interfaces
{
    public interface IContactsDb
    {
        IList<Contact> Contacts { get; }
    }
}
