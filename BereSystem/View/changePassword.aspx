<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="BereSystem.View.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="content" aria-autocomplete="none">

             <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnChangedPassword="ChangePassword1_ChangedPassword" OnCancelButtonClick="ChangePassword1_CancelButtonClick" CancelButtonText="Cancelar" ChangePasswordButtonText="Cambiar Contraseña" ChangePasswordFailureText="La contraseña es incorrecta o la nueva contraseña es inválida. Debe contener 7 caracteres como mínimo." ChangePasswordTitleText="Cambio de Contraseña " ConfirmNewPasswordLabelText="Confirmación nueva contraseña :" ConfirmPasswordCompareErrorMessage="La confirmación de la nueva contraseña debe coincidir con la nueva contraseña." ConfirmPasswordRequiredErrorMessage="Confirmación de la nueva contraseña es requisito ." ContinueButtonText="Continuar" NewPasswordLabelText="Nueva contraseña :" NewPasswordRegularExpressionErrorMessage="Por favor ingresse una contraseña diferente." NewPasswordRequiredErrorMessage="Nueva contraseña es requisito." PasswordLabelText="Contraseña:" PasswordRequiredErrorMessage="Contraseña es requisito." SuccessText="Su contraseña ha sido cambiada!" SuccessTitleText="Cambio de contraseña completo" UserNameLabelText="Usuario:" UserNameRequiredErrorMessage="Usuario es requisito.">
                 <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:ChangePassword>
        </div>
</asp:Content>
