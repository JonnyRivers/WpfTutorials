using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDITestbed.IoC
{
    public class IoCContainer
    {
        private static IServiceProvider _provider;

        public static IServiceProvider Provider
        {
            get
            {
                if (_provider == null)
                {
                    _provider = CreateServiceProvider();
                }

                return _provider;
            }
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<ITextService, TextService>();

            serviceCollection.AddTransient<MainViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
