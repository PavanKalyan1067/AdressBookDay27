using System;
using System.Collections.Generic;

namespace AddressBooks
{
    class Program
    {
        //Creating a dictionary for city,state aand person details
        public static Dictionary<string, List<AddrBook>> addressBook = new Dictionary<string, List<AddrBook>>();
        public static Dictionary<string, List<AddrBook>> City = new Dictionary<string, List<AddrBook>>();
        public static Dictionary<string, List<AddrBook>> State = new Dictionary<string, List<AddrBook>>();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Address Book System!");
            Console.WriteLine("Enter the number of address books: ");
            int noOfAddressBook = Convert.ToInt32(Console.ReadLine());
            int noOfBooks = 0;
            while (noOfBooks < noOfAddressBook)
            {
                Console.WriteLine("Enter the address book name : ");
                string addressbookname = Console.ReadLine();
                AddrBook addrBook = new AddrBook();
                Console.WriteLine("Enter the no of contacts in the address book: ");
                int noOfContact = Convert.ToInt32(Console.ReadLine());

                while (noOfContact > 0)
                {
                    Console.WriteLine("Enter the details of contact to be added: ");
                    //Getting the user details

                    Console.Write("Enter First Name: ");
                    string FirstName = Console.ReadLine();

                    Console.Write("Enter Last Name: ");
                    string LastName = Console.ReadLine();

                    Console.Write("Enter Phone Number: ");
                    string PhoneNumber = Console.ReadLine();

                    Console.Write("Enter Address : ");
                    string Addresses = Console.ReadLine();

                    Console.Write("Enter City : ");
                    string City = Console.ReadLine();

                    Console.Write("Enter State : ");
                    string State = Console.ReadLine();

                    Console.Write("Enter ZipCode: ");
                    string ZipCode = Console.ReadLine();

                    Console.Write("Enter EmailId: ");
                    string EmailId = Console.ReadLine();
                    //Calling the getcustomer method and store it dictionary
                    addrBook.GetCustomer(FirstName, LastName, PhoneNumber, Addresses, City, State, ZipCode, EmailId);
                    noOfContact--;
                    Console.WriteLine(" ");
                    //Print the details
                    addrBook.ListingPeople();
                }
                Console.WriteLine("1.To modify the details");
                Console.WriteLine("2.To remove the details");
                Console.WriteLine("3.Exit from loop");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addrBook.Modify();
                        Console.WriteLine(" ");
                        addrBook.ListingPeople();
                        break;
                    case 2:
                        addrBook.RemovePeople();
                        Console.WriteLine(" ");
                        addrBook.ListingPeople();
                        break;
                }
                //Checking the address book name is already exist or not
                if (addressBook.ContainsKey(addressbookname))
                {
                    Console.WriteLine("Existing address book name");
                    return;
                }
                //If not add it in dictionary
                else
                {
                    addressBook.Add(addressbookname, addrBook.people);
                }

                noOfBooks++;

                //Displaying the address book names
                foreach (KeyValuePair<string, List<AddrBook>> addr in addressBook)
                {
                    Console.WriteLine("The address Books are:{0}", addr.Key);

                }
                //Searching and sorting operations based on city,state,name,zipcode

                Console.WriteLine("Enter 1-To Search a person through a City");
                Console.WriteLine("Enter 2-To Search a person through a State");
                Console.WriteLine("Enter 3-To view a person by state list or city list");
                Console.WriteLine("Enter 4-Sort Contact People");
                Console.WriteLine("Enter 5-Sort based on city");
                Console.WriteLine("Enter 6-Sort based on State");
                Console.WriteLine("Enter 7-Sort based on zipcode");
                int opt = Convert.ToInt32(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        SearchAddress(opt);
                        break;
                    case 2:
                        SearchAddress(opt);
                        break;
                    case 3:
                        AddrBook.DisplayCityorState();
                        break;
                    case 4:
                        AddrBook.SortContactPerson(addressBook);
                        break;
                    case 5:
                        AddrBook.SortBasedOnCity(addressBook);
                        break;
                    case 6:
                        AddrBook.SortBasedOnState(addressBook);
                        break;
                    case 7:
                        AddrBook.SortBasedOnZipCode(addressBook);
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
                //Search the person through city or state
                static void SearchAddress(int option)
                {
                    string city, state;
                    if (option == 1)
                    {
                        Console.WriteLine("Enter the City Name");
                        city = Console.ReadLine();
                        foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
                        {
                            AddrBook.StoreCityList(kvp.Key, kvp.Value, city);

                        }
                        if (option == 2)
                        {
                            Console.WriteLine("Enter the City Name");
                            state = Console.ReadLine();
                            foreach (KeyValuePair<string, List<AddrBook>> kvp in addressBook)
                            {
                                AddrBook.StoreStateList(kvp.Key, kvp.Value, state);
                            }
                        }
                    }
                }
            }
        }
    }

}