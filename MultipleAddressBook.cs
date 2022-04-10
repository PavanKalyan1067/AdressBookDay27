using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBook
{
    /// <summary>
    /// Create multiple addressbooks
    /// </summary>
    class MultipleAddressBook
    {
        static Dictionary<string, List<Contacts>> dtAddressbook;
        Dictionary<string, List<Contacts>> dtCities;
        Dictionary<string, List<Contacts>> dtStates;
        public MultipleAddressBook()
        {
            dtAddressbook = new Dictionary<string, List<Contacts>>();
            dtCities = new Dictionary<string, List<Contacts>>();
            dtStates = new Dictionary<string, List<Contacts>>();
        }
        /// <summary>
        /// ability to return addressBook Dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Contacts>> GetAddressBook()
        {
            return dtAddressbook;
        }
        /// <summary>
        /// create a new address book check for name,
        /// if already exists then, wont create new.
        /// </summary>
        /// <param name="name"></param>
        public bool AddAddressBook(string name)
        {
            //check for addressbook name
            if (dtAddressbook.ContainsKey(name))
            {
                Console.WriteLine("Name already exists!! \n Choose other Name and try Creating new AddressBook.");
                return false;
            }
            else
            {
                List<Contacts> contactsList = new List<Contacts>();
                Console.WriteLine("address book created successfully....");
                Console.WriteLine("Add new Contacts? \n Press Y/N :");
                char ch = Convert.ToChar(Console.ReadLine());
                ch = Char.ToUpper(ch);
                switch (ch)
                {
                    case 'Y':
                        ContactView contact = new ContactView();
                        Contacts newContact = contact.NewContact(contactsList);
                        if (newContact != null)
                        {
                            contactsList.Add(newContact);
                            dtAddressbook.Add(name, contactsList);
                            //utility to add contact person to city and state dictionary
                            UtilityToAddContactToCityState(newContact);
                        }
                        else
                            Console.WriteLine("Contact Add failed");
                        break;
                    case 'N':
                        dtAddressbook.Add(name, contactsList);
                        break;
                }
                return true;
            }
        }
        /// <summary>
        /// an uitility to add contacts to city and state dictionary
        /// </summary>
        /// <param name="newContact"></param>
        public void UtilityToAddContactToCityState(Contacts newContact)
        {
            List<Contacts> cityList = new List<Contacts>();
            List<Contacts> stateList = new List<Contacts>();
            //adding list to cities dictionary
            //if city key already exists then add to its list
            if (dtCities.ContainsKey(newContact.City))
            {
                dtCities[newContact.City].Add(newContact);
                Console.WriteLine($"Contact Added to CityList: {newContact.City}");
            }
            //if city key doesn't exists then add new key and list
            if (newContact.City != null && !dtCities.ContainsKey(newContact.City))
            {
                cityList.Add(newContact);
                dtCities.Add(newContact.City, cityList);
                Console.WriteLine("New City Detected, Added to CityList");
            }
            //adding contacts to States Dictionary
            if (dtStates.ContainsKey(newContact.State))
            {
                dtStates[newContact.State].Add(newContact);
                Console.WriteLine($"Contact Added to StateList: {newContact.State}");
            }
            if (newContact.State != null && !dtStates.ContainsKey(newContact.State))
            {
                stateList.Add(newContact);
                dtStates.Add(newContact.State, stateList);
                Console.WriteLine("New State Detected, Added to StateList");
            }
        }

        /// <summary>
        /// view all addressbooks present.
        /// </summary>
        public string ViewAddressBooks()
        {
            if (dtAddressbook.Count == 0)
                Console.WriteLine("No AddressBook(s) to Show.");
            if (dtAddressbook.Count >= 1)
            {
                Console.WriteLine("Select AddressBook(s):");
                foreach (var item in dtAddressbook.Keys)
                {
                    Console.WriteLine($"Enter name to Select AddressBook : {item}");
                }
                string addressBookName = Console.ReadLine();
                if (dtAddressbook.ContainsKey(addressBookName))
                    return addressBookName;
                else
                {
                    Console.WriteLine("Invalid Selection made!! \n Try again.");
                    ViewAddressBooks();
                }
            }
            return null;
        }
        /// <summary>
        /// ability to sort the contacts in list by Person's name
        /// </summary>
        /// <param name="contactsList"></param>
        public void SortAddressBookByName(List<Contacts> contactsList)
        {
            ContactView view = new ContactView();
            contactsList.Sort((contact1, contact2) => contact1.FirstName.CompareTo(contact2.FirstName));
            Console.WriteLine("Sorted Contacts By Name: ");
            view.Listview(contactsList);
        }

        /// <summary>
        /// ability to sort the contacts in list by Person's City
        /// </summary>
        /// <param name="contactsList"></param>
        public void SortAddressBookByCity(List<Contacts> contactsList)
        {
            ContactView view = new ContactView();
            contactsList.Sort((contact1, contact2) => contact1.City.CompareTo(contact2.City));
            Console.WriteLine("Sorted Contacts By City: ");
            view.Listview(contactsList);
        }
        /// <summary>
        /// ability to sort the contacts in list by Person's City
        /// </summary>
        /// <param name="contactsList"></param>
        public void SortAddressBookByState(List<Contacts> contactsList)
        {
            ContactView view = new ContactView();
            contactsList.Sort((contact1, contact2) => contact1.State.CompareTo(contact2.State));
            Console.WriteLine("Sorted Contacts By State: ");
            view.Listview(contactsList);
        }

        /// <summary>
        /// ability to sort the contacts in list by Person's City
        /// </summary>
        /// <param name="contactsList"></param>
        public void SortAddressBookByZipcode(List<Contacts> contactsList)
        {
            ContactView view = new ContactView();
            contactsList.Sort((contact1, contact2) => contact1.ZipCode.CompareTo(contact2.ZipCode));
            Console.WriteLine("Sorted Contacts By Zipcode: ");
            view.Listview(contactsList);
        }

        /// <summary>
        /// view Contacts by Cities
        /// </summary>
        public void DisplayContactsByCities()
        {
            if (dtCities.Count == 0)
                Console.WriteLine("No AddressBook(s) to Show.");
            if (dtCities.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contacts>> addressBooks in dtCities)
                {
                    Console.WriteLine("Contacts From City: " + addressBooks.Key + " :" + addressBooks.Value.Count);
                    foreach (Contacts items in addressBooks.Value)
                    {
                        Console.WriteLine($"Name: {items.FirstName + " " + items.LastName}, Phone Number: {items.PhoneNumber}, City: {items.City}, State: {items.State}" +
                            $"\n Address: {items.Address}, Zipcode: {items.ZipCode}, Email: {items.Email}");
                        Console.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// view Contacts by states
        /// </summary>
        public void DisplayContactsByStates()
        {
            if (dtStates.Count == 0)
                Console.WriteLine("No AddressBook(s) to Show.");
            if (dtStates.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contacts>> addressBooks in dtStates)
                {
                    Console.WriteLine("Contacts from State: " + addressBooks.Key + " :" + addressBooks.Value.Count);
                    foreach (Contacts items in addressBooks.Value)
                    {
                        Console.WriteLine($"Name: {items.FirstName + " " + items.LastName}, Phone Number: {items.PhoneNumber}, City: {items.City}, State: {items.State}" +
                            $"\n Address: {items.Address}, Zipcode: {items.ZipCode}, Email: {items.Email}");
                        Console.WriteLine();
                    }
                }
            }
        }
        /// <summary>
        /// ability to search contacts in multiple addressBooks using city or state name
        /// </summary>
        /// <param name="cityName"></param>
        public void SearchContactsByCity(string cityName)
        {
            if (dtAddressbook.Count == 0)
            {
                Console.WriteLine("No Contacts to display");
            }
            if (dtAddressbook.Count >= 1)
            {
                foreach (KeyValuePair<string, List<Contacts>> item in dtAddressbook)
                {
                    Console.WriteLine("Name of AddressBook: " + item.Key);
                    foreach (Contacts items in item.Value)
                    {
                        if (items.City.Contains(cityName) || items.State.Contains(cityName))
                        {
                            Console.WriteLine($"Name: {items.FirstName + " " + items.LastName}, Phone Number: {items.PhoneNumber}, City: {items.City}, State: {items.State}");
                            Console.WriteLine();
                        }
                    }
                }
            }

        }
    }
}