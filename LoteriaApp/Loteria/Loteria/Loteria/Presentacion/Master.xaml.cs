using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Loteria.Presentacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void btn_usuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new usuario());
        }

        private void Billetera(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Billetera());

        }

        private void Boletos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Boletas());

        }

        private void Jugar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Jugar());

        }
        private void ganadores(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ganadores());

        }
    }
}