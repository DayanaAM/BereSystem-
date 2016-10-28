<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroProcedimientos.aspx.cs" Inherits="BereSystem.View.ZonaAdministrador.RegistroProcedimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>Registro Procedimientos Especializados</h1>
          <table class="mantenimiento">
                
                <tr>
                    <td>Codigo:</td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                 <tr>
                    <td>Nombre:</td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ErrorMessage="Debe digitar el nombre del Servicio " ForeColor="#CC0000" SetFocusOnError="True" ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                       
                </tr>
                  <tr>
                    <td>Categoria:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategorias" runat="server"></asp:DropDownList></td>
                    <td></td>
                </tr>
                  <tr>
                    <td>Zona:</td>
                    <td>
                        <asp:DropDownList ID="ddlZonas" runat="server"></asp:DropDownList></td>
                    <td>
                      </td>
                </tr>
                 <tr>
                    <td>Precio :</td>
                    <td>
                        <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number">00000</asp:TextBox>
                        </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                  <td>Duración:</td>
                  <td >
                      
                      <asp:TextBox ID="txtDuracion" runat="server" TextMode="Number" Width="25px">1</asp:TextBox>
                     &nbsp Horas
                  </td>
                   
              </tr>
                   <tr>
                  <td>Estado:</td>
                  <td >
                      <asp:DropDownList ID="cboEstado" runat="server">
                          <asp:ListItem Value="1">Activo</asp:ListItem>
                          <asp:ListItem Value="0">Inactivo</asp:ListItem>
                      </asp:DropDownList>
                  </td>
              </tr>
                <tr>
                    <td colspan="4" class="centrar">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" BackColor="#4B84A6" Font-Size="Large" ForeColor="White" OnClick="btnAgregar_Click"   />
                           <asp:Button ID="btnActualiza" runat="server" Text="Actualizar" BackColor="#4B84A6" Font-Size="Large" ForeColor="White"   />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" BackColor="#4B84A6" Font-Size="Large" ForeColor="White"  />
                    </td>
                </tr>
                <tr>
                    <td colspan="4"class="centrar" >
                        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></td>
                </tr>
               <tr>
               <td colspan="4" class="derecha">
                   <asp:LinkButton ID="lnkRegresar" runat="server" CausesValidation="FALSE" PostBackUrl="~/View/Default.aspx" Font-Size="Medium" Font-Underline="False" ForeColor="White">Volver</asp:LinkButton></td>
                </tr>
       </table>
          <br />
        <br />
         <div class="datos">
          <div class="tabla1">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                 <ContentTemplate>
                  
                      <asp:GridView ID="gvProductos" runat="server"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="cod" CausesValidation="FALSE"  >
                          <Columns>
                              <asp:BoundField DataField="cod" HeaderText="Código" ReadOnly="True" SortExpression="cod" />
                              <asp:BoundField DataField="descrpcion" HeaderText="Descripción" SortExpression="descrpcion" />
                              <asp:BoundField DataField="precio" HeaderText="Precio" SortExpression="precio" />
                              <asp:BoundField DataField="stock" HeaderText="Stock" SortExpression="stock" />
                              <asp:BoundField DataField="proveedor" HeaderText="Proveedor" SortExpression="proveedor" />
                              <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="imgSeleccion" CausesValidation="FALSE" runat="server" CommandName="Select" ImageUrl="~/Images/check1.jpg"/>
                                  </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                 </asp:TemplateField>
                          </Columns>
                             
                          <FooterStyle BackColor="White" ForeColor="#000066" />
                          <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                          <RowStyle ForeColor="#000066" />
                          <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F1F1F1" />
                          <SortedAscendingHeaderStyle BackColor="#007DBB" />
                          <SortedDescendingCellStyle BackColor="#CAC9C9" />
                          <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
               <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aspnetdbConnectionString %>" SelectCommand="SELECT [cod], [descrpcion], [precio], [stock], [proveedor], [estado] FROM [productos]"></asp:SqlDataSource>--%>
             </ContentTemplate>
       </asp:UpdatePanel>   
     </div>
    <div class="tabla2">
         <asp:Button ID="btnEditar" runat="server" Text="Modificar Registro" CausesValidation="FALSE" BackColor="#4B84A6" Font-Size="Large" ForeColor="White"    />
        <br />
        <asp:Label ID="lblErrorSeleccion" runat="server" Text="Debe seleccionar un registro" ForeColor="Red" Font-Size="X-Large"></asp:Label>
        <br />
    </div>
     </div>
</asp:Content>
