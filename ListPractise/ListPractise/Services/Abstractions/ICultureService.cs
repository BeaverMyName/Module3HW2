using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListPractise.Services.Abstractions
{
    public interface ICultureService
    {
        public CultureInfo GetCultureInfo(char key);
    }
}
