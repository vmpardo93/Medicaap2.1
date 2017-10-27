using Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    static Int32 FORMULARIO = 18;
    protected void Page_Load(object sender, EventArgs e)
    {
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            L_Mapa.InnerHtml = idioma["L_Mapa"].ToString();
            L_QuienesSomos.InnerHtml = idioma["L_QuienesSomos"].ToString();
            L_Doctores.InnerHtml = idioma["L_Doctores"].ToString();
            L_Inicio.InnerHtml = idioma["L_Inicio"].ToString();
            L_Login.InnerHtml = idioma["L_Login"].ToString();
            

        }
        catch(Exception ex){

        }

    }
}
