<%@ Page Title="Rank" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rank.aspx.cs" Inherits="K_NationalAssembly_Star.Rank" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="국회의원 랭킹"></asp:Label>
    <br /><br /><br />
    <asp:Label ID="Label1" runat="server" Text="좋아요 TOP 5" Font-Size="Large"></asp:Label>
    <p>
        <asp:DataList ID="dlLike" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both" Height="330px" Width="1022px">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:ImageButton CssClass="ourproductPAGE_productImage" ID="jpgLinkImage" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("jpgLink") %> ' PostBackUrl='<%# "MemberDetail.aspx?id=" +Eval("deptCd") %>'/>
                <br />
                좋아요 수:
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("total") %>' />
                <br />
                이름:
                <asp:Label ID="empNmLabel" runat="server" Text='<%# Eval("empNm") %>' />
                <br />
                비례대표/선거구:
                <asp:Label ID="origNmLabel" runat="server" Text='<%# Eval("origNm") %>' />
                <br />
                정당:
                <asp:Label ID="polyNmLabel" runat="server" Text='<%# Eval("polyNm") %>' />
                <br />
                당선횟수:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [total], [empNm], [polyNm], [origNm], [reeleGbnNm], [deptCd] FROM [likerankInfo]"></asp:SqlDataSource>
    </p>
    <br />
    <asp:Label ID="Label2" runat="server" Text="싫어요  TOP 5" Font-Size="Large"></asp:Label>
    <p>
        <asp:DataList ID="dlDislike" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:ImageButton CssClass="ourproductPAGE_productImage" ID="jpgLinkImage" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("jpgLink") %> ' PostBackUrl='<%# "MemberDetail.aspx?id=" +Eval("deptCd") %>'/>
                <br />
                싫어요 수:
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("total") %>' />
                <br />
                이름:
                <asp:Label ID="empNmLabel" runat="server" Text='<%# Eval("empNm") %>' />
                <br />
                비례대표/선거구:
                <asp:Label ID="origNmLabel" runat="server" Text='<%# Eval("origNm") %>' />
                <br />
                정당:
                <asp:Label ID="polyNmLabel" runat="server" Text='<%# Eval("polyNm") %>' />
                <br />
                당선횟수:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [total], [empNm], [polyNm], [origNm], [reeleGbnNm], [deptCd] FROM [dislikerankInfo]"></asp:SqlDataSource>
    </p>
    <br />
    <asp:Label ID="Label3" runat="server" Text="코멘트  TOP 5" Font-Size="Large"></asp:Label>
    <p>
        <asp:DataList ID="dlComment" runat="server" DataSourceID="SqlDataSource3" RepeatDirection="Horizontal" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:ImageButton CssClass="ourproductPAGE_productImage" ID="jpgLinkImage" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("jpgLink") %> ' PostBackUrl='<%# "MemberDetail.aspx?id=" +Eval("deptCd") %>'/>
                <br />
                코멘트 수:
                <asp:Label ID="Label4" runat="server" Text='<%# Eval("total") %>' />
                <br />
                이름:
                <asp:Label ID="empNmLabel" runat="server" Text='<%# Eval("empNm") %>' />
                <br />
                비례대표/선거구:
                <asp:Label ID="origNmLabel" runat="server" Text='<%# Eval("origNm") %>' />
                <br />
                정당:
                <asp:Label ID="polyNmLabel" runat="server" Text='<%# Eval("polyNm") %>' />
                <br />
                당선횟수:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [total], [empNm], [polyNm], [origNm], [reeleGbnNm], [deptCd] FROM [commentrankInfo]"></asp:SqlDataSource>
    </p>
    </asp:Content>


