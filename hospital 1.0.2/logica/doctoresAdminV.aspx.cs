using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;
using Logica;
using System.Collections;

public partial class vista_doctoresAdminV : System.Web.UI.Page
{

    static Int32 FORMULARIO = 16;
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
            GV_Doctores.Columns[0].HeaderText = idioma["GV_Doctores_UserName"].ToString();
            GV_Doctores.Columns[1].HeaderText = idioma["GV_Doctores_Clave"].ToString();
            GV_Doctores.Columns[2].HeaderText = idioma["GV_Doctores_Nombre"].ToString();
            GV_Doctores.Columns[3].HeaderText = idioma["GV_Doctores_Apellido"].ToString();
            GV_Doctores.Columns[4].HeaderText = idioma["GV_Doctores_Edad"].ToString();
            GV_Doctores.Columns[5].HeaderText = idioma["GV_Doctores_Estudios"].ToString();
            GV_Doctores.Columns[6].HeaderText = idioma["GV_Doctores_Especialidad"].ToString();
            GV_Doctores.Columns[7].HeaderText = idioma["GV_Doctores_Docuento"].ToString();
            GV_Doctores.Columns[8].HeaderText = idioma["GV_Doctores_Estado"].ToString();
            GV_Doctores.Columns[9].HeaderText = idioma["GV_Doctores_Correo"].ToString();
            GV_Doctores.Columns[10].HeaderText = idioma["GV_Doctores_Foto"].ToString();
        }
        catch (Exception ex)
        {

        }
    }
    
    protected void gv_modifia(object sender, GridViewUpdatedEventArgs e)
    {

    }
    protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        int index = e.RowIndex;
        GridViewRow row = (GridViewRow)GV_Doctores.Rows[index];
        FileUpload file = (FileUpload)row.FindControl("Imagen");
        Label imagen = (Label)row.FindControl("Label11");
        DropDownList drop = (DropDownList)row.FindControl("DL_Estado");
        String estado = drop.SelectedValue;
        e.NewValues.Add("estado", estado);
        
        
        if (file.HasFile)
        {
            String archivo = System.IO.Path.GetFileName(file.PostedFile.FileName);
            string extension = System.IO.Path.GetExtension(file.PostedFile.FileName);
            string savelocation = (Server.MapPath("~\\images\\Perfil") + "\\" + archivo);
            string nombreArchivo = archivo;
            e.NewValues.Add("imagen", "~\\images\\Perfil\\" + nombreArchivo);
            try
            {
                file.PostedFile.SaveAs(savelocation);
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            e.NewValues.Add("imagen", imagen.Text);
        }
    }
}