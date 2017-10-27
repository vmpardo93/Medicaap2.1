using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Data;

public partial class vista_Idioma : System.Web.UI.Page
{
    static Int32 ID_FORMULARIO;
    static Int32 ID_IDIOMA;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Lidioma parametro = new Lidioma();   
        String idioma = TB_Idioma.Text;
        String terminacion = TB_Terminacion.Text;
        parametro.agregaridioma(idioma, terminacion);

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        int id_idioma =int.Parse(DDL_Idioma.SelectedValue.ToString()) ;
        int id_formulario = int.Parse(DDL_Formularios.SelectedValue.ToString());
        string componentes = DDL_Componentes.SelectedItem.ToString();
        string traduccion = TB_Ncomponentes.Text;
        Lidioma parametro = new Lidioma();
        parametro.agregartraduccion(id_idioma, id_formulario, componentes, traduccion);

    }

    protected void DDL_Componentes_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int id_idioma = int.Parse(DDL_Idioma.SelectedValue.ToString());
        int id_formulario = int.Parse(DDL_Formularios.SelectedValue.ToString());
        string componente = DDL_Componentes.SelectedItem.ToString();
        Lidioma parametro = new Lidioma();
        DataTable texto = parametro.cargartraduccion(id_idioma,id_formulario,componente);
        String traduccion="";
        try
        {
            traduccion = texto.Rows[0]["texto"].ToString();
        }
        catch(Exception ex){

        }
       
        if(traduccion==""){
            TB_Ncomponentes.Text = "no hay traduccion";

        }
        else
        {
            TB_Ncomponentes.Text = traduccion;
        }
    }
}