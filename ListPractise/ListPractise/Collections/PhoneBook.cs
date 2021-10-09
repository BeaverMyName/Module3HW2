using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using ListPractise.Services.Abstractions;
using ListPractise.Collections.Abstractions;
using ListPractise.Models.Abstractions;
using ListPractise.Enums;

namespace ListPractise.Collections
{
    public class PhoneBook<T> : IPhoneBook<T>
        where T : IContact
    {
        private readonly IDictionary<CultureInfo, IList<T>> _culturedCollections;
        private readonly IDictionary<CharType, IList<T>> _specialCollections;
        private readonly ICultureService _cultureService;

        public PhoneBook(ICultureService cultureService)
        {
            _cultureService = cultureService;
            _culturedCollections = new Dictionary<CultureInfo, IList<T>>();
            _culturedCollections.Add(CultureInfo.GetCultureInfo("ru-Ru"), new List<T>());
            _culturedCollections.Add(CultureInfo.GetCultureInfo("en-Gb"), new List<T>());
            _specialCollections = new Dictionary<CharType, IList<T>>();
            _specialCollections.Add(CharType.Number, new List<T>());
            _specialCollections.Add(CharType.Special, new List<T>());
        }

        public IReadOnlyCollection<T> this[string key]
        {
            get
            {
                var collection = DetermineCollection(key);
                var result = new List<T>();

                foreach (var contact in collection)
                {
                    if (contact.Name.StartsWith(key, StringComparison.InvariantCultureIgnoreCase))
                    {
                        result.Add(contact);
                    }
                }

                return result;
            }
        }

        public void Add(T contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
            {
                throw new ArgumentException("Name is null or empty");
            }

            var collection = DetermineCollection(contact.Name);

            var index = GetIndex(contact.Name[0], collection);

            if (index != -1)
            {
                collection.Insert(index, contact);
            }
            else
            {
                collection.Add(contact);
            }
        }

        public IList<T> DetermineCollection(string name)
        {
            var cultureInfo = _cultureService.GetCultureInfo(name[0]);

            if (cultureInfo == null)
            {
                if (Regex.IsMatch(name[0].ToString(), "[0-9]"))
                {
                    return _specialCollections[CharType.Number];
                }
                else
                {
                    return _specialCollections[CharType.Special];
                }
            }

            return _culturedCollections[cultureInfo];
        }

        public int GetIndex(char key, IList<T> collection)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (key < collection[i].Name[0])
                {
                    return i;
                }
            }

            return -1;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var collection in _culturedCollections)
            {
                foreach (var contact in collection.Value)
                {
                    yield return contact;
                }
            }

            foreach (var collection in _specialCollections)
            {
                foreach (var contact in collection.Value)
                {
                    yield return contact;
                }
            }

            yield break;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var collection in _culturedCollections)
            {
                foreach (var contact in collection.Value)
                {
                    yield return contact;
                }
            }

            foreach (var collection in _specialCollections)
            {
                foreach (var contact in collection.Value)
                {
                    yield return contact;
                }
            }

            yield break;
        }
    }
}
