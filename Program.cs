using System;

namespace AddressBook
{
    class Program
    {
        /// <summary>
        /// Address book program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Display display = new Display();
            display.DisplayChoiceAddressBook();
        }
    }
}