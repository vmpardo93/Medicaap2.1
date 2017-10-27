using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using utilitarios;
using System.Collections;

namespace Logica
{
    public class Lidioma
    {
        public DataTable buscaidioma()
        {
            DataTable idiomas = new DataTable();
            DAOidioma parametro = new DAOidioma();
            idiomas = parametro.buscaidioma();
            return idiomas;
        }
      
        public String selecionarcultura(int idioma)
        {
            DataTable idiomas = new DataTable();
            DAOidioma parametro = new DAOidioma();
            idiomas = parametro.buscarCultura(idioma);
            String cultura = (idiomas.Rows[0]["terminacion"]).ToString();
            return cultura;


        }
        public Hashtable devolverIdioma(int id_idioma, int id_formulario)
        {
            Hashtable tabla = new Hashtable();
            DataTable data = new DataTable();
            DAOidioma param = new DAOidioma();
            Uidioma util = new Uidioma();
            data = param.buscarcomponentes(id_idioma, id_formulario);
            tabla = util.obtenerHash(data);
            return tabla;

        }
        public DataTable buscarformularios()
        {
            DataTable idiomas = new DataTable();
            DAOidioma parametro = new DAOidioma();
            idiomas = parametro.buscarformularios();
            return idiomas;


        }
        public DataTable cargarcomponentes(int id_idioma, int id_formulario)
        {

            DataTable componentes = new DataTable();
            DAOidioma parametro = new DAOidioma();
            componentes = parametro.cargarcomponenetes(id_idioma, id_formulario);
            return componentes;


        }
        public void agregaridioma(string _idioma, string _terminacion)
        {
            DataTable componentes = new DataTable();
            DAOidioma parametro = new DAOidioma();
            parametro.agregaridioma(_idioma, _terminacion);



        }
        public void agregartraduccion(int id_idioma, int id_formulario, string _componente, string _texto)
        {
            DAOidioma parametro = new DAOidioma();
            parametro.agregartraduccion(id_idioma, id_formulario, _componente, _texto);
        }

        public DataTable cargartraduccion(int id_idioma, int id_formulario, string componente)
        {

            DataTable componentes = new DataTable();
            DAOidioma parametro = new DAOidioma();
            componentes = parametro.cargartraduccion(id_idioma, id_formulario, componente);
            return componentes;


        }
        public DataTable buscaidiomas()
        {
            DataTable idiomas = new DataTable();
            DAOidioma parametro = new DAOidioma();
            idiomas = parametro.buscaidiomas();
            return idiomas;
        }
        public DataTable mostrarallcomponentes()
        {
            DataTable idiomas = new DataTable();
            DAOidioma parametro = new DAOidioma();
            idiomas = parametro.mostrarallcomponentes();
            return idiomas;
        }
    }
}
