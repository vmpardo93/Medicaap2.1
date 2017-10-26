using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;
using Logica;
using System.Collections;

public partial class editarhojavida : System.Web.UI.Page
{

    static Int32 FORMULARIO = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        try
        {
            Uhojavida datos = new Uhojavida();
            Lhojavida logic = new Lhojavida();
            String valida =Convert.ToString(GV_hojavida.Rows.Count);
            LUsuarios users = new LUsuarios();
            Object nomb = Session["objdata"] as Object;
            String rol = Session["rol_user"] as String;
            String user = Session["user"] as String;
            string val =logic.validargrid(valida,rol);
            Response.Redirect(val);
            
        }
        catch (Exception ex)
        {
 
        }
        int cultura = int.Parse(Session["idioma"].ToString());
        Lparametriza param = new Lparametriza();
        Hashtable idioma = param.devolverIdioma(cultura, FORMULARIO);
        try
        {
            GV_hojavida.Columns[0].HeaderText = idioma["GV_hojavida_Perfil"].ToString();
            GV_hojavida.Columns[1].HeaderText = idioma["GV_hojavida_Bachiller"].ToString();
            GV_hojavida.Columns[2].HeaderText = idioma["GV_hojavida_Universidad"].ToString();
            GV_hojavida.Columns[3].HeaderText = idioma["GV_hojavida_Otrosestudios"].ToString();
            GV_hojavida.Columns[4].HeaderText = idioma["GV_hojavida_Fellows"].ToString();
            GV_hojavida.Columns[5].HeaderText = idioma["GV_hojavida_Idiomas"].ToString();
            GV_hojavida.Columns[6].HeaderText = idioma["GV_hojavida_Experiencia"].ToString();
        }
        catch (Exception ex)
        {

        }
        }
}