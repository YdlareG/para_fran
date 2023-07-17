using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Loteria.Presentacion
{
    public partial class Billetera : ContentPage
    {
        public Billetera()
        {
            InitializeComponent();
        }
        private void TransferButton_Clicked(object sender, System.EventArgs e)
        {
            ShowPopup(); // Mostrar ventana emergente
        }

        private void RetiroButton_Clicked(object sender, System.EventArgs e)
        {
            ShowPopup1(); // Mostrar ventana emergente
        }

        private void ShowPopup()
        {
            PopupFrame.IsVisible = true; // Mostrar ventana emergente
        }

        private void ShowPopup1()
        {
            PopupFrame2.IsVisible = true; // Mostrar ventana emergente
        }

        private void TransferButton_Popup_Clicked(object sender, System.EventArgs e)
        {
            // Lógica para transferir dinero

            // Volver a la pantalla de la billetera
            PopupFrame.IsVisible = false; // Ocultar ventana emergente
        }

        private void RetiroButton_Popup_Clicked(object sender, System.EventArgs e)
        {
            // Lógica para retirar dinero

            // Volver a la pantalla de la billetera
            PopupFrame2.IsVisible = false; // Ocultar ventana emergente
        }

        private void PayPalButton(object sender, EventArgs e)
        {
            // Abre la página web de PayPal en el navegador
            Device.OpenUri(new Uri("https://www.paypal.com"));
        }

        private void UsuarioRadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                UsuarioFrame.IsVisible = true;
            }
            else
            {
                UsuarioFrame.IsVisible = false;
            }
        }
    }
}