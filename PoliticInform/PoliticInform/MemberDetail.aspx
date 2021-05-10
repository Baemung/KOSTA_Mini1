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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <%  
                    if (Session["uid"] != null)
                    {%>
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgbtnLike" runat="server" Height="100px" ImageAlign="Left" ImageUrl="~/Content/Disable_Like.png" OnClick="imgbtnLike_Click" Width="100px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="imgbtnDislike" runat="server" Height="100px" ImageUrl="~/Content/Disable_Dislike.png" OnClick="imgbtnDislike_Click" Width="100px" />    
                    <%}
                    else
                    {%>
                        &nbsp;&nbsp;&nbsp;
                        <asp:Image ID="Image1" runat="server" Height="100px" ImageAlign="Left" ImageUrl="~/Content/Disable_Like.png" Width="100px" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Image ID="Image2" runat="server" Height="100px" ImageUrl="~/Content/Disable_Dislike.png" Width="100px" />
                    <%}
             %>
                        &nbsp;&nbsp;&nbsp;
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbLike" runat="server" Font-Size="Large" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lbDislike" runat="server" Font-Size="Large" Text="Label"></asp:Label> 
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
            <asp:GridView ID="GridView1" CssClass="Grid" runat="server" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting"  AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="861px" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="uid" HeaderText="ID" SortExpression="uid" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>

                    <asp:BoundField DataField="comment" HeaderText="코멘트" SortExpression="comment" >
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>

                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" >
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" Font-Size="Large" Font-Underline="True" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <br />
            <%  
                    if(Session["uid"] != null)
                    {%>
                        <asp:TextBox ID="tbComment" runat="server" Height="77px" MaxLength="2000" TextMode="MultiLine" Width="836px"></asp:TextBox>
                        <asp:Button ID="btnComment" runat="server" Height="60px" OnClick="btnComment_Click" Text="등록" Width="120px" />
                    <%}
            %>
            
            <br />
            <br />
            <br />
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:miniProject2ConnectionString3 %>" SelectCommand="SELECT [comment], [uid] FROM [UserComment]"></asp:SqlDataSource>
</asp:Content>