<%@ Page Title="Issue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussion.aspx.cs" Inherits="PoliticInform.Contact" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <p>
        이슈&포커스, 의원님은 재판중, 국민동의청원중 세개의 게시판으로 나눠져 있습니다. 
    </p>
    <asp:Button ID="Button1" runat="server" Text="이슈&포커스" Width="150px" /><asp:Button ID="Button2" runat="server" Text="의원님은 재판중" Width="150px" /><asp:Button ID="Button3" runat="server" Text="국민청원동의중" Width="150px" />
    <p>
        버튼을 눌렀을 때의 동작은 이후에 완성하도록 하겠습니다. 
    </p>
</asp:Content>


