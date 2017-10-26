using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Logica;
using utilitarios;
using System.Collections;

public partial class vista_Login : System.Web.UI.Page
{

    static Int32 FORMULARIO = 1;
    protected void Page_Load(object sender, EventArgs e)
    {

        
        Session["id_user"] = null;
        Session["id_user"] = null;
        Session["user"] = null;
        Session["rol_user"] = null;

        Response.Cache.SetNoStore();
        int cultura=int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            LB_UserName.InnerHtml = idioma["LB_UserName"].ToString();
            REV_UserName.Text = idioma["REV_UserName"].ToString();
            LB_Clave.InnerHtml = idioma["LB_Clave"].ToString();
            REV_Clave.Text = idioma["REV_Clave"].ToString();
            B_Entrar.Text = idioma["B_Entrar"].ToString();
            B_Registro.Text = idioma["B_Registro"].ToString();
        }
        catch(Exception ex){

        }
        
        
    }



    protected void B_Entrar_Click(object sender, EventArgs e)
    {
      
        UUsuario user = new UUsuario();
        LUsuarios log = new LUsuarios();
        user = log.loggin(TB_username.Text, TB_Clave.Text);

        Session["id_user"] = user.Id_usuario;
        Session["user"] = user.Username;
        Session["rol_user"] = (user.Idrol.ToString());
        Session["objdata"] = user;

        this.RegisterStartupScript("mensaje",user.Mensaje);

    }

    protected void B_Registro_Click(object sender, EventArgs e)
    {
        TB_Clave.Text = "";
        TB_username.Text = "";
        Response.Redirect("registro.aspx");
    }



    protected void IB_HomeLogin_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Inicio.aspx");
    }
}
