<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PoliticInform._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
    <p aria-atomic="False">환영합니다. 이곳은 국회의원 정보 확인을 위한 페이지입니다. </p>
    <p class="lead">
        참여연대 의정감시센터가 만들어 운영하는 국회 모니터링 전문사이트입니다.
    </p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <h2>국회의원 찾기</h2>
        <p>
            이름, 정당, 지역, 위원회, 성별, 연령, 당선횟수로 국회의원의 정보를 확인해보세요.

            국회의원의 정보를 찾고 원하는 코멘트를 남기실 수도 있습니다.
        </p>
       
    </div>
    <div class="col-md-4">
        <h2>의안 찾기</h2>
        <p>
            
                의안을 검색을 통해 쉽게 알아보세요.

                21대 국회의 전체 의안과 제안일, 의안명, 발의자 정보, 진행상황까지 확인하실 수 있습니다.
        </p>
        
    </div>
    <div class="col-md-4">
        <h2>정당</h2>
        <p>
            정당의 정보를 쉽게 확인해보세요.

            과거 13대 국회부터 정당의 변화를 그림으로 쉽게 확인하실 수 있습니다. 
        </p>
       
    </div>
</div>
</asp:Content>
