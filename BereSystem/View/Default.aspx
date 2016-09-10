<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BereSystem.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
                           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            <asp:LoginView ID="LoginView1" runat="server" EnableTheming="True">
                        <AnonymousTemplate>
                            <p>Bienvenido, por favor introduce tus credenciales de acceso</p>
                            <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" LoginButtonText="Ingresar" PasswordLabelText="Contraseña :" RememberMeText="Recordar la próxima vez" TitleText="Registro" UserNameLabelText="Usuario :" FailureText="Su intento de acceso no tuvo éxito. Por favor, inténtelo de nuevo.">
                                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                   
                            </asp:Login>
                            <asp:LinkButton ID="lnkRegistrarse" runat="server" PostBackUrl="~/View/singIn.aspx" Font-Size="large" ForeColor="#d9ecb0">Registrarse</asp:LinkButton>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                                  <div >
                                    <p>&nbsp;</p>
                                    <p>Bienvenido</p>
                                    <asp:LoginName ID="LoginName1" runat="server" Font-Size="X-Large" ForeColor="White" />
                                    <br />
                                    <asp:LoginStatus ID="LoginStatus1" runat="server" Font-Size="Large" ForeColor="White" LoginText="Ingresar" LogoutText="Salir" />
                                    &nbsp;
                                    <asp:LinkButton ID="lnkCambioContrasenna" runat="server" Font-Size="Large" ForeColor="White" PostBackUrl="~/View/changePassword.aspx">Cambiar Contraseña</asp:LinkButton>
	                            </div>
                        </LoggedInTemplate>
                    </asp:LoginView>

</asp:Content>

       