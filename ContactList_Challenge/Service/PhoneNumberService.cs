using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneNumbers;
using ContactList_Challenge.Interfaces;

namespace ContactList_Challenge.Service
{
    public class PhoneNumberService: IPhoneNumberService
    {
        public bool IsValidNumber(string number)
        {
            if (String.IsNullOrWhiteSpace(number)) return false;
            return PhoneNumberUtil.IsViablePhoneNumber(number);
        }

        public string FormatPhoneNumber(string number)
        {
            return PhoneNumberUtil.Normalize(number);
        }
    }
}