using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList_Challenge.Interfaces
{
    public interface IPhoneNumberService
    {
        bool IsValidNumber(string number);
        string FormatPhoneNumber(string number);
    }
}
