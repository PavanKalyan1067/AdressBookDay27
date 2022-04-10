using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{/// <summary>
 /// OOP's concepts for saving user details
 /// using Encapsulation, properties, Interface, Exceptions
 /// getting contacts from user 
 /// </summary>
    interface IContactDetails
    {
        void ValidateContactDetails();
    }
    class Contacts : IContactDetails
    {
        //variables
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private int zipCode;
        private long phoneNumber;
        private string email;

        //properties
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }
        public int ZipCode
        {
            get
            {
                return zipCode;
            }

            set
            {
                zipCode = value;
            }
        }
        public long PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        private bool ValidateFullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            try
            {
                if (FirstName != " " && LastName != " ")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Full Name");
            }
            return false;
        }

        private bool ValidateAddress(string address, string city, string state, int zipCode)
        {
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            try
            {
                if (Address != " " && City != " " && State != " " && ZipCode != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Address");
            }
            return false;
        }
        private bool ValidateContactNumbers(long phoneNumber, string email)
        {
            PhoneNumber = phoneNumber;
            Email = email;
            try
            {
                if (PhoneNumber != 0 && Email != " ")
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Contact Numbers");
            }
            return false;
        }
        public void ValidateContactDetails()
        {
            try
            {
                bool full_Name = ValidateFullName(FirstName, LastName);
                bool addr = ValidateAddress(Address, City, State, ZipCode);
                bool contact = ValidateContactNumbers(PhoneNumber, Email);
                if (full_Name == true && addr == true && contact == true)
                    Console.WriteLine("Contact Details Saved Successfully");
                else
                    Console.WriteLine("Contact Save Failed!!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error in Saving Details");
            }
        }
    }
}