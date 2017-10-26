using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;
using Logica;
using System.Collections;

public partial class vista_Perfil : System.Web.UI.Page
{
    static Int32 FORMULARIO = 3;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios user = new LUsuarios();
        UUsuario datos = new UUsuario();
        datos = user.ValidarSesionPaci(Session["rol_user"].ToString(), Session["user"].ToString());
        this.RegisterStartupScript("mensaje", datos.Mensaje);
        int cultura = int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_Perfil.Columns[0].HeaderText = idioma["GV_Perfil_Nombre"].ToString();
            GV_Perfil.Columns[1].HeaderText = idioma["GV_Perfil_Apellido"].ToString();
            GV_Perfil.Columns[2].HeaderText = idioma["GV_Perfil_Clave"].ToString();
            GV_Perfil.Columns[3].HeaderText = idioma["GV_Perfil_Edad"].ToString();
        }
        catch(Exception ex){

        }
    }
}