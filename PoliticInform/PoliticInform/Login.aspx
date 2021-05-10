<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PoliticInform.Login" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="로그인"></asp:Label>
    <br />
    <br />
    <p>
    <asp:TextBox ID="tbLoginID" runat="server" Width="332px" Height="25px" Wrap="False" Font-Names="나눔바른고딕" Font-Size="X-Large"></asp:TextBox>
    </p>
     <p>
    <asp:TextBox ID="tbLoginPassword" runat="server" Width="330px" TextMode="Password" Height="25px" Wrap="False" Font-Names="나눔바른고딕" Font-Size="X-Large"></asp:TextBox>
    </p>
    <p>
       <asp:Button ID="btnLogin" runat="server" Text="로그인" Width="150px" BackColor="#339966" Font-Bold="True" ForeColor="White" OnClick="btnLogin_Click" Height="30px" BorderColor="#339966" Font-Names="나눔바른고딕" Font-Size="Medium"/>
        <asp:Button ID="btnRegister" runat="server" BackColor="#339966" ForeColor="White" Height="30px" Text="회원가입" Width="150px" BorderColor="#339966" Font-Bold="True" Font-Names="나눔바른고딕" Font-Size="Medium" />
    </p>
</asp:Content>

