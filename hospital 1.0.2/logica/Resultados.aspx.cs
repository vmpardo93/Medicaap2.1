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

public partial class vista_Resultados : System.Web.UI.Page
{

    static Int32 FORMULARIO = 7;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios user = new LUsuarios();
        UUsuario datos=new UUsuario();
        datos=user.ValidarSesionPaci(Session["rol_user"].ToString(), Session["user"].ToString());
        this.RegisterStartupScript("mensaje", datos.Mensaje);
        int cultura = int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            B_citas.Text = idioma["B_Citas"].ToString();
            B_medicamentos.Text = idioma["B_Medicamentos"].ToString();
            B_alergias.Text = idioma["B_Alergias"].ToString();
            B_cirugias.Text = idioma["B_Cirugias"].ToString();
        }
        catch (Exception ex)
        {

        }
        
    }
    
    protected void B_citas_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reportecitas.aspx");
    }
    protected void B_medicamentos_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteMedicamentos.aspx");
    }
    protected void B_alergias_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteAlergias.aspx");
    }
    protected void B_cirugias_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteCirugias.aspx");
    }
}