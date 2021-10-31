using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListPractise.Models.Abstractions;

namespace ListPractise.Collections.Abstractions
{
    public interface IPhoneBook<T> : IEnumerable<T>
        where T : IContact
    {
        public IReadOnlyCollection<T> this[string key] { get; }

        public void Add(T contact);
    }
}
