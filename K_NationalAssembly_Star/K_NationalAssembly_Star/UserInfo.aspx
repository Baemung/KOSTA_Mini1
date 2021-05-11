<%@ Page Title="UserInfo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="K_NationalAssembly_Star.UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="회원정보"></asp:Label>
    <br />
    <br />
    <p>
        이름&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp; 
    </p>
    <p>
        생년월일&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbUserbday" runat="server"></asp:TextBox> 
    </p>
    <p>
        성별&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="UserGender" runat="server" Width="300">
            <asp:ListItem>선택안함</asp:ListItem>
            <asp:ListItem>남자</asp:ListItem>
            <asp:ListItem>여자</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        휴대전화&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="UserPhoneFirst" runat="server" Width="80px">
            <asp:ListItem>010</asp:ListItem>
            <asp:ListItem>011</asp:ListItem>
            <asp:ListItem>016</asp:ListItem>
            <asp:ListItem>017</asp:ListItem>
            <asp:ListItem>018</asp:ListItem>
        </asp:DropDownList><asp:TextBox ID="UserPhoneSecond" runat="server" Width="100px" MaxLength="4"></asp:TextBox><asp:TextBox ID="UserPhoneThird" runat="server" Width="100px" MaxLength="4" Height="22px"></asp:TextBox>
    </p>

    <p>
        
        이메일&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbUserEmail" runat="server"></asp:TextBox> 
    </p>
    <p>
        <asp:Button ID="btnChange" runat="server" Text="수정" OnClick="btnChangeClick" Height="30px" Width="120px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <p>
        &nbsp;<p>
        <asp:Label ID="Label3" runat="server" Font-Size="X-Large" Text="좋아요 표시한 국회의원"></asp:Label>
    <p>
        <asp:DataList ID="DataList1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Both" RepeatColumns="5">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:ImageButton CssClass="ourproductPAGE_productImage" ID="jpgLinkImage" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("jpgLink") %> ' PostBackUrl='<%# "MemberDetail.aspx?id=" +Eval("deptCd") %>'/>
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
                소속위원회:
                <asp:Label ID="shrtNmLabel" runat="server" Text='<%# Eval("shrtNm") %>' />
                <br />
                당선횟수:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [empNm], [polyNm], [origNm], [reeleGbnNm] FROM [totalInfo]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label4" runat="server" Font-Size="X-Large" Text="싫어요 표시한 국회의원"></asp:Label>
        <asp:DataList ID="DataList2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Both" RepeatColumns="5">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:ImageButton CssClass="ourproductPAGE_productImage" ID="jpgLinkImage" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("jpgLink") %> ' PostBackUrl='<%# "MemberDetail.aspx?id=" +Eval("deptCd") %>'/>
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
                소속위원회:
                <asp:Label ID="shrtNmLabel" runat="server" Text='<%# Eval("shrtNm") %>' />
                <br />
                당선횟수:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" Font-Size="X-Large" Text="코멘트 남긴 국회의원"></asp:Label>
        <asp:DataList ID="DataList3" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSource3" ForeColor="Black" GridLines="Both" RepeatColumns="5">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <asp:ImageButton CssClass="ourproductPAGE_productImage" ID="jpgLinkImage" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("jpgLink") %> ' PostBackUrl='<%# "MemberDetail.aspx?id=" +Eval("deptCd") %>'/>
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
                소속위원회:
                <asp:Label ID="shrtNmLabel" runat="server" Text='<%# Eval("shrtNm") %>' />
                <br />
                당선횟수:
                <asp:Label ID="reeleGbnNmLabel" runat="server" Text='<%# Eval("reeleGbnNm") %>' />
                <br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [empNm], [polyNm], [origNm], [reeleGbnNm] FROM [totalInfo]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [empNm], [origNm], [polyNm], [deptCd], [shrtNm], [reeleGbnNm] FROM [totalInfo]"></asp:SqlDataSource>
    </p>
</asp:Content>
