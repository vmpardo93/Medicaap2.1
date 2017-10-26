using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using utilitarios;
using System.Collections;

public partial class vista_Citas : System.Web.UI.Page
{

    static Int32 FORMULARIO = 4;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios user = new LUsuarios();
        UUsuario datos = new UUsuario();
        datos = user.ValidarSesionPaci(Session["rol_user"].ToString(), Session["user"].ToString());
        this.RegisterStartupScript("mensaje", datos.Mensaje);
        int cultura = int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_Citas.Columns[0].HeaderText = idioma["GV_Citas_Tipo"].ToString();
            GV_Citas.Columns[1].HeaderText = idioma["GV_Citas_Inicio"].ToString();
            GV_Citas.Columns[2].HeaderText = idioma["GV_Citas_Fin"].ToString();
            GV_Citas.Columns[3].HeaderText = idioma["GV_Citas_Diagnostico"].ToString();
            GV_Citas.Columns[4].HeaderText = idioma["GV_Citas_Nombre_Doctor"].ToString();
            GV_Citas.Columns[5].HeaderText = idioma["GV_Citas_Apellido_Doctor"].ToString();
        }
        catch (Exception ex)
        {

        }
    }
}