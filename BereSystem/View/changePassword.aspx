<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="BereSystem.View.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="content">

             <asp:ChangePassword ID="ChangePassword1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" OnChangedPassword="ChangePassword1_ChangedPassword" OnCancelButtonClick="ChangePassword1_CancelButtonClick">
                 <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
            </asp:ChangePassword>
        </div>
</asp:Content>
