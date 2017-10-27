using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using utilitarios;
using System.Collections;

public partial class vista_VerUsuariosAdmon : System.Web.UI.Page
{
    static Int32 FORMULARIO = 15;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios logica = new LUsuarios();
        UUsuario datos = logica.ValidarSesionAdmin(Session["rol_user"].ToString(), Session["user"].ToString());

        this.RegisterStartupScript("mensaje", datos.Mensaje);
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_usuariosAdmon.Columns[0].HeaderText = idioma["GV_usuariosAdmon_UserName"].ToString();
            GV_usuariosAdmon.Columns[1].HeaderText = idioma["GV_usuariosAdmon_Clave"].ToString();
            GV_usuariosAdmon.Columns[2].HeaderText = idioma["GV_usuariosAdmon_Nombre"].ToString();
            GV_usuariosAdmon.Columns[3].HeaderText = idioma["GV_usuariosAdmon_Apellido"].ToString();
            GV_usuariosAdmon.Columns[4].HeaderText = idioma["GV_usuariosAdmon_Edad"].ToString();
            GV_usuariosAdmon.Columns[5].HeaderText = idioma["GV_usuariosAdmon_Sangre"].ToString();
            GV_usuariosAdmon.Columns[6].HeaderText = idioma["GV_usuariosAdmon_Correo"].ToString();
            GV_usuariosAdmon.Columns[7].HeaderText = idioma["GV_usuariosAdmon_Documento"].ToString();
        }
        catch(Exception ex){

        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = this.GV_usuariosAdmon.SelectedRow;
        int id_usuario = int.Parse(GV_usuariosAdmon.DataKeys[row.RowIndex].Values[0].ToString());
        Session["usuarioSeleccionado"] = id_usuario;
        Response.Redirect("Reportecitas.aspx");
        
    }
}