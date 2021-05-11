<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="K_NationalAssembly_Star.Register" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" TextMode="Search">
    
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="회원가입"></asp:Label>
    <br />
    <br />
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000; width: 756px;">
        아이디
        (6~20자)

    <asp:TextBox ID="RegisterID" runat="server" Width="300px" MaxLength="20"></asp:TextBox>
        <asp:Button ID="btnIDcheck" runat="server" OnClick="btnIDcheck_Click" Text="중복확인" BackColor="#339966" BorderColor="#339966" Font-Names="나눔바른고딕" ForeColor="White" />
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        비밀번호
        (8~12자)
        <asp:TextBox ID="RegisterPassword" runat="server" Width="300" TextMode="Password" MaxLength="12"></asp:TextBox>
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        비밀번호 재확인
        <asp:TextBox ID="ConfirmPassword" runat="server" Width="300" TextMode="Password" MaxLength="12"></asp:TextBox>
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        이름
         <asp:TextBox ID="RegisterName" runat="server" Width="300px"></asp:TextBox>
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        생년월일(ex. yyyymmdd)
        <asp:TextBox ID="RegisterBthDay" runat="server" MaxLength="8" Width="261px"></asp:TextBox>
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        성별
        <asp:DropDownList ID="RegisterGender" runat="server" Width="300">
            <asp:ListItem>선택안함</asp:ListItem>
            <asp:ListItem>남자</asp:ListItem>
            <asp:ListItem>여자</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        휴대전화
        <asp:DropDownList ID="RegisterPhoneFirst" runat="server" Width="80px">
            <asp:ListItem>010</asp:ListItem>
            <asp:ListItem>011</asp:ListItem>
            <asp:ListItem>016</asp:ListItem>
            <asp:ListItem>017</asp:ListItem>
            <asp:ListItem>018</asp:ListItem>
        </asp:DropDownList>-<asp:TextBox ID="RegisterPhoneSecond" runat="server" Width="100px" MaxLength="4"></asp:TextBox>-<asp:TextBox ID="RegisterPhoneThird" runat="server" Width="100px" MaxLength="4"></asp:TextBox>
    </p>
    <p style="font-family: 나눔바른고딕; font-size: x-small; color: #000000">
        이메일
        <asp:TextBox ID="RegisterEmail" runat="server" Width="300"></asp:TextBox>

    </p>
    <p>
        <asp:Button ID="btnRegister" runat="server" Text="가입하기" Width="300" OnClick="RegisterUser" BackColor="#339966" BorderColor="#339966" Font-Names="나눔바른고딕" Font-Size="X-Small" ForeColor="White"/>
    </p>
</asp:Content>




