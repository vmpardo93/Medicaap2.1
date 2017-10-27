using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;
using utilitarios;
using Data;
using System.Collections;
public partial class buscacita : System.Web.UI.Page
{

    static Int32 FORMULARIO = 12;
    protected void Page_Load(object sender, EventArgs e)
    {
        LUsuarios user = new LUsuarios();
        UUsuario datos = new UUsuario();
        datos = user.ValidarSesionPaci(Session["rol_user"].ToString(), Session["user"].ToString());
        this.RegisterStartupScript("mensaje", datos.Mensaje);
        ClientScriptManager cm = this.ClientScript;
        Lnombre.Visible = false;
        Lapellido.Visible = false;
        L_paciente.Visible = false;
        LB_descripalergia.Visible = false;
        LB_diagnostico.Visible = false;
        DDL_alergias.Visible = false;
        DDL_horacirugia.Visible = false;
        DDL_medicina.Visible = false;
        TB_fecha_cirugia.Visible = false;
        DDL_horacirugia.Visible = false;
        L_paciente.Visible = false;
        L_fefinme.Visible = false;
        L_descirugia.Visible = false;
        L_alergias.Visible = false;
        L_cirugia.Visible = false;
        L_desalergias.Visible = false;
        L_diagnostico.Visible = false;
        L_dosis.Visible = false;
        L_fecirugia.Visible = false;
        L_hora.Visible = false;
        L_medicinas.Visible = false;
        LB_descripcion_cirugia.Visible = false;
        TB_cirugia.Visible = false;
        TB_dosis.Visible = false;
        TB_fechafin.Visible = false;
        B_cargar.Visible = false;
        
        Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
        Response.Cache.SetAllowResponseInBrowserHistory(false);
        Response.Cache.SetNoStore();
        int cultura = int.Parse(Session["idioma"].ToString());
        Lidioma param = new Lidioma();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_citasdoc.Columns[0].HeaderText = idioma["GV_citasdoc_Inicio"].ToString();
            GV_citasdoc.Columns[0].HeaderText = idioma["GV_citasdoc_Fin"].ToString();
            GV_citasdoc.Columns[0].HeaderText = idioma["GV_citasdoc_ApellidoPaciente"].ToString();
            GV_citasdoc.Columns[0].HeaderText = idioma["GV_citasdoc_NombrePaciente"].ToString();
            L_alergias.Text = idioma["L_alergias"].ToString();
            L_cirugia.Text = idioma["L_cirugia"].ToString();
            L_desalergias.Text = idioma["L_desalergias"].ToString();
            L_descirugia.Text = idioma["L_descirugia"].ToString();
            L_Dia.Text = idioma["L_Dia"].ToString();
            L_diagnostico.Text = idioma["L_diagnostico"].ToString();
            L_dosis.Text = idioma["L_dosis"].ToString();
            L_fecirugia.Text = idioma["L_fecirugia"].ToString();
            L_fefinme.Text = idioma["L_fefinme"].ToString();
            L_hora.Text = idioma["L_hora"].ToString();
            L_medicinas.Text = idioma["L_medicinas"].ToString();
            L_Nombre.Text = idioma["L_Nombre"].ToString();
            L_paciente.Text = idioma["L_paciente"].ToString();
            REV_Cirugia.Text = idioma["REV_Cirugia"].ToString();
            REV_DesAlergias.Text = idioma["REV_DesAlergias"].ToString();
            REV_DesCirugia.Text = idioma["REV_DesCirugia"].ToString();
            REV_Dosis.Text = idioma["REV_Dosis"].ToString();
            REV_FeCirugia.Text = idioma["REV_FeCirugia"].ToString();
            REV_FinMedicina.Text = idioma["REV_FinMedicina"].ToString();
            REV_UserName.Text = idioma["REV_UserName"].ToString();
        }
        catch (Exception ex)
        {

        }



    }
    protected void B_cargar_Click(object sender, EventArgs e)
    {
        try
            {
                DateTime hoy = DateTime.Today;
                String fecha = TB_fecha_cirugia.Text;
                String diagnostico = LB_diagnostico.Text;
                GridViewRow row = this.GV_citasdoc.SelectedRow;
                
                Lcitas doc = new Lcitas();
                Ucitas datos = new Ucitas();

                String idalergia = DDL_alergias.SelectedItem.Value;
                String idcita = Convert.ToString(GV_citasdoc.DataKeys[row.RowIndex].Values[0].ToString());
                String iddoc = Session["id_user"].ToString();
                String descripalergia = LB_descripalergia.Text;
                String fechasinhciru = TB_fecha_cirugia.Text;
                String horaciru = DDL_horacirugia.Text;
                String fechacirugia = TB_fecha_cirugia.Text + DDL_horacirugia.Text;
                String idmedicina = DDL_medicina.SelectedItem.Value;
                String idmedicna = idmedicina;
                String dosis = TB_dosis.Text;
                String fechafin = TB_fechafin.Text;
                String cirugia = TB_cirugia.Text;
                String descripcirugia = LB_descripcion_cirugia.Text;
                String fechaini = "2017-06-23";
                doc.guardarcitasdoc(idcita, Session["id_user"].ToString(), diagnostico, idalergia, descripalergia, cirugia, descripcirugia, fechasinhciru,horaciru, fechacirugia, idmedicina, dosis, fechaini, fechafin);

                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + datos.Mensaje + "');window.location=\"" + datos.Url + "\"</script>");

            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('"+ex.Message+"');</script>");//ESTE
            }
            
    }
    protected void GV_citasdocSelectedIndexChanged(object sender, EventArgs e)
    {
        Lnombre.Text = Convert.ToString(GV_citasdoc.SelectedRow.Cells[3].Text);
        Lapellido.Text = Convert.ToString(GV_citasdoc.SelectedRow.Cells[4].Text);
        Lnombre.Visible = true;
        Lapellido.Visible = true;
        L_paciente.Visible = true;
        LB_descripalergia.Visible = true;
        LB_diagnostico.Visible = true;
        DDL_alergias.Visible = true;
        DDL_horacirugia.Visible = true;
        DDL_medicina.Visible = true;
        DDL_horacirugia.Visible = true;
        L_paciente.Visible = true;
        L_fefinme.Visible = true;
        L_descirugia.Visible = true;
        L_alergias.Visible = true;
        L_cirugia.Visible = true;
        L_desalergias.Visible = true;
        L_diagnostico.Visible = true;
        L_dosis.Visible = true;
        L_fecirugia.Visible = true;
        L_hora.Visible = true;
        L_medicinas.Visible = true;
        LB_descripcion_cirugia.Visible = true;
        TB_cirugia.Visible = true;
        TB_dosis.Visible = true;
        TB_fechafin.Visible = true;
        TB_fecha_cirugia.Visible = true;
        B_cargar.Visible = true;

    }
}