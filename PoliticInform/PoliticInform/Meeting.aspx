<%@ Page Title="Meeting" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussion.aspx.cs" Inherits="PoliticInform.Contact" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <p>
         회의 정보를 확인할 수 있는 페이지입니다. 
        상임 위원회, 본회의 중 골라서 drop down item 형식으로 보여줄 생각입니다. 
    </p>
    <asp:Button ID="Button1" runat="server" Text="상임위원회" Width="150px"  /><asp:Button ID="Button2" runat="server" Text="본회의" Width="150px" /><asp:Button ID="Button3" runat="server" Text="상임위출석부"  Width="150px" />


    <p>
        이벤트 처리는 나중에 진행하겠습니다. 
    </p>
</asp:Content>



