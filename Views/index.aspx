<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="index.aspx.cs" Inherits="Views.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Sucursales</title>
  <link rel="stylesheet" type="text/css" href="index.css" />
</head>
<body>
  <%-- Nav --%>
  <div class="navBar">
    <ul class="navBar__ul">
      <%-- ADD SUCURSALES --%>
      <li class="navBar__ul__li">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="" CssClass="navBar__link active">
                    Sucursales
        </asp:HyperLink>
      </li>
      <%-- SUCURSALES LIST --%>
      <li class="navBar__ul__li">
        <asp:HyperLink ID="linkListSuc" runat="server" NavigateUrl="~/listSucursales.aspx" CssClass="navBar__link">
                    Listado de sucursales
        </asp:HyperLink>
      </li>
      <%-- DELETE SUCUCSALES --%>
      <li class="navBar__ul__li">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="" CssClass="navBar__link">
                     Eliminar Sucursal
        </asp:HyperLink>
      </li>
    </ul>
  </div>

  <h2 class="title">Agregar sucursales</h2>


  <form id="form1" runat="server">
    <%-- SCRIPT MANAGER --%>
    <asp:ScriptManager runat="server" ID="scriptManagerAddSucursal" />
    <asp:UpdatePanel runat="server" ID="UpdatePanelAddSucursal">
      <ContentTemplate>
        <%-- Nombre Sucursal --%>
        <div>
          <span>Nombre Sucursal:</span>
          <asp:TextBox runat="server" ID="txtNameSuc" MaxLength="100"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredNameSuc" runat="server" ControlToValidate="txtNameSuc" CssClass="validaciones">Este campo es requerido</asp:RequiredFieldValidator>
        </div>
        <%-- Descripcion Sucursal--%>
        <div>
          <span>Descripción: </span>
          <asp:TextBox runat="server" ID="txtDescriptionSuc" MaxLength="100"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredDescriptionSuc" runat="server" ControlToValidate="txtDescriptionSuc" CssClass="validaciones">Este campo es requerido</asp:RequiredFieldValidator>
        </div>
        <%-- Provincias Sucursal --%>
        <div>
          <span>Provincia: 
            <asp:DropDownList runat="server" ID="ddlProvinciesSuc">
              <asp:ListItem Value="0" Enabled="True">-- Seleccionar -- </asp:ListItem>
            </asp:DropDownList>
          </span>

          <asp:RequiredFieldValidator ID="requiredProvinciesSuc" runat="server" ControlToValidate="ddlProvinciesSuc" CssClass="validaciones" InitialValue="0">Debe seleccionar una Provincia</asp:RequiredFieldValidator>
        </div>
        <%-- Direccion Sucursal --%>
        <div>
          <span>Dirección:</span>
          <asp:TextBox runat="server" ID="txtAddressSuc" MaxLength="100"></asp:TextBox>
          <asp:RequiredFieldValidator ID="requiredAddressSuc" runat="server" ControlToValidate="txtAddressSuc" CssClass="validaciones">Este campo es requerido</asp:RequiredFieldValidator>
        </div>
        <%-- Boton Enviar --%>
        <asp:Button runat="server" ID="btnSend" Text="Enviar" OnClick="BtnSend_Click" CssClass="aspNet-Button"/>  
      </ContentTemplate>     
    </asp:UpdatePanel>

    <%-- UPDATEPANEL WITH TIMER --%>
    <asp:UpdatePanel ID="UpdatePanelMsg" runat="server">
    <ContentTemplate>
      <asp:Timer ID="timer_lblShow" runat="server" Interval="3000" OnTick="Timer_lblShow_Tick" />
      <asp:Label ID="lblShow" runat="server" CssClass="lblShowMsg"/>
    </ContentTemplate>
  </asp:UpdatePanel>
  </form>
</body>
</html>

<%-- TOTO: ADD  <asp:ScriptManager> ,   <asp:UpdatePanel>  <ContentTemplate> for not reload the page--%>