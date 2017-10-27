using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;
using Logica;
using System.Collections;

public partial class vista_MasterAdminVic : System.Web.UI.MasterPage
{
    static Int32 FORMULARIO = 14;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        
        String rol = Session["rol_user"] as String;
        String nombre = Session["user"] as String;
        Object nomb = Session["objdata"] as Object;
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            L_menu.InnerHtml = idioma["L_Menu"].ToString();
            B_Parametros.Text = idioma["B_Parametros"].ToString();
            B_RegistrarDoctores.Text = idioma["B_RegistrarDoctores"].ToString();
            B_Salir.Text = idioma["B_Salir"].ToString();
            B_VDoctores.Text = idioma["B_VDoctores"].ToString();
            B_VUsuario.Text = idioma["B_VUsuarios"].ToString();
        }
        catch(Exception ex){

        }
    }

    protected void B_Salir_Click(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Session["id_user"] = null;
        Session["user"] = null;
        Session["rol_user"] = null;
        Session["usuarioSeleccionado"] = null;
        Response.Redirect("Login.aspx");
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("VerUsuariosAdmon.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("doctoresAdminV.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistroDocAdmon.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("AgregarAdmon.aspx");
    }
    protected void IB_Idioma_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("idioma.aspx");
    }
}