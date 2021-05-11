<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="K_NationalAssembly_Star._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Style.css" rel="stylesheet"/>
    <body >
<div class="jumbotron"  >
    <p aria-atomic="False" style="font-family: 나눔바른고딕; font-size: xx-large; font-weight: normal; color: #000000; white-space: nowrap; background-color: #EEEEEE">K-국회 스타</p>
    <p style="font-family: 나눔바른고딕; font-size: large">&nbsp;</p>
    <p style="font-family: 나눔바른고딕; font-size: large">Open API를 활용한 국회의원 정보열람 시스템입니다.</p>
    <p style="font-family: 나눔바른고딕; font-size: large">열려라 국회, 우리가 사랑하는 정치인에서 아이디어를 얻었습니다. </p>
            
</div>

<div class="row">
    <div class="col-md-4" style="color: #000000">
        <h2 style="font-family: 나눔바른고딕">국회의원 찾기</h2>
        <p style="font-family: 나눔바른고딕">
            이름, 정당, 지역, 위원회, 당선횟수로 국회의원의 정보를 확인해보세요.

            국회의원의 정보를 찾고 원하는 코멘트를 남기실 수도 있습니다.
        </p>
       
    </div>
    <div class="col-md-4" style="color: #000000">
        <h2 style="font-family: 나눔바른고딕">의안 찾기</h2>
        <p style="font-family: 나눔바른고딕">
            
                의안을 검색을 통해 쉽게 알아보세요.

                21대 국회의 전체 의안과 제안일, 의안명, 발의자 정보, 진행상황까지 확인하실 수 있습니다.
        </p>
        
    </div>
    <div class="col-md-4" style="font-family: 나눔바른고딕; color: #000000;">
        <h2>정당</h2>
        <p>
            정당의 정보를 쉽게 확인해보세요.

            과거 13대 국회부터 정당의 변화를 그림으로 쉽게 확인하실 수 있습니다. 
        </p>
       
    </div>
</div>

    </body>
</asp:Content>