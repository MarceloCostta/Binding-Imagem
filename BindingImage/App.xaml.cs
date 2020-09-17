using BindingImage.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BindingImage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PageFoto();
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
