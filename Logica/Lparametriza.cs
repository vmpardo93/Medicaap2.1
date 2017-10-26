using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilitarios;
using Data;
using System.Collections;

namespace Logica
{
    public class Lparametriza
    {
        public Uparametrizacion parametrizacitas(String duracion, String horainicio, String horafin) 
        {
            Uparametrizacion datos = new Uparametrizacion();
            datos.Inicio = horainicio;
            datos.Fin = horafin;
            datos.Duracion = duracion;
            return datos;
        }
        public DataTable buscaidioma()
        {
            DataTable idiomas = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            idiomas = parametro.buscaidioma();
            return idiomas;
        }
        public String selecionarcultura(int idioma)
        {
            DataTable idiomas = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            idiomas = parametro.buscarCultura(idioma);
            String cultura = (idiomas.Rows[0]["terminacion"]).ToString();
            return cultura;


        }
        public Hashtable devolverIdioma(int id_idioma, int id_formulario)
        {
            Hashtable tabla = new Hashtable();
            DataTable data = new DataTable();
            DAOparametriza param= new DAOparametriza();
            Uidioma util = new Uidioma();
            data = param.buscarcomponentes(id_idioma, id_formulario);
            tabla=util.obtenerHash(data);
            return tabla;

        }
        public DataTable buscarformularios()
        {
            DataTable idiomas = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            idiomas = parametro.buscarformularios();
            return idiomas;


        }
        public DataTable cargarcomponentes(int id_idioma, int id_formulario)
        {
            
            DataTable componentes = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            componentes = parametro.cargarcomponenetes(id_idioma, id_formulario);
            return componentes;


        }
        public void agregaridioma(string _idioma, string _terminacion)
        {
            DataTable componentes = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            parametro.agregaridioma(_idioma, _terminacion);
           


        }
        public void agregartraduccion(int id_idioma, int id_formulario, string _componente, string _texto)
        {
            DAOparametriza parametro = new DAOparametriza();
            parametro.agregartraduccion(id_idioma, id_formulario,  _componente, _texto);
        }

        public DataTable cargartraduccion(int id_idioma, int id_formulario, string componente)
        {

            DataTable componentes = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            componentes = parametro.cargartraduccion(id_idioma, id_formulario, componente);
            return componentes;


        }
        public DataTable buscaidiomas()
        {
            DataTable idiomas = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            idiomas = parametro.buscaidiomas();
            return idiomas;
        }
        public DataTable mostrarallcomponentes()
        {
            DataTable idiomas = new DataTable();
            DAOparametriza parametro = new DAOparametriza();
            idiomas = parametro.mostrarallcomponentes();
            return idiomas;
        }

    }
}
