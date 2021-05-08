<%@ Page Title="Discussion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discussion.aspx.cs" Inherits="PoliticInform.Contact" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [BILL_NO], [BILL_NAME], [PROPOSER], [DETAIL_LINK], [COMMITTEE], [PROPOSE_DT], [PROC_RESULT] FROM [Proposition] ORDER BY [PROPOSE_DT] DESC"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="국회의원 발의법률안 검색"></asp:Label>
    <br />
    <br />
    <br />
    <asp:DropDownList ID="ddlist" runat="server" Height="30px" Width="185px">
        <asp:ListItem Value="BILL_NO">의안번호</asp:ListItem>
        <asp:ListItem Value="BILL_NAME">법률안명</asp:ListItem>
        <asp:ListItem Value="PROPOSER">제안자</asp:ListItem>
        <asp:ListItem Value="DETAIL_LINK">상세페이지 링크</asp:ListItem>
        <asp:ListItem Value="COMMITTEE">소관위원회</asp:ListItem>
        <asp:ListItem Value="PROPOSE_DT">제안일</asp:ListItem>
        <asp:ListItem Value="PROC_RESULT">처리상태</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;
    <asp:TextBox ID="tbSearch" runat="server" Height="30px" Width="339px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSearch" runat="server" Height="30px" Text="검색" Width="140px" OnClick="btnSearch_Click" />
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="20" CellSpacing="5" DataSourceID="SqlDataSource1" Font-Size="X-Small" ForeColor="Black" Height="709px" HorizontalAlign="Justify" Width="1219px" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="BILL_NO" HeaderText="의안번호" SortExpression="BILL_NO" />
            <asp:BoundField DataField="BILL_NAME" HeaderText="법률안명" SortExpression="BILL_NAME" />
            <asp:BoundField DataField="PROPOSER" HeaderText="제안자" SortExpression="PROPOSER" />
            <asp:BoundField DataField="DETAIL_LINK" HeaderText="상세페이지 링크" SortExpression="DETAIL_LINK" />
            <asp:BoundField DataField="COMMITTEE" HeaderText="소관위원회" SortExpression="COMMITTEE" />
            <asp:BoundField DataField="PROPOSE_DT" HeaderText="제안일" SortExpression="PROPOSE_DT" />
            <asp:BoundField DataField="PROC_RESULT" HeaderText="처리상태" SortExpression="PROC_RESULT" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Larger"/>
        <PagerSettings Mode="NumericFirstLast" />
        <PagerStyle BackColor="White" Font-Bold="False" Font-Size="Medium" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" BorderWidth="5" BorderStyle="None" Font-Underline="True" Height="100" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</asp:Content>


