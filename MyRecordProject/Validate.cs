using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRecordProject
{
    class Validate
    {
        public bool RecordNumber_IsValid(string record)
        {
            if (String.IsNullOrWhiteSpace(record) || record.Any(x => Char.IsWhiteSpace(x)))
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        public bool AccountNumber_IsValid(string record)
        {
            if (record.Contains("-"))
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        public bool FirstName_IsValid(string name)
        {

            if (name != null && name.Length <= 20)
            {
                return true;
            }

            throw new NotImplementedException();

        }
        public bool LastName_IsValid(string name)
        {
            if (name != null && name.Length <= 20)
            {
                return true;
            }

            throw new NotImplementedException();

        }
        public bool AddressLine1_IsValid(string address)
        {
            if (address != null && address.Length <= 30)
            {
                return true;
            }

            throw new NotImplementedException();

        }
        public bool City_IsValid(string city)
        {
            if (city != null && city.Length <= 20)
            {
                return true;
            }

            throw new NotImplementedException();

        }
        public bool State_IsValid(string state)
        {
            if (state != null && state.Length == 2)
            {

                for (int i = 0; i < state.Length; i++)
                {
                    //checks if the two letter are uppercase to see if state initials were given
                    if (Char.IsLetter(state[i]) && Char.IsUpper(state[i]))
                        return true;
                }

            }

            return false;
        }
        public bool Amount_IsValid(double amount)
        {
            if (amount != 0 && amount <= 10000 && amount.ToString().Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
    }
}
