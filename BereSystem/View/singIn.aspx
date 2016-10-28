<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="singIn.aspx.cs" Inherits="BereSystem.View.singIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="registro">
            <asp:CreateUserWizard ID="cuwUsuarios" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnCreatedUser="cuwUsuarios_CreatedUser" AnswerLabelText="Respuesta de Seguridad :" AnswerRequiredErrorMessage="Pregunta de seguridad es un requisito " CancelButtonText="Cancelar" CompleteSuccessText="Cuenta registrada con exito ." ConfirmPasswordLabelText="Confirmación de contraseña : " ConfirmPasswordRequiredErrorMessage="Confirmación de contraseña es un requisito " ContinueButtonText="Continuar" CreateUserButtonText="Crear Usuario " DuplicateEmailErrorMessage="El correo ingresado ya esta en uso. Por favor, ingrese un correo diferente" DuplicateUserNameErrorMessage="Por favor ingrese otro nombre de usuario " EmailLabelText="Correo : " EmailRegularExpressionErrorMessage="Por favor ingrese un correo diferente" EmailRequiredErrorMessage="Correo es un requisito " InvalidAnswerErrorMessage="Por favor ingrese una respuesta de seguridad diferente" InvalidEmailErrorMessage="Por favor ingrese un correo válido " InvalidPasswordErrorMessage="Ingresesar un mínimo de 7 caracteres alfanuméricos" InvalidQuestionErrorMessage="Por favor ingrese una pregunta de seguridad diferente" PasswordLabelText="Contraseña :" PasswordRegularExpressionErrorMessage="Por favor ingrese una contraseña diferente " PasswordRequiredErrorMessage="Contraseña es un requisito" QuestionLabelText="Pregunta de Seguridad :" QuestionRequiredErrorMessage="La pregunta de seguridad es un requisito " UnknownErrorMessage="Su cuenta no fue creada. Por favor, intente de nuevo " UserNameLabelText="Nombre de Usuario :" UserNameRequiredErrorMessage="Nombre de usuario es un requisito " ConfirmPasswordCompareErrorMessage="La contraseña y la confirmación de contraseña deben coincidir ">
                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="Registro de Cuenta">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" Title="Registro Completo ">
                    </asp:CompleteWizardStep>
                </WizardSteps>
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" HorizontalAlign="Center" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <SideBarButtonStyle Font-Names="Verdana" ForeColor="#FFFFFF" BorderWidth="0px" />
                <SideBarStyle BackColor="#7C6F57" Font-Size="0.9em" VerticalAlign="Top" BorderWidth="0px" />
                <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
    <asp:LinkButton ID="lnkVolver" runat="server" PostBackUrl="~/View/Default.aspx" Font-Size="Medium" ForeColor="Gray">Volver</asp:LinkButton>

        </div>
</asp:Content>
