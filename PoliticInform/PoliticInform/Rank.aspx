<%@ Page Title="Rank" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rank.aspx.cs" Inherits="PoliticInform.Rank" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="국회의원 랭킹"></asp:Label>
    <br /><br /><br />
    <asp:Label ID="Label1" runat="server" Text="좋아요 TOP 5" Font-Size="Large"></asp:Label>
    <p>
        <asp:DataList ID="dlLike" runat="server" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal">
            <ItemTemplate>
                total:
                <asp:Label ID="totalLabel" runat="server" Text='<%# Eval("total") %>' />
                <br />
                deptCd:
                <asp:Label ID="deptCdLabel" runat="server" Text='<%# Eval("deptCd") %>' />
                <br />
                jpgLink:
                <asp:Label ID="jpgLinkLabel" runat="server" Text='<%# Eval("jpgLink") %>' />
                <br />
                empNm:
                <asp:Label ID="empNmLabel" runat="server" Text='<%# Eval("empNm") %>' />
                <br />
                origNm:
                <asp:Label ID="origNmLabel" runat="server" Text='<%# Eval("origNm") %>' />
                <br />
                polyNm:
                <asp:Label ID="polyNmLabel" runat="server" Text='<%# Eval("polyNm") %>' />
                <br />
                reeleGbnNm:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString3 %>" SelectCommand="SELECT * FROM [likerankInfo]"></asp:SqlDataSource>
    </p>
    <br />
    <asp:Label ID="Label2" runat="server" Text="싫어요  TOP 5" Font-Size="Large"></asp:Label>
    <p>
        <asp:DataList ID="dlDislike" runat="server" DataSourceID="SqlDataSource2" RepeatDirection="Horizontal">
            <ItemTemplate>
                total:
                <asp:Label ID="totalLabel" runat="server" Text='<%# Eval("total") %>' />
                <br />
                deptCd:
                <asp:Label ID="deptCdLabel" runat="server" Text='<%# Eval("deptCd") %>' />
                <br />
                jpgLink:
                <asp:Label ID="jpgLinkLabel" runat="server" Text='<%# Eval("jpgLink") %>' />
                <br />
                empNm:
                <asp:Label ID="empNmLabel" runat="server" Text='<%# Eval("empNm") %>' />
                <br />
                origNm:
                <asp:Label ID="origNmLabel" runat="server" Text='<%# Eval("origNm") %>' />
                <br />
                polyNm:
                <asp:Label ID="polyNmLabel" runat="server" Text='<%# Eval("polyNm") %>' />
                <br />
                reeleGbnNm:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString3 %>" SelectCommand="SELECT * FROM [dislikerankInfo]"></asp:SqlDataSource>
    </p>
    <br />
    <asp:Label ID="Label3" runat="server" Text="코멘트  TOP 5" Font-Size="Large"></asp:Label>
    <p>
        <asp:DataList ID="dlComment" runat="server" DataSourceID="SqlDataSource3" RepeatDirection="Horizontal">
            <ItemTemplate>
                total:
                <asp:Label ID="totalLabel" runat="server" Text='<%# Eval("total") %>' />
                <br />
                deptCd:
                <asp:Label ID="deptCdLabel" runat="server" Text='<%# Eval("deptCd") %>' />
                <br />
                jpgLink:
                <asp:Label ID="jpgLinkLabel" runat="server" Text='<%# Eval("jpgLink") %>' />
                <br />
                empNm:
                <asp:Label ID="empNmLabel" runat="server" Text='<%# Eval("empNm") %>' />
                <br />
                origNm:
                <asp:Label ID="origNmLabel" runat="server" Text='<%# Eval("origNm") %>' />
                <br />
                polyNm:
                <asp:Label ID="polyNmLabel" runat="server" Text='<%# Eval("polyNm") %>' />
                <br />
                reeleGbnNm:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString3 %>" SelectCommand="SELECT * FROM [commentrankInfo]"></asp:SqlDataSource>
    </p>
    </asp:Content>


