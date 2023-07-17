using Loteria.CustomRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Loteria.Presentacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void IrRegistrarse(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        private async void irmenu(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new mainmaster());
        }

        private async void IrBilletera(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Billetera());
        }

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            string usuario = userSpace.Text;
            string contrasenia = passSpace.Text;

            try
            {
                // Construir el objeto con los datos del usuario
                var usuarioObjeto = new { Usuario = usuario, Contrasenia = contrasenia };
                var usuarioJson = JsonConvert.SerializeObject(usuarioObjeto);
                var contenido = new StringContent(usuarioJson, System.Text.Encoding.UTF8, "application/json");

                // URL del endpoint de inicio de sesión en el servidor
                string url = "http://tu_servidor/login";

                // Realizar la solicitud HTTP POST al servidor
                HttpClient cliente = new HttpClient();
                var respuesta = await cliente.PostAsync(url, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer la respuesta del servidor
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    var respuestaObjeto = JsonConvert.DeserializeObject<dynamic>(contenidoRespuesta);

                    // Obtener el ID de usuario de la respuesta del servidor
                    int idUsuario = respuestaObjeto.idUsuario;

                    // Aquí puedes realizar alguna acción con el ID de usuario, como mostrar una nueva página, etc.
                    // Por ejemplo, mostrar un mensaje con el ID de usuario en un label.
                    // resultadoLabel.Text = "Inicio de sesión exitoso. ID de usuario: " + idUsuario;
                }
                else
                {
                    // resultadoLabel.Text = "Credenciales inválidas. Inténtalo nuevamente.";
                }
            }
            catch (Exception ex)
            {
                // resultadoLabel.Text = "Error al realizar el inicio de sesión: " + ex.Message;
            }
        }

        private void MostrarPass(object sender, EventArgs e)
        {
            passSpace.IsPassword = !passSpace.IsPassword;

            if (passSpace.IsPassword == true)
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
