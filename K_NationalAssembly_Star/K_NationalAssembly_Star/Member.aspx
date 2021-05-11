<%@ Page Title="Member" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="K_NationalAssembly_Star.Member" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="국회의원 검색"></asp:Label>
    <br />
    <br />
    <p>
        이름 <asp:TextBox ID="tbMemberName" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="검색" OnClick="MemberSearch" Height="30px" Width="90px" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </p>
    <p>
        정당 <asp:DropDownList ID="MemberParty" runat="server" EnableTheming="True" Width="180px">
            <asp:ListItem Selected="False">전체</asp:ListItem>
            <asp:ListItem Selected="False">국민의당</asp:ListItem>
            <asp:ListItem Selected="False">국민의힘</asp:ListItem>
            <asp:ListItem Selected="False">기본소득당</asp:ListItem>
            <asp:ListItem Selected="False">더불어민주당</asp:ListItem>
            <asp:ListItem Selected="False">더불어시민당</asp:ListItem>
            <asp:ListItem Selected="False">무소속</asp:ListItem>
            <asp:ListItem Selected="False">미래한국당</asp:ListItem>
            <asp:ListItem Selected="False">시대전환</asp:ListItem>
            <asp:ListItem Selected="False">열린민주당</asp:ListItem>
            <asp:ListItem Selected="False">정의당</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        지역 <asp:DropDownList ID="MemberArea" runat="server" Width="180px">
            <asp:ListItem>전체</asp:ListItem>
            <asp:ListItem>비례대표</asp:ListItem>
            <asp:ListItem>강원</asp:ListItem>
            <asp:ListItem>경기</asp:ListItem>
            <asp:ListItem>경남</asp:ListItem>
            <asp:ListItem>경북</asp:ListItem>
            <asp:ListItem>광주</asp:ListItem>
            <asp:ListItem>대구</asp:ListItem>
            <asp:ListItem>대전</asp:ListItem>
            <asp:ListItem>부산</asp:ListItem>
            <asp:ListItem>서울</asp:ListItem>
            <asp:ListItem>세종</asp:ListItem>
            <asp:ListItem>울산</asp:ListItem>
            <asp:ListItem>인천</asp:ListItem>
            <asp:ListItem>전남</asp:ListItem>
            <asp:ListItem>전북</asp:ListItem>
            <asp:ListItem>제주</asp:ListItem>
            <asp:ListItem>충남</asp:ListItem>
            <asp:ListItem>충북</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        위원회 <asp:DropDownList ID="MemberCommittee" runat="server" Width="180px">
            <asp:ListItem>전체</asp:ListItem>
            <asp:ListItem>과학기술정보방송통신</asp:ListItem>
            <asp:ListItem>교육</asp:ListItem>
            <asp:ListItem>국무총리(김부겸)임명동의에 관한 인사청문 특별</asp:ListItem>
            <asp:ListItem>국방</asp:ListItem>
            <asp:ListItem>국토교통</asp:ListItem>
            <asp:ListItem>국회운영</asp:ListItem>
            <asp:ListItem>기획재정</asp:ListItem>
            <asp:ListItem>농림축산식품해양수산</asp:ListItem>
            <asp:ListItem>대법관(천대엽)임명동의에 관한 인사청문 특별</asp:ListItem>
            <asp:ListItem>문화체육관광</asp:ListItem>
            <asp:ListItem>법제사법</asp:ListItem>
            <asp:ListItem>보건복지</asp:ListItem>
            <asp:ListItem>산업통상자원중소벤처기업</asp:ListItem>
            <asp:ListItem>여성가족</asp:ListItem>
            <asp:ListItem>예산결산특별</asp:ListItem>
            <asp:ListItem>외교통일</asp:ListItem>
            <asp:ListItem>윤리특별</asp:ListItem>
            <asp:ListItem>정무</asp:ListItem>
            <asp:ListItem>정보</asp:ListItem>
        </asp:DropDownList>
    </p>

    <p>
        
        당선횟수 <asp:DropDownList ID="MemberElectedTimes" runat="server" Width="180px">
            <asp:ListItem>전체</asp:ListItem>
            <asp:ListItem>초선</asp:ListItem>
            <asp:ListItem>재선</asp:ListItem>
            <asp:ListItem>3선</asp:ListItem>
            <asp:ListItem>4선</asp:ListItem>
            <asp:ListItem>5선</asp:ListItem>
            <asp:ListItem>6선</asp:ListItem>
            <asp:ListItem>7선</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="MemberConfirm" runat="server" Text="확인" OnClick="btnMemberClick" Height="30px" Width="120px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="MemberReset" runat="server" Text="검색초기화" OnClick="MemberReset_Click" Height="30px" Width="150px" />
    </p>
    <p>
        <asp:DataList ID="DataList1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Both" RepeatColumns="5">
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString %>" SelectCommand="SELECT [jpgLink], [empNm], [origNm], [polyNm], [deptCd], [shrtNm], [reeleGbnNm] FROM [totalInfo]"></asp:SqlDataSource>
    </p>
    </asp:Content>
