using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using utilitarios;
using System.Collections;


public partial class vista_Usuario : System.Web.UI.MasterPage
{

    static Int32 FORMULARIO = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();

        UUsuario user = (UUsuario)Session["objdata"];
        
        Im_Perfil.ImageUrl = user.DireccionImagen;
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            B_salir.Text = idioma["B_salir"].ToString();
            h0.InnerHtml = idioma["h0"].ToString();
            h1.InnerHtml = idioma["h1"].ToString();
            h2.InnerHtml = idioma["h2"].ToString();
            h3.InnerHtml = idioma["h3"].ToString();
            h4.InnerHtml = idioma["h4"].ToString();
            h5.InnerHtml = idioma["h5"].ToString();
            L_Nombre.Text = idioma["h6"].ToString() +" "+ user.Nombre;

        }
        catch (Exception ex)
        {

        }
        

    }

    /*protected void B_cita_Click(object sender, EventArgs e)
    {
        Response.Redirect("Nuevacita.aspx"); 
    }
    protected void B_perfil_Click(object sender, EventArgs e)
    {
        Response.Redirect("Perfil.aspx"); 
    }*/
    protected void B_salir_Click(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        Session["id_user"] = null;
        Session["user"] = null;
        Session["rol_user"] = null;
        Response.Redirect("Login.aspx");
    }
    /* protected void B_Citas_Click(object sender, EventArgs e)
     {
         Response.Redirect("Citas.aspx"); 
     }
     protected void B_Resultados_Click(object sender, EventArgs e)
     {
         Response.Redirect("Resultados.aspx"); 
     }
     protected void B_doctores_Click(object sender, EventArgs e)
     {
         Response.Redirect("verdoctores.aspx");
     }
     protected void Button1_Click(object sender, EventArgs e)
     {
         Response.Redirect("CancelarCitas.aspx");

     }*/
}

