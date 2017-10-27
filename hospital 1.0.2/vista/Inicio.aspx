<%@ Page Title="" Language="C#" MasterPageFile="~/vista/MasterPage.master" AutoEventWireup="true" CodeFile="~/logica/Inicio.aspx.cs" Inherits="vista_InicioP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <asp:DropDownList ID="DD_Idioma" runat="server" DataSourceID="ObjectDataSource1" DataTextField="nombre" DataValueField="id_idioma" OnSelectedIndexChanged="DD_Idioma_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="1">Español</asp:ListItem>
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="buscaidiomas" TypeName="Logica.Lidioma" ></asp:ObjectDataSource>
        <br />
        <div class="col-md-12">
            <div id="carousel-1" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#caurusel-1" data-slide-to="0" class="active"></li>
                    <li data-target="#caurusel-1" data-slide-to="1"></li>
                    <li data-target="#caurusel-1" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="..\images\medicos.jpg" class="img-responsive" alt="" height="500" width="500" />
                        <div class="carousel-caption">
                            <h3 id="L_BMedicos" runat="server">Medicos las 24 horas</h3>
                            <p id="L_Bleyenda"  runat="server">Nuestros medicos estan disponibles las 24 horas ademas de ser los mejores especialistas</p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="..\images\HospitalB.jpg" class="img-responsive" alt="" height="500" width="500"/>
                        <div class="carousel-caption">
                            <h3>Instalaciones</h3>
                            <p>El hospital esta equipado con lo mejor en instalciones como en tecnologia </p>
                        </div>
                    </div>
                    <div class="item">
                        <img src="..\images\ambulancia.jpg" class="img-responsive" alt="" height="500" width="500"/>
                        <div class="carousel-caption">
                            <h3>Ambulancias</h3>
                            <p> Ambulancias siempre lista para la atencion</p>
                        </div>
                    </div>
                </div>
                <a href="#caurusel-1" class="left carousel-control" role="button" data-slide-to="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Anterior</span>
                </a>
                <a href="#caurusel-1" class="right carousel-control" role="button" data-slide-to="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Siguiente</span>
                </a>
            </div>

        </div>

    </div>
    
</asp:Content>

