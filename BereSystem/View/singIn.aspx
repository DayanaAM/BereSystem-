<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="singIn.aspx.cs" Inherits="BereSystem.View.singIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="content">
            <asp:CreateUserWizard ID="cuwUsuarios" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnCreatedUser="cuwUsuarios_CreatedUser">
                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Center" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <SideBarButtonStyle Font-Names="Verdana" ForeColor="#FFFFFF" BorderWidth="0px" />
                <SideBarStyle BackColor="#7C6F57" Font-Size="0.9em" VerticalAlign="Top" BorderWidth="0px" />
                <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
    <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/View/Default.aspx" Font-Size="Medium" ForeColor="White">Volver</asp:LinkButton>

        </div>
</asp:Content>
