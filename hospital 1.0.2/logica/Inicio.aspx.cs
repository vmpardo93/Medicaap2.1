using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using System.Globalization;
using System.Threading;
using System.Collections;

public partial class vista_InicioP : System.Web.UI.Page
{
    static Int32 FORMULARIO = 19;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["idioma"] = null;
        Session["idioma"] = int.Parse(DD_Idioma.SelectedValue); 
    }
    protected void DD_Idioma_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cultura = int.Parse(DD_Idioma.SelectedValue);
        Lparametriza param = new Lparametriza();
        String terminacion=param.selecionarcultura(cultura);
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(terminacion);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(terminacion);
        Session["idioma"] = cultura;
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            L_BMedicos.InnerHtml = idioma["L_BMedicos"].ToString();
            L_Bleyenda.InnerHtml = idioma["L_BLeyenda"].ToString();
        }
        catch(Exception ex){

        }
        //Response.Redirect("Inicio.aspx");
        
    }
}