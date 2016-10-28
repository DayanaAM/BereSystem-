<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BereSystem.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="img">
        <div id="content">
            <div class="registro">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                <asp:LoginView ID="LoginView1" runat="server" EnableTheming="True">
                    <AnonymousTemplate>
                        <br></br>
                        <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" FailureText="Su intento de acceso no tuvo éxito. Por favor, inténtelo de nuevo." Font-Names="Verdana" Font-Size="10pt" LoginButtonText="Ingresar" PasswordLabelText="Contraseña :" RememberMeText="Recordar la próxima vez" TitleText="Registro" UserNameLabelText="Usuario :">
                            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                        </asp:Login>
                        <asp:LinkButton ID="lnkRegistrarse" runat="server" Font-Size="Medium" ForeColor="Gray" PostBackUrl="~/View/singIn.aspx">Registrarse</asp:LinkButton>
                    </AnonymousTemplate>
                    <LoggedInTemplate>

                        <p>&nbsp;</p>
                        <p>Bienvenido</p>
                        <asp:LoginName ID="LoginName1" runat="server" Font-Size="X-Large" ForeColor="White" />
                        <br />
                        <asp:LoginStatus ID="LoginStatus1" runat="server" Font-Size="Large" ForeColor="White" LoginText="Ingresar" LogoutText="Salir" />
                        &nbsp;
                                    <asp:LinkButton ID="lnkCambioContrasenna" runat="server" Font-Size="Large" ForeColor="White" PostBackUrl="~/View/changePassword.aspx">Cambiar Contraseña</asp:LinkButton>

                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
        </div>

    </div>


</asp:Content>

