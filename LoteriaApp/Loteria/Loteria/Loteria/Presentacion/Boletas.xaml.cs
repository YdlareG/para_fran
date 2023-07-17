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
    public partial class Boletas : ContentPage
    {
        public Boletas()
        {
            InitializeComponent();
        }

        private void TicketButton_Clicked(object sender, EventArgs e)
        {
            // Lógica para el evento de clic del botón del ticket
            // Aquí puedes agregar la funcionalidad correspondiente, como guardar la selección del ticket o mostrar un mensaje al usuario.
        }
    }
}