﻿<%@ Page
  Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="DeleteSucursal.aspx.cs" Inherits="Views.DeleteSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Sucursales</title>
  <link rel="stylesheet" type="text/css" href="deleteSucursal.css" />
</head>
<body>
  <%-- Nav --%>
  <div class="navBar">
    <ul class="navBar__ul">
      <%-- ADD SUCURSALES --%>
      <li class="navBar__ul__li">
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/index.aspx" CssClass="navBar__link ">
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
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="" CssClass="navBar__link active">
                     Eliminar Sucursal
        </asp:HyperLink>
      </li>
    </ul>
  </div>

  <h2 class="title">Eliminar Sucursal: </h2>

  <form id="form1" runat="server">
    <%-- Busqueda de Sucursales --%>
    <div class="busqueda">
      <span class="busqueda__span" id="rageFiltro">Ingrese ID sucursal: 
      <asp:TextBox runat="server" ID="txtFind" ValidationGroup="delete"></asp:TextBox>

        <%-- Required Field Validator --%>
        <asp:RequiredFieldValidator runat="server"
          ControlToValidate="txtFind"
          ID="requiredTxtFind" CssClass="validaciones" Text="Ingrese un ID" ValidationGroup="delete" Display="Dynamic"></asp:RequiredFieldValidator>

        <%-- REGEX VALIDATOR --%>
        <asp:RegularExpressionValidator ID="regexNumber" runat="server" ValidationGroup="delete" CssClass="validaciones" ValidationExpression="[1-9][0-9]*$" Text="Only Numbers" ControlToValidate="txtFind" Display="Dynamic"></asp:RegularExpressionValidator>

        <%-- ELIMINAR --%>
        <asp:Button runat="server" ID="btnDelete" Text="Eliminar" CssClass="aspNet-Button" OnClick="btnDelete_Click" />
      </span>
    </div>
    <%-- SCRIPT MANAGER --%>
    <asp:ScriptManager runat="server" ID="scriptManagerAddSucursal" />
    <%-- UPDATEPANEL WITH TIMER --%>
    <asp:UpdatePanel ID="UpdatePanelMsg" runat="server">
      <ContentTemplate>
        <asp:Timer ID="timer_lblShow" runat="server" Interval="6000" OnTick="timer_lblShow_Tick" />
        <asp:Label runat="server" ID="lblShowTable"></asp:Label>
      </ContentTemplate>
    </asp:UpdatePanel>
  </form>
</body>
</html>
