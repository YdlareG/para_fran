const express = require('express');
const cors = require('cors');
const sql = require('mssql');

const app = express();

app.use(cors());
app.use(express.json());
// Configuración de la conexión a la base de datos
const config = {
  server: 'localhost',
  database: 'BD_LOTERIA',
  options: {
    encrypt: true,
    trustServerCertificate: true
  },
  authentication: {
    type: 'default',
    options: {
      userName: 'sa', // Reemplaza 'tu_usuario' con el nombre de usuario de la base de datos
      password: '12345678' // Reemplaza 'tu_contraseña' con la contraseña del usuario
    }
  }
};


app.post('/login', async (req, res) => {
  try {
    // Establecer la conexión a la base de datos
    const pool = await sql.connect(config);

    // Obtener el usuario y contraseña del cuerpo de la solicitud
    const { usuario, contrasenia } = req.body;

    // Consultar el usuario y contraseña en la base de datos
    const result = await pool.request()
      .input('usuario', sql.VarChar, usuario)
      .input('Contrasenia', sql.VarChar, contrasenia)
      .query('SELECT id_usuario FROM Usuarios WHERE Correo_electronico = @usuario AND contrasena = @Contrasenia');

    // Cerrar la conexión a la base de datos
    sql.close();

    // Verificar si se encontró un usuario con las credenciales proporcionadas
    if (result.recordset.length === 1) {
      const idUsuario = result.recordset[0].id_usuario;
      console.log('Bienvenido'); // Muestra "Bienvenido" en la consola
      res.json({ idUsuario });
    } else {
      console.log('Error: Credenciales inválidas'); // Muestra el error en la consola
      res.status(401).json({ error: 'Credenciales inválidas' });
    }

  } catch (error) {
    console.error('Error en el servidor:', error);
    res.status(500).json({ error: 'Error interno en el servidor' });
  }
});

app.post('/registro', async (req, res) => {
  try {
    const { nombre, apellido, correo, telefono,direccion, contrasenia } = req.body;

    // Establecer la conexión a la base de datos
    const pool = await sql.connect(config);

    // Llamar al procedimiento almacenado para insertar o actualizar el usuario
    const result = await pool.request()
      .input('id_usuario', sql.Int, 0) // 0 para indicar que es un nuevo registro
      .input('Nombre', sql.VarChar, nombre)
      .input('Apellido', sql.VarChar, apellido)
      .input('Telefono', sql.VarChar, telefono)
      .input('Direccion', sql.VarChar, direccion) // Puedes agregar este campo si es necesario
      .input('Correo_electronico', sql.VarChar, correo)
      .input('contrasena', sql.VarChar, contrasenia)
      .execute('UsuarioActualiza');

    // Cerrar la conexión a la base de datos
    sql.close();

    res.json({ mensaje: 'Registro exitoso.' });
  } catch (error) {
    console.error('Error al realizar el registro:', error);
    res.status(500).json({ error: 'Error al realizar el registro' });
  }
});


// Puerto en el que se ejecutará el servidor
const PORT = 3000;

// Iniciar el servidor
app.listen(PORT, () => {
  console.log(`Servidor Express iniciado en http://localhost:${PORT}`);
});
