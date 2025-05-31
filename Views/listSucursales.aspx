<%@ Page Language="C#" AutoEventWireup="true"
  UnobtrusiveValidationMode="None"
  CodeBehind="listSucursales.aspx.cs" Inherits="Views.listSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Sucursales</title>
  <link rel="stylesheet" type="text/css" href="listSucursales.css" />
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
      <%-- LIST SUCURSALES --%>
      <li class="navBar__ul__li">
        <asp:HyperLink ID="linkListSuc" runat="server" NavigateUrl="" CssClass="navBar__link active">
                Listado de sucursales
        </asp:HyperLink>
      </li>
      <%-- DELETE SUCURSALES --%>
      <li class="navBar__ul__li">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="" CssClass="navBar__link ">
                 Eliminar Sucursal
        </asp:HyperLink>
      </li>
    </ul>
  </div>
  <%-- TItulo: --%>
  <h2 class="title">Listado de sucursales</h2>
  <%-- FORMULARIO --%>
  <form id="form1" runat="server">

    <%-- Busqueda de Sucursales --%>
    <div class="busqueda">
      <span class="busqueda__span" id="rageFiltro">Ingrese ID sucursal: 
      <asp:TextBox runat="server" ID="txtFind" ValidationGroup="Filter"></asp:TextBox>
        <%-- Required Field Validator --%>
        <asp:RequiredFieldValidator runat="server"
          ControlToValidate="txtFind"
          ID="requiredTxtFind" CssClass="validaciones" Text="Ingrese un ID" ValidationGroup="Filter" Display="Dynamic"></asp:RequiredFieldValidator>
        <%-- REGEX VALIDATOR --%>
        <asp:RegularExpressionValidator ID="regexNumber" runat="server" ValidationGroup="Filter" CssClass="validaciones" ValidationExpression="[1-9][0-9]*$" Text="Only Numbers" ControlToValidate="txtFind" Display="Dynamic"></asp:RegularExpressionValidator>

        <%-- BUTTON FILTER--%>
        <asp:Button runat="server" ID="btnFilter" Text="Filtrar" ValidationGroup="Filter" CssClass="aspNet-Button" OnClick="BtnFilter_Click" />
        <%-- BUTTON SHOW ALL --%>
        <asp:Button runat="server" ID="btnShowAll" Text="Mostrar Todos" CssClass="aspNet-Button" OnClick="BtnShowAll_Click" />
        <asp:Label runat="server" ID="lblShow" CssClass="lblNotFound"></asp:Label>
      </span>
    </div>

    <%--Grid con los resultados: --%>
    <div class="gridFiltros">
      <asp:GridView runat="server" ID="gridFiltros" CssClass="gridFiltros"></asp:GridView>
    </div>
  </form>
</body>
</html>

<%-- TOTO: ADD  <asp:ScriptManager> ,   <asp:UpdatePanel>  <ContentTemplate> for not reload the page--%>