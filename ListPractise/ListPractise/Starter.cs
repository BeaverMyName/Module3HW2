using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListPractise.Collections;
using ListPractise.Collections.Abstractions;
using ListPractise.Models.Abstractions;
using ListPractise.Services;
using ListPractise.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ListPractise
{
    public class Starter
    {
        public void StartApplication()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ICultureService, CultureService>()
                .AddTransient<IPhoneBook<IContact>, PhoneBook<IContact>>()
                .AddTransient<Application>()
                .BuildServiceProvider();

            var application = serviceProvider.GetService<Application>();
            application.Run();
        }
    }
}
