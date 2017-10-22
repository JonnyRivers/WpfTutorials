using System;

using Microsoft.Extensions.DependencyInjection;

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

            serviceCollection.AddTransient<IMainViewModel, MainViewModel>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
