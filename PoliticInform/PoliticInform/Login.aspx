<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PoliticInform.Login" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="font-size: xx-large; font-style: normal; font-variant: small-caps">
        로그인</h1>
    <p>
    <asp:TextBox ID="tbLoginID" runat="server" Width="500px" Height="50px" Wrap="False"></asp:TextBox>
    </p>
     <p>
    <asp:TextBox ID="tbLoginPassword" runat="server" Width="500px" TextMode="Password" Height="50px" Wrap="False"></asp:TextBox>
    </p>
    <p>
       <asp:Button ID="btnLogin" runat="server" Text="로그인" Width="150px" BackColor="#33CC33" Font-Bold="True" ForeColor="White" OnClick="btnLogin_Click" Height="50px"/>
        <asp:Button ID="btnRegister" runat="server" BackColor="#33CC33" ForeColor="White" Height="50px" Text="회원가입" Width="150px" />
    </p>
</asp:Content>



