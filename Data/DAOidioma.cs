using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DAOidioma
    {
        public DataTable buscaidioma()
        {
         DataTable parametri = new DataTable();
            NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.buscaridioma", conection);
                dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                conection.Open();
                dataAdapter.Fill(parametri);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (conection != null)
                {
                    conection.Close();
                }
            }
            return parametri;

        }
         public DataTable buscarCultura(int cultura)
         {
             DataTable parametri = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.buscarCultura", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = cultura;
                 conection.Open();
                 dataAdapter.Fill(parametri);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return parametri;

         }
         public DataTable buscarcomponentes(int id_idioma, int id_formulario)
         {
             DataTable componentes = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.obtenercomponentes", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = id_idioma;
                 dataAdapter.SelectCommand.Parameters.Add("_id_formulario", NpgsqlDbType.Integer).Value = id_formulario;
                 conection.Open();
                 dataAdapter.Fill(componentes);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return componentes;

         }
         public DataTable buscarformularios()
         {
             DataTable formularios = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.buscarformularios", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 conection.Open();
                 dataAdapter.Fill(formularios);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return formularios;

         }
         public DataTable cargarcomponenetes(int id_idioma, int id_formulario)
         {
             DataTable componentes = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {

                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.cargarcomponentes", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = id_idioma;
                 dataAdapter.SelectCommand.Parameters.Add("_id_formulario", NpgsqlDbType.Integer).Value = id_formulario;
                 conection.Open();
                 dataAdapter.Fill(componentes);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return componentes;

         }
         public void agregaridioma(string _idioma, string _terminacion)
         {
             DataTable componentes = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.cargarcomponentes", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 dataAdapter.SelectCommand.Parameters.Add("_idioma", NpgsqlDbType.Text).Value = _idioma;
                 dataAdapter.SelectCommand.Parameters.Add("_terminacion", NpgsqlDbType.Text).Value = _terminacion;
                 conection.Open();
                 dataAdapter.Fill(componentes);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }

         }
         public void agregartraduccion(int id_idioma, int id_formulario,string _componente,string _texto)
         {
             DataTable componentes = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.agregartraduccion", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = id_idioma;
                 dataAdapter.SelectCommand.Parameters.Add("_idi_formulario", NpgsqlDbType.Integer).Value = id_formulario;
                 dataAdapter.SelectCommand.Parameters.Add("_componente", NpgsqlDbType.Text).Value = _componente;
                 dataAdapter.SelectCommand.Parameters.Add("_texto", NpgsqlDbType.Text).Value = _texto;
                 conection.Open();
                 dataAdapter.Fill(componentes);
             }
             catch (Exception Ex)
             {
                 //throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }

         }
         public DataTable cargartraduccion(int id_idioma, int id_formulario, string componente)
         {
             DataTable componentes = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {

                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.cargartraduccion", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 dataAdapter.SelectCommand.Parameters.Add("_id_idioma", NpgsqlDbType.Integer).Value = id_idioma;
                 dataAdapter.SelectCommand.Parameters.Add("_id_formulario", NpgsqlDbType.Integer).Value = id_formulario;
                 dataAdapter.SelectCommand.Parameters.Add("_id_formulario", NpgsqlDbType.Text).Value = componente;
                 conection.Open();
                 dataAdapter.Fill(componentes);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return componentes;

         }
         public DataTable buscaidiomas()
         {
             DataTable parametri = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.buscaridiomas", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 conection.Open();
                 dataAdapter.Fill(parametri);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return parametri;

         }
         public DataTable mostrarallcomponentes()
         {
             DataTable parametri = new DataTable();
             NpgsqlConnection conection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString);
             try
             {
                 NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("idioma.f_mostrarallcomponentes", conection);
                 dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                 conection.Open();
                 dataAdapter.Fill(parametri);
             }
             catch (Exception Ex)
             {
                 throw Ex;
             }
             finally
             {
                 if (conection != null)
                 {
                     conection.Close();
                 }
             }
             return parametri;

         }
    }
}
