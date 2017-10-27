using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using utilitarios;
using System.Collections;


public partial class vista_CancelarCitas : System.Web.UI.Page
{

    static Int32 FORMULARIO = 5;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios user = new LUsuarios();
        UUsuario datos = new UUsuario();
        datos = user.ValidarSesionPaci(Session["rol_user"].ToString(), Session["user"].ToString());
        this.RegisterStartupScript("mensaje", datos.Mensaje);
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_CancelarCita.Columns[0].HeaderText = idioma["GV_CancelarCitas_Tipo"].ToString();
            GV_CancelarCita.Columns[1].HeaderText = idioma["GV_CancelarCitas_Inicio"].ToString();
            GV_CancelarCita.Columns[2].HeaderText = idioma["GV_CancelarCitas_Fin"].ToString();
            GV_CancelarCita.Columns[3].HeaderText = idioma["GV_CancelarCitas_Nombre"].ToString();
            GV_CancelarCita.Columns[4].HeaderText = idioma["GV_CancelarCitas_Apellido"].ToString();
        }
        catch (Exception ex)
        {

        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Lcitas doctores = new Lcitas();
        GridViewRow row = this.GV_CancelarCita.SelectedRow;
        int id_cita = int.Parse(GV_CancelarCita.DataKeys[row.RowIndex].Values[0].ToString());
        doctores.cancelarCitasUsuario(id_cita);
        Response.Redirect("CancelarCitas.aspx");
    }
}