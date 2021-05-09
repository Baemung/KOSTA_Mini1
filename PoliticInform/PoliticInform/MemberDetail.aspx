<%@ Page Title="MemberDetail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="PoliticInform.MemberDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="국회의원 상세정보"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Image ID="img" runat="server" Height="500px" ImageAlign="Top" Width="500px" />
            <br />
            <br />
            <asp:DetailsView ID="dv" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1" Height="200px" style="margin-top: 0px" Width="1200px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="5px" CellPadding="3" CellSpacing="3" ForeColor="Black">
                <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <Fields>
                    <asp:BoundField DataField="empNm" HeaderText="이름" SortExpression="empNm" />
                    <asp:BoundField DataField="hjNm" HeaderText="한문명" SortExpression="hjNm" />
                    <asp:BoundField DataField="engNm" HeaderText="영문명" SortExpression="engNm" />
                    <asp:BoundField DataField="polyNm" HeaderText="정당" SortExpression="polyNm" />
                    <asp:BoundField DataField="origNm" HeaderText="비례대표/선거구" SortExpression="origNm" />
                    <asp:BoundField DataField="reeleGbnNm" HeaderText="당선횟수" SortExpression="reeleGbnNm" />
                    <asp:BoundField DataField="bthDate" HeaderText="생년월일" SortExpression="bthDate" />
                    <asp:BoundField DataField="shrtNm" HeaderText="소속위원회" SortExpression="shrtNm" />
                    <asp:BoundField DataField="assemTel" HeaderText="전화번호" SortExpression="assemTel" />
                    <asp:BoundField DataField="assemEmail" HeaderText="이메일" SortExpression="assemEmail" />
                    <asp:BoundField DataField="assemHomep" HeaderText="홈페이지" SortExpression="assemHomep" />
                    <asp:BoundField DataField="memTitle" HeaderText="약력" SortExpression="memTitle" />
                </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
            </asp:DetailsView>
            <br />
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString2 %>" SelectCommand="SELECT [jpgLink], [empNm], [hjNm], [engNm], [polyNm], [origNm], [reeleGbnNm], [bthDate], [shrtNm], [assemTel], [assemEmail], [assemHomep], [memTitle] FROM [totalInfo]"></asp:SqlDataSource>
</asp:Content>