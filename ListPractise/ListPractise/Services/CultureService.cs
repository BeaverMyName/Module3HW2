using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using ListPractise.Services.Abstractions;
using ListPractise.Enums;

namespace ListPractise.Services
{
    public class CultureService : ICultureService
    {
        private readonly CultureInfo _defaultInfo;

        public CultureService()
        {
            _defaultInfo = CultureInfo.GetCultureInfo("en-Gb");
        }

        public CultureInfo GetCultureInfo(char key)
        {
            if (string.IsNullOrEmpty(key.ToString()))
            {
                throw new ArgumentException("Name is null or empty");
            }

            if (Regex.IsMatch(key.ToString(), "[A-Za-z]"))
            {
                return CultureInfo.GetCultureInfo("en-Gb");
            }
            else if (Regex.IsMatch(key.ToString(), "[ЁёА-Яа-я]"))
            {
                return CultureInfo.GetCultureInfo("ru-Ru");
            }
            else if (Regex.IsMatch(key.ToString(), "[$&+,:;=?@#|'<>.-^*()%!0-9]"))
            {
                return null;
            }
            else
            {
                return _defaultInfo;
            }
        }
    }
}
