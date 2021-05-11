<%@ Page Title="Party" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussion.aspx.cs" Inherits="K_NationalAssembly_Star.Party" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="대한민국 정당"></asp:Label>
    <br />
    <br />
    <br />
    <p>
        정당에 대한 정보를 확인할 수 있는 페이지입니다.
        추가적으로 보조금과 선거비용 정보도 표시할 예정입니다. 
    </p>
    <asp:Image ID="Image1" runat="server" Height="3000px" ImageUrl="~/Content/Parties.png" Width="1000px" />
</asp:Content>
