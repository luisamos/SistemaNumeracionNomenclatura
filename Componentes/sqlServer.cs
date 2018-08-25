using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace Componentes
{
    /// <summary>
    /// Descripción: Representa el acceso a la base de datos Sql Server y ofrece los métodos de acceso a misma. 
    /// Autor                   : Luis Amos
    /// Fecha de Creación       : 03 - 02- 2011
    /// Fecha de Modificación   : 11 - 04- 2012
    /// </summary>
    internal class sqlServer
    {
        #region Atributos de Conexión SQL Server
        SqlConnection conexion;
        SqlCommand comando;
        SqlParameter p;
        SqlDataAdapter adapter = new SqlDataAdapter();
        static string cadena_conexion;
        object rpta;
        int i = 0;
        #endregion

        #region Constructor y Destructor
        /// <summary>
        /// Inicia un nuevo proceso SQLServer
        /// </summary>
        /// <exception cref="sqlServerException">Si existe un error al cargar la configuración de datos.</exception>
        public sqlServer()
        {
            try
            {                
                cConexion.cargar_configuracion();
                cadena_conexion = string.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", cConexion.Servidor_Base_Datos, cConexion.BaseDatos, cConexion.User, cConexion.Password);
                if (conexion == null) conexion = new SqlConnection(cadena_conexion);                
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error al cargar la configuración del acceso a datos. ", ex);
            }
        }

        /// <summary>
        /// Destruye el Objeto Creado
        /// </summary>
        ~sqlServer()
        {
            //Desconectar();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Se conecta a la base de Datos Sql Server
        /// </summary>
        /// <exception cref="sqlServerException">Si existe un error si la conexión  SQL Server esta abierta y/o no se puede conectar al servidor.</exception>
        internal void conectar()
        {
            try
            {
                if (conexion != null && conexion.State.Equals(ConnectionState.Closed))
                {
                    conexion.Open();
                }
            }
            catch (DataException ex)
            {
                throw new sqlServerException("Error al conectarse a la base de datos SQL Server. ",ex);
            }
        }

        /// <summary>
        /// Se Desconecta de la base de Datos SQL Server
        /// </summary>
        internal void desconectar()
        {
            if (conexion.State.Equals(ConnectionState.Open))
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Crea los parámetros necesarios para ejecutar un Procedimiento Almacenado
        /// </summary>
        /// <returns>Retorna el Parametro especificado. RETURN_VALUE</returns>
        internal SqlParameter parametro()
        {
            return new SqlParameter("@RETURN_VALUE",SqlDbType.Int, 4,ParameterDirection.ReturnValue, 10, 0, null,DataRowVersion.Current, false, null, "", "", "");
        }

        /// <summary>
        /// Crea los parámetros necesarios para ejecutar un Procedimiento Almacenado
        /// </summary>
        /// <param name="nombre">Nombre de la Columna de la Tabla y/o Vista</param>
        /// <returns>Retorna el Parametro Especificado. </returns>
        internal DataColumnMapping parametro(string nombre)
        {
            return new DataColumnMapping(nombre, nombre);
        }

        /// <summary>
        /// Crea los parámetros necesarios para ejecutar un Procedimiento Almacenado
        /// </summary>
        /// <param name="nombre">Nombre del Parámetro</param>
        /// <param name="tipo">Tipo de Dato del Parámetro</param>        
        /// <param name="valor">Valor del Parámetro</param>
        /// <returns>Retorna el Parametro Especificado. RETURN_VALUE</returns>
        internal SqlParameter parametro(string nombre, SqlDbType tipo, object valor)
        {
            p = new SqlParameter();
            p.ParameterName = nombre;
            p.SqlDbType = tipo;
            p.Value = (valor == null) ? DBNull.Value : valor;
            p.IsNullable = true;
            return p;
        }

        /// <summary>
        /// Crea los parámetros necesarios para ejecutar un Procedimiento Almacenado
        /// </summary>
        /// <param name="nombre">Nombre del Parámetro</param>
        /// <param name="tipo">Tipo de Dato del Parámetro</param>
        /// <param name="tamaño">Tamaño del Parámetro</param>
        /// <param name="valor">Valor del Parámetro</param>
        /// <returns>Retorna el Parametro Especificado. RETURN_VALUE</returns>
        internal SqlParameter parametro(string nombre, SqlDbType tipo, int tamaño, object valor)
        {
            p = new SqlParameter();
            p.ParameterName = nombre;
            p.SqlDbType = tipo;
            p.Size = tamaño;
            p.Value = (valor == null) ? DBNull.Value : valor;
            p.IsNullable = true;
            return p;
        }        

        /// <summary>
        /// Crea los parámetros necesarios para ejecutar un Procedimiento Almacenado
        /// </summary>
        /// <param name="nombre">Nombre del Parámetro</param>
        /// <param name="tipo">Tipo de Dato del Parámetro</param> 
        /// <param name="columna">Nombre de la Columna</param>
        /// <param name="valor">Valor del Parámetro</param>
        /// <returns>Retorna el Parametro Especificado. RETURN_VALUE</returns>
        internal SqlParameter parametro(string nombre, SqlDbType tipo,string columna,string valor)
        {
            return new SqlParameter(nombre, tipo,0, ParameterDirection.Input, 0, 0,columna, DataRowVersion.Current, false, valor, "", "", "");
        }

        /// <summary>
        /// Crea los parámetros necesarios para ejecutar un Procedimiento Almacenado
        /// </summary>
        /// <param name="nombre">Nombre del Parámetro</param>
        /// <param name="tipo">Tipo de Dato del Parámetro</param> 
        /// <param name="tamaño">Tamaño del Parámetro</param>
        /// <param name="columna">Nombre de la Columna</param>
        /// <param name="valor">Valor del Parámetro</param>
        /// <returns>Retorna el Parametro Especificado. RETURN_VALUE</returns>
        internal SqlParameter parametro(string nombre, SqlDbType tipo,int tamaño,string columna,string valor)
        {
            return new SqlParameter(nombre,tipo, tamaño,ParameterDirection.Input, 0, 0,columna,DataRowVersion.Current, false, valor, "", "", "");
        }        

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <returns>El número de filas afectadas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal int ejecutar(string nombre)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 1000;
                conectar();
                i = comando.ExecuteNonQuery();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            return i;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="tiempo">Establece el tiempo de espera antes de terminar el intento de ejecutar el Procedimiento Almacenado</param>
        /// <returns>El número de filas afectadas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal int ejecutar(string nombre, int tiempo)
        {
            try
            {
                conectar();
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = tiempo;
                i = comando.ExecuteNonQuery();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            finally
            {

            }
            return i;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        /// <returns>El número de filas afectadas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal int ejecutar(string nombre, params SqlParameter[] parametros)
        {
            try
            {
                conectar();
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 1000;
                comando.Parameters.AddRange(parametros);
                i = comando.ExecuteNonQuery();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            return i;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="tiempo">Establece el tiempo de espera antes de terminar el intento de ejecutar el Procedimiento Almacenado</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        /// <returns>El número de filas afectadas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal int ejecutar(string nombre, int tiempo, params SqlParameter[] parametros)
        {
            try
            {
                conectar();
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = tiempo;
                comando.Parameters.AddRange(parametros);
                i = comando.ExecuteNonQuery();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            return i;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal object ejecutar_sp(string nombre)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 1000;
                conectar();
                rpta = comando.ExecuteScalar();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="tiempo">Establece el tiempo de espera antes de terminar el intento de ejecutar el Procedimiento Almacenado</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal object ejecutar_sp(string nombre, int tiempo)
        {
            try
            {
                conectar();
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = tiempo;
                rpta = comando.ExecuteScalar();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            finally
            {

            }
            return rpta;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal object ejecutar_sp(string nombre, params SqlParameter[] parametros)
        {
            try
            {
                conectar();
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 1000;
                comando.Parameters.AddRange(parametros);
                rpta = comando.ExecuteScalar();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="tiempo">Establece el tiempo de espera antes de terminar el intento de ejecutar el Procedimiento Almacenado</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal object ejecutar_sp(string nombre, int tiempo, params SqlParameter[] parametros)
        {
            try
            {
                conectar();
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = tiempo;
                comando.Parameters.AddRange(parametros);
                rpta = comando.ExecuteScalar();
                desconectar();
            }
            catch (Exception ex)
            {
                rpta = null;
                throw new sqlServerException(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada y Desconectada - Modo Híbrido
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenados</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="nombre_tabla">Nombre de la Tabla</param>
        /// <returns>Devuelve un Conjunto de Datos representados en Filas y Columnas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción cuando tabla de origen no es válida.</exception>
        internal FICHA_ds ejecutar_ds(string nombre, FICHA_ds tabla, string nombre_tabla)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 1000;
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla.Tables[nombre_tabla]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException(ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada y Desconectada Modo Híbrido
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenados</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="nombre_tabla">Nombre de la Tabla</param>
        /// <param name="tiempo">Establece el tiempo de espera antes de terminar el intento de ejecutar el Procedimiento Almacenado</param>
        /// <returns>Devuelve un Conjunto de Datos representados en Filas y Columnas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción cuando tabla de origen no es válida.</exception>
        internal FICHA_ds ejecutar_ds(string nombre, FICHA_ds tabla, string nombre_tabla, int tiempo)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = tiempo;
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla.Tables[nombre_tabla]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException(ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada y Desconectada Modo Híbrido
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenados</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="nombre_tabla">Nombre de la Tabla</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        /// <returns>Devuelve un Conjunto de Datos representados en Filas y Columnas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción cuando tabla de origen no es válida.</exception>
        internal FICHA_ds ejecutar_ds(string nombre, FICHA_ds tabla, string nombre_tabla, params SqlParameter[] parametros)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 1000;
                comando.Parameters.AddRange(parametros);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla.Tables[nombre_tabla]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException(ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta el Procedimiento Almacenado con tecnología Conectada y Desconectada - Modo Híbrido
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenados</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="nombre_tabla">Nombre de la Tabla</param>
        /// <param name="tiempo">Establece el tiempo de espera antes de terminar el intento de ejecutar el Procedimiento Almacenado</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        /// <returns>Devuelve un Conjunto de Datos representados en Filas y Columnas. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción cuando tabla de origen no es válida.</exception>
        internal FICHA_ds ejecutar_ds(string nombre, FICHA_ds tabla, string nombre_tabla, int tiempo, params SqlParameter[] parametros)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = tiempo;
                comando.Parameters.AddRange(parametros);
                adapter = new SqlDataAdapter(comando);
                adapter.Fill(tabla.Tables[nombre_tabla]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException(ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta una vista con tecnología Desconectada
        /// </summary>
        /// <param name="nombre">Nombre Vista</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal FICHA_ds ejecutar_vs(string nombre, FICHA_ds tabla)
        {
            try
            {
                adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0}", nombre), conexion);
                adapter.Fill(tabla.Tables[nombre]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error - Ejecutar Vista. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta una vista con tecnología Desconectada
        /// </summary>
        /// <param name="nombre">Nombre Vista</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="columna">Nombre de la Columna</param>
        /// <param name="ascendente">Si el listado es Ascendente</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal FICHA_ds ejecutar_vs(string nombre, FICHA_ds tabla, string columna, bool ascendente)
        {
            try
            {
                adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0} ORDER BY [{1}] {2}", nombre, columna, (ascendente) ? "ASC" : "DESC"), conexion);
                adapter.Fill(tabla.Tables[nombre]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error - Ejecutar Vista. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta una vista con tecnología Desconectada
        /// </summary>
        /// <param name="nombre">Nombre Vista</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="nombre_parametro">Nombre del Parametro</param>
        /// <param name="valor">El valor requerido</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal FICHA_ds ejecutar_vs(string nombre, FICHA_ds tabla, string nombre_parametro, string valor)
        {
            try
            {
                adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0} WHERE {1}='{2}'", nombre, nombre_parametro, valor), conexion);
                adapter.Fill(tabla.Tables[nombre]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error - Ejecutar Vista. ", ex);
            }
            return tabla;
        }

        /// <summary>
        /// Ejecuta una vista con tecnología Desconectada
        /// </summary>
        /// <param name="nombre">Nombre Vista</param>
        /// <param name="tabla">Tabla dataset</param>
        /// <param name="nombre_parametro">Nombre del Parametro</param>
        /// <param name="valor">El valor requerido</param>
        /// <param name="columna">Nombre de la Columna</param>
        /// <param name="ascendente">Si el listado es Ascendente</param>
        /// <returns>La primera columna de la primera fila del Procedimiento Almacenado. RETURN_VALUE</returns>
        /// <exception cref="sqlServerException">Se produjo una excepción al ejecutar el comando en una fila bloqueada</exception>
        internal FICHA_ds ejecutar_vs(string nombre, FICHA_ds tabla, string columna, bool ascendente, string nombre_parametro, string valor)
        {
            try
            {
                adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0} WHERE {1}='{2}' ORDER BY [{3}] {4} ", nombre, nombre_parametro, valor, columna, (ascendente) ? "ASC" : "DESC"), conexion);
                adapter.Fill(tabla.Tables[nombre]);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error - Ejecutar Vista. ", ex);
            }
            return tabla;
        }       

        /// <summary>
        /// Agrega un Table Mapping a Sql Data Adapter
        /// </summary>
        /// <param name="nombre_vista">Nombre de la Vista</param>
        /// <param name="nombre_columnas">Nombres de las Columnas</param>        
        internal void agregar_table_mapping(string nombre_vista, params DataColumnMapping[] nombre_columnas)
        {
            try
            {
                DataTableMapping tableMapping = new DataTableMapping();
                tableMapping.SourceTable = "Table";
                tableMapping.DataSetTable = nombre_vista;
                tableMapping.ColumnMappings.AddRange(nombre_columnas);
                adapter.TableMappings.Add(tableMapping);
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error - Agregar Table mapping Vista. ", ex);
            }
        }

        /// <summary>
        /// Agrega un procedimiento Almacenado al Sql Command
        /// </summary>
        /// <param name="nombre">Nombre del Procedimiento Almacenado</param>
        /// <param name="tipo">Tipo de Procedimiento Almacenado (G: Guardar, M: Modificar, E: Eliminar)</param>
        /// <param name="parametros">Los parámetros que necesita el Procedimiento Almacenado</param>
        internal void agregar_sp(string nombre, char tipo, params SqlParameter[] parametros)
        {
            try
            {
                comando = new SqlCommand(nombre, conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddRange(parametros);
                switch (tipo)
                {
                    case 'G':
                        adapter.InsertCommand = comando;
                        break;
                    case 'M':
                        adapter.UpdateCommand = comando;
                        break;
                    case 'E':
                        adapter.DeleteCommand = comando;
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new sqlServerException("Error - Agregar Procedimiento Almacenado. ", ex);
            }
        }

        /// <summary>
        /// Actualiza Un conjunto de datos
        /// </summary>
        /// <param name="tabla">DataSet</param>
        /// <param name="nombre_tabla">Nombre de la tabla.</param>
        /// <returns>Retorna el número de filas Afectadas.</returns>
        internal int actualizar(FICHA_ds tabla,string nombre_tabla)
        {            
            return (adapter != null) ? adapter.Update(tabla, nombre_tabla) : -1; 
        }
        #endregion
    }
}