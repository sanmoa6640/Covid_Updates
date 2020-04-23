using App2.PageModels;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // To set MainPage for the Application  
            Page page = FreshPageModelResolver.ResolvePageModel<MainPageModel>();

            FreshNavigationContainer container = new FreshNavigationContainer(page);

            MainPage = container;

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
