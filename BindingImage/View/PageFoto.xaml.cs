using System;
using BindingImage.Models;
using BindingImage.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BindingImage.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFoto : ContentPage
    {
        public PageFoto()
        {
            InitializeComponent();
            this.BindingContext = new ViewModelFoto();
            imgFoto.Source = "Foto.png";
        }

        private MediaFile mediaFile;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //ViewModelFoto _ViewModelFoto = new ViewModelFoto();
            //_ViewModelFoto.EscolherFoto();



            // Upload
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Ops", "Galeria de fotos não suportada.", "OK");

                return;
            }

            mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (mediaFile == null)
                return;

            imgFoto.Source = ImageSource.FromStream(() =>
            {
                var stream = mediaFile.GetStream();
                //mediaFile.Dispose();
                return stream;
            });

        }
    }
    
}