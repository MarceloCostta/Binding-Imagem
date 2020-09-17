using BindingImage.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BindingImage.ViewModels
{
    class ViewModelFoto : ViewModelBase
    {
        private ImageSource _CAD_IMAGEM;
        public ImageSource CAD_IMAGEM
        {
            get => _CAD_IMAGEM;
            set
            {
                _CAD_IMAGEM = value;
                OnPropertyChanged();
            }
        }

        //private MediaFile mediaFile;
        //public async void EscolherFoto()
        //{
        //    // Upload
        //    await CrossMedia.Current.Initialize();

        //    if (!CrossMedia.Current.IsPickPhotoSupported)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Ops", "Galeria de fotos não suportada.", "OK");

        //        return;
        //    }

        //    mediaFile = await CrossMedia.Current.PickPhotoAsync();

        //    if (mediaFile == null)
        //        return;

        //    CAD_IMAGEM = ImageSource.FromStream(() =>
        //    {
        //        var stream = mediaFile.GetStream();
        //        //mediaFile.Dispose();
        //        return stream;
        //    });


        //}

        private Command _Commando;
        public Command Commando
            => _Commando
            ?? (_Commando = new Command(
                        () => CommandExecute(),
                        () => CommandCanExecute()));

        private bool CommandCanExecute()
            => CAD_IMAGEM != null;
        

        private void CommandExecute()
        {
            ModelFoto _ModelFoto = new ModelFoto();
            _ModelFoto.CAD_IMAGEM_BASE64 = ImageSourceToByteArray(CAD_IMAGEM);
        }

        private string ImageSourceToByteArray(ImageSource source)
        {
            StreamImageSource streamImageSource = (StreamImageSource)source;
            System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
            Task<Stream> task = streamImageSource.Stream(cancellationToken);
            Stream stream = task.Result;

            byte[] b;
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                b = ms.ToArray();
            }

            return System.Convert.ToBase64String(b);
        }
    }
}
