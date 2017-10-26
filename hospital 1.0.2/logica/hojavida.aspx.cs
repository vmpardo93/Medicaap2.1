using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using utilitarios;
using System.Collections;

public partial class hojavida : System.Web.UI.Page
{

    static Int32 FORMULARIO = 23;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        LUsuarios users = new LUsuarios();
        Object nomb = Session["objdata"] as Object;
        String rol = Session["rol_user"] as String;
        String user = Session["user"] as String;
        Udoctor datos = users.ValidarSesiondoc(rol, user);
        this.RegisterStartupScript("mensaje", datos.Mensaje);
        int cultura = int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            L_Bachillerato.Text = idioma["L_Bachillerato"].ToString();
            L_Experiencia.Text = idioma["L_Experiencia"].ToString();
            L_Fellows.Text = idioma["L_Fellows"].ToString();
            L_Idiomas.Text = idioma["L_Idiomas"].ToString();
            L_Otros.Text = idioma["L_Otros"].ToString();
            L_PerfilP.Text = idioma["L_PerfilP"].ToString();
            L_Universidad.Text = idioma["L_Universidad"].ToString();
            BT_enviar.Text = idioma["BT_enviar"].ToString();

        }
        catch(Exception ex){

        }

    }
    protected void BT_enviar_Click(object sender, EventArgs e)
    {
        Lhojavida hojavida = new Lhojavida();
        Uhojavida datos =new Uhojavida() ;

        hojavida.agregar_hoja_vida(TB_bachiller.Text, TB_estudios.Text, TB_fellows.Text, TB_idiomas.Text, TB_perfil.Text, TB_universidad.Text, TB_experiencia.Text, Session["id_user"].ToString());

        this.RegisterStartupScript("mensaje", datos.Mensaje);
            
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
       


    }
}