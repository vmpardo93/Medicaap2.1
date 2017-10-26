using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using utilitarios;
using Logica;
using System.Collections;

public partial class modificadoc : System.Web.UI.Page
{

    static Int32 FORMULARIO = 13;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios logica = new LUsuarios();
        Udoctor datos = logica.ValidarSesiondoc(Session["rol_user"].ToString(), Session["user"].ToString());
        this.RegisterStartupScript("mensaje", datos.Mensaje);

        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
        int cultura = int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_EditarDoc.Columns[0].HeaderText = idioma["GV_EditarDoc_UserName"].ToString();
            GV_EditarDoc.Columns[1].HeaderText = idioma["GV_EditarDoc_Clave"].ToString();
            GV_EditarDoc.Columns[2].HeaderText = idioma["GV_EditarDoc_Nombre"].ToString();
            GV_EditarDoc.Columns[3].HeaderText = idioma["GV_EditarDoc_Apellido"].ToString();
            GV_EditarDoc.Columns[4].HeaderText = idioma["GV_EditarDoc_Edad"].ToString();
            GV_EditarDoc.Columns[5].HeaderText = idioma["GV_EditarDoc_Estudios"].ToString();
            GV_EditarDoc.Columns[6].HeaderText = idioma["GV_EditarDoc_Especialidad"].ToString();
            GV_EditarDoc.Columns[7].HeaderText = idioma["GV_EditarDoc_Documento"].ToString();
            GV_EditarDoc.Columns[8].HeaderText = idioma["GV_EditarDoc_Correo"].ToString();
            GV_EditarDoc.Columns[9].HeaderText = idioma["GV_EditarDoc_Foto"].ToString();
        }
        catch(Exception ex){

        }
        
    }
    protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
    {
        int index = e.RowIndex;
        Udoctor datos = new Udoctor();
        GridViewRow row = (GridViewRow)GV_EditarDoc.Rows[index];
        FileUpload file = (FileUpload)row.FindControl("Imagen");
        Label imagen = (Label)row.FindControl("Label1");
        LDoctor doc = new LDoctor();
        /* modificado(file, imagen);
         e.NewValues.Add("imagen", datos.Foto);*/
        string aux;

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