using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace Componentes
{
    /// <summary>
    /// Clase: Usuario
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 01 - 02 - 2011
    /// Fecha de Modificación   : 21 - 02 - 2012
    /// </summary>
    public class cUsuario : cConexion
    {
        #region Atributos y Propiedades
        string login;
        /// <summary>
        /// Usuario 
        /// </summary>
        public string Login
        {
            get { return login; }
            set { login = value; }
        }        
        string apellidos_nombres;

        /// <summary>
        /// Apellidos y Nombres
        /// </summary>
        public string Apellidos_nombres
        {
            get { return apellidos_nombres; }
            set { apellidos_nombres = value; }
        }
        string direccion;

        /// <summary>
        /// Dirección
        /// </summary>
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        string celular;

        /// <summary>
        /// Celular
        /// </summary>
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        string correo_electronico;

        /// <summary>
        /// Correo Electrónico
        /// </summary>
        public string Correo_Electronico
        {
            get { return correo_electronico; }
            set { correo_electronico = value; }
        }
        string contraseña;

        /// <summary>
        /// Contraseña
        /// </summary>
        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }
        bool habilitado;

        /// <summary>
        /// Habilitado
        /// </summary>
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }
        bool administrador;

        /// <summary>
        /// Administrador
        /// </summary>
        public bool Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }       
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica si Existe el Usuario y Contraseña
        /// </summary>
        /// <param name="usuario">El usuario</param>
        /// <param name="contraseña">Su Clave</param>
        /// <returns>Retorna si existe el usuario o caso contrario no existe.</returns>
        public string autenticar(string usuario, string contraseña)
        {
            string rpta = "";
            try
            {
                rpta = server.ejecutar_sp("AUTENTICACION",
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, usuario),
                    server.parametro("@CONTRASEÑA", SqlDbType.VarChar, 300, contraseña)).ToString();
            }
            catch (Exception ex)
            {
               throw new sqlServerException("Error Autenticación, Usuario. ", ex);
            }
            return rpta;
        }

        /// <summary>
        /// Lista todos los registros
        /// </summary>
        /// <returns>Un conjunto de datos</returns>
        public FICHA_ds listar()
        {
            try
            {
                tabla = server.ejecutar_vs("VS_LISTAR_USUARIO", tabla);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error Listar, Usuario. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Busca un registro especificado
        /// </summary>
        /// <param name="pUsuario">El código del elemento a buscar</param>
        /// <returns>Si existe en la tabla</returns>
        public List<FICHA_ds.VS_LISTAR_USUARIORow> buscar(string pUsuario)
        {
            if (tabla.VS_LISTAR_USUARIO.Rows.Count == 0) listar();
            EnumerableRowCollection<FICHA_ds.VS_LISTAR_USUARIORow> query = from c in tabla.VS_LISTAR_USUARIO.AsEnumerable()
                                                                                          where c.USUARIO == pUsuario
                                                                                          select c;

            return query.ToList();
        }

        /// <summary>
        /// Guardar un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int guardar()
        {
            try
            {
                i = server.ejecutar("GUARDAR_USUARIO",
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Login),
                    server.parametro("@APELLIDOS_NOMBRES", SqlDbType.VarChar, 300, Apellidos_nombres),
                    server.parametro("@DIRECCION", SqlDbType.VarChar, 100, Direccion),
                    server.parametro("@CELULAR", SqlDbType.VarChar, 30, Celular),
                    server.parametro("@CORREO_ELECTRONICO", SqlDbType.VarChar, 50, Correo_Electronico),
                    server.parametro("@CONTRASEÑA", SqlDbType.VarChar, 10, Contraseña),
                    server.parametro("@HABILITADO", SqlDbType.Bit, Habilitado),
                    server.parametro("@ADMINISTRADOR", SqlDbType.Bit, Administrador),
                    server.parametro("@USUARIO_ADMINISTRADOR", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Guardar, Usuario. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Modifica un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int modificar()
        {
            try
            {
                i = server.ejecutar("MODIFICAR_USUARIO",
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Login),
                    server.parametro("@APELLIDOS_NOMBRES", SqlDbType.VarChar, 300, Apellidos_nombres),
                    server.parametro("@DIRECCION", SqlDbType.VarChar, 100, Direccion),
                    server.parametro("@CELULAR", SqlDbType.VarChar, 30, Celular),
                    server.parametro("@CORREO_ELECTRONICO", SqlDbType.VarChar, 50, Correo_Electronico),
                    server.parametro("@CONTRASEÑA", SqlDbType.VarChar, 10, Contraseña),
                    server.parametro("@HABILITADO", SqlDbType.Bit, Habilitado),
                    server.parametro("@ADMINISTRADOR", SqlDbType.Bit, Administrador),
                    server.parametro("@USUARIO_ADMINISTRADOR", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Modificar, Usuario. ", ex);
            }
            return i;
        }

        /// <summary>
        /// Elimina un Registro
        /// </summary>
        /// <returns>El número de filas Afectadas</returns>
        public int eliminar()
        {
            try
            {
                i = server.ejecutar("ELIMINAR_USUARIO",
                    server.parametro("@USUARIO", SqlDbType.VarChar, 10, Login),
                    server.parametro("@USUARIO_ADMINISTRADOR", SqlDbType.VarChar, 10, Usuario));
            }
            catch (Exception ex)
            {
                i = -1;
                throw new sqlServerException("Error Eliminar, Usuario. ", ex);
            }
            return i;
        }
        #endregion
    }
}
