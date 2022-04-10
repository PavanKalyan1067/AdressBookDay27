using System;
using System.Collections.Generic;

namespace AddressBooks
{
    class Program
    {

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
                    addrBook.GetCustomer(FirstName, LastName, PhoneNumber, Addresses, City, State, ZipCode, EmailId);
                    noOfContact--;
                    //addressBook.Add(addressbookname, addrBook.people);
                    Console.WriteLine(" ");
                    addrBook.ListingPeople();
                }
                Console.WriteLine("1.To modify the details");
                Console.WriteLine("2.To remove the details");
                Console.WriteLine("3.city or state");
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
                    case 3:
                        Console.WriteLine("Enter 1-To Search a person through a City");
                        Console.WriteLine("Enter 2-To Search a person through a State");
                        Console.WriteLine("Enter 3-To view a person by state list or city list");
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
                            default:
                                Console.WriteLine("Invalid Option!");
                                break;
                        }
                        break;
                }
                if (addressBook.ContainsKey(addressbookname))
                {
                    Console.WriteLine("Existing address book name");
                    return;
                }
                else
                {
                    addressBook.Add(addressbookname, addrBook.people);
                }
                noOfBooks++;
                foreach (KeyValuePair<string, List<AddrBook>> addr in addressBook)
                {
                    Console.WriteLine("The address Books are:{0}", addr.Key);

                }
            }
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