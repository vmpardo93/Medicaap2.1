using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;
using Logica;
using System.Collections;

public partial class MasterDoctores : System.Web.UI.MasterPage
{

    static Int32 FORMULARIO = 11;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios log = new LUsuarios();
        UUsuario datos = new UUsuario();
        String rol = Session["rol_user"] as String;
        String nombre = Session["user"] as String;
        Object nomb = Session["objdata"] as Object;

        UUsuario user = (UUsuario)Session["objdata"];

        Im_Perfil.ImageUrl = user.DireccionImagen;
        Response.Cache.SetNoStore();
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            L_Citas.InnerHtml = idioma["L_Citas"].ToString();
            L_Datos.InnerHtml = idioma["L_Datos"].ToString();
            L_Horario.InnerHtml = idioma["L_Horario"].ToString();
            L_Hv.InnerHtml = idioma["L_Hv"].ToString();
            B_cerrar.Text = idioma["B_cerrar"].ToString();
        }
        catch(Exception ex){

        }
    }
    protected void B_salir_Click(object sender, EventArgs e)
    {
        Session["id_user"] = null;
        Session["user"] = null;
        Session["rol_user"] = null;
        Response.Redirect("Login.aspx");

        Response.Cache.SetNoStore();
    }
}
