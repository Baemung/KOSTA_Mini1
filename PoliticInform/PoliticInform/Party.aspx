<%@ Page Title="Party" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussion.aspx.cs" Inherits="PoliticInform.Contact" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <p>
        정당에 대한 정보를 확인할 수 있는 페이지입니다.
        추가적으로 보조금과 선거비용 정보도 표시할 예정입니다. 
    </p>
    <asp:Image ID="Image1" runat="server" Height="2803px" ImageUrl="~/Content/Parties.png" Width="1318px" />
</asp:Content>
