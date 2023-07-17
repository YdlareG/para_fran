using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Xamarin.Forms;

namespace Loteria.Presentacion
{
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string nombres = NombresEntry.Text;
            string apellidos = ApellidosEntry.Text;
            string correoElectronico = CorreoElectronicoEntry.Text;
            // Otros campos de registro

            try
            {
                // Construir el objeto con los datos del registro
                var registroObjeto = new
                {
                    Nombres = nombres,
                    Apellidos = apellidos,
                    CorreoElectronico = correoElectronico,
                    // Otros campos de registro
                };
                var registroJson = JsonConvert.SerializeObject(registroObjeto);
                var contenido = new StringContent(registroJson, Encoding.UTF8, "application/json");

                // URL del endpoint de registro en el servidor
                string url = "http://tu_servidor/registro";

                // Realizar la solicitud HTTP POST al servidor
                using (var httpClient = new HttpClient())
                {
                    var respuesta = await httpClient.PostAsync(url, contenido);

                    if (respuesta.IsSuccessStatusCode)
                    {
                        // Registro exitoso
                    }
                    else
                    {
                        // Manejar el caso de error en el registro
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el caso de error en la solicitud
            }
        }


        private void MostrarPass(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
            ConfirmPasswordEntry.IsPassword = !ConfirmPasswordEntry.IsPassword;

            if (PasswordEntry.IsPassword)
            {
                BtnOjo.Source = "ojo.png";
            }
            else
            {
                BtnOjo.Source = "ojoVista.png";
            }
        }

    }
}
