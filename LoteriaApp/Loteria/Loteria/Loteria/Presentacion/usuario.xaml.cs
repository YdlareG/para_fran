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
    public partial class usuario : ContentPage
    {
        public usuario()
        {
            InitializeComponent();
        }
        private void ganadores(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Ganadores());

        }
        private void Billetera(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Billetera());

        }
    }
}