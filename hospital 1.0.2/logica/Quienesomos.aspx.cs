using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Logica;

public partial class vista_Quienesomos : System.Web.UI.Page
{
    static Int32 FORMULARIO = 21;
    protected void Page_Load(object sender, EventArgs e)
    {
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            T_QuieneSomos.InnerHtml = idioma["T_QuieneSomos"].ToString();
            L_QSContenido.InnerHtml = idioma["L_QSContenido"].ToString();
            L_CHistoria.InnerHtml = idioma["L_CHistoria"].ToString();
            L_Historia.InnerHtml = idioma["L_Historia"].ToString();
        }
        catch(Exception ex){

        }
        
    }
}