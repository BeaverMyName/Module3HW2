using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListPractise.Collections.Abstractions;
using ListPractise.Models;
using ListPractise.Models.Abstractions;

namespace ListPractise
{
    public class Application
    {
        private readonly IPhoneBook<IContact> _phoneBook;

        public Application(IPhoneBook<IContact> phoneBook)
        {
            _phoneBook = phoneBook;
        }

        public void Run()
        {
            _phoneBook.Add(new Contact() { Name = "Igor", LastName = "Serduik" });
            _phoneBook.Add(new Contact() { Name = "Igor", LastName = "Bobro" });
            _phoneBook.Add(new Contact() { Name = "Ilya", LastName = "Добродушный" });
            _phoneBook.Add(new Contact() { Name = "Сергей", LastName = "Иванов" });
            _phoneBook.Add(new Contact() { Name = "Piter", LastName = "Parker" });
            _phoneBook.Add(new Contact() { Name = "Harry", LastName = "Potter" });
            _phoneBook.Add(new Contact() { Name = "Alex", LastName = "May" });
            _phoneBook.Add(new Contact() { Name = "Hygo", LastName = "Jackson" });
            _phoneBook.Add(new Contact() { Name = "Marlin", LastName = "Monro" });
            _phoneBook.Add(new Contact() { Name = "Антон", LastName = "Птушкин" });
            _phoneBook.Add(new Contact() { Name = "&Гарик", LastName = "Харламов" });
            _phoneBook.Add(new Contact() { Name = "04237fasdf49234" });
            _phoneBook.Add(new Contact() { Name = "321323749234" });
            _phoneBook.Add(new Contact() { Name = "0423749234" });
            _phoneBook.Add(new Contact() { Name = "0933749234" });
            _phoneBook.Add(new Contact() { Name = "*111#" });

            var x = _phoneBook["Ig"];

            DisplayCollection();
        }

        public void DisplayCollection()
        {
            foreach (var contact in _phoneBook)
            {
                Console.WriteLine(contact.Name);
            }
        }
    }
}
