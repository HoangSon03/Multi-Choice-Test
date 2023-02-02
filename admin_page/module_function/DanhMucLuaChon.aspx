<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucLuaChon.aspx.cs" Inherits="admin_page_module_function_DanhMucLuaChon" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <style>
        @import url("https://fonts.googleapis.com/css?family=Lato:400,700");

        html {
            display: grid;
            min-height: 100%;
        }

        body {
            display: grid;
            overflow: hidden;
            font-family: "Lato", sans-serif;
            text-transform: uppercase;
            text-align: center;
        }

        #container {
            position: relative;
            margin: auto;
            overflow: hidden;
            width: 700px;
            height: 250px;
        }

        h1 {
            font-size: 0.9em;
            font-weight: 100;
            letter-spacing: 3px;
            padding-top: 5px;
            color: #fcfcfc;
            padding-bottom: 5px;
            text-transform: uppercase;
        }

        .green {
            color: #4ec07d;
        }

        .red {
            color: #e96075;
        }

        .alert {
            font-weight: 700;
            letter-spacing: 5px;
        }

        p {
            margin-top: -5px;
            font-size: 0.5em;
            font-weight: 100;
            color: #5e5e5e;
            letter-spacing: 1px;
        }

        button,
        .dot {
            cursor: pointer;
        }

        #success-box {
            position: absolute;
            width: 35%;
            height: 100%;
            left: 12%;
            background: linear-gradient(to bottom right, #b0db7d 40%, #99dbb4 100%);
            border-radius: 20px;
            box-shadow: 5px 5px 20px rgba(203, 205, 211, 0.1);
            perspective: 40px;
        }

        #error-box {
            position: absolute;
            width: 35%;
            height: 100%;
            right: 27%;
            background: linear-gradient(to bottom left, #ef8d9c 40%, #ffc39e 100%);
            border-radius: 20px;
            box-shadow: 5px 5px 20px rgba(203, 205, 211, 0.1);
        }

        .dot {
            width: 8px;
            height: 8px;
            background: #fcfcfc;
            border-radius: 50%;
            position: absolute;
            top: 4%;
            right: 6%;
        }

            .dot:hover {
                background: #c9c9c9;
            }

        .two {
            right: 12%;
            opacity: 0.5;
        }

        .face {
            position: absolute;
            width: 22%;
            height: 22%;
            background: #fcfcfc;
            border-radius: 50%;
            border: 1px solid #777777;
            top: 21%;
            left: 37.5%;
            z-index: 2;
            animation: bounce 1s ease-in infinite;
        }

        .face2 {
            position: absolute;
            width: 22%;
            height: 22%;
            background: #fcfcfc;
            border-radius: 50%;
            border: 1px solid #777777;
            top: 21%;
            left: 37.5%;
            z-index: 2;
            animation: roll 3s ease-in-out infinite;
        }

        .eye {
            position: absolute;
            width: 5px;
            height: 5px;
            background: #777777;
            border-radius: 50%;
            top: 40%;
            left: 20%;
        }

        .right {
            left: 68%;
        }

        .mouth {
            position: absolute;
            top: 43%;
            left: 41%;
            width: 7px;
            height: 7px;
            border-radius: 50%;
        }

        .happy {
            border: 2px solid;
            border-color: transparent #777777 #777777 transparent;
            transform: rotate(45deg);
        }

        .sad {
            top: 49%;
            border: 2px solid;
            border-color: #777777 transparent transparent #777777;
            transform: rotate(45deg);
        }

        .shadow {
            position: absolute;
            width: 21%;
            height: 3%;
            opacity: 0.5;
            background: #777777;
            left: 40%;
            top: 43%;
            border-radius: 50%;
            z-index: 1;
        }

        .scale {
            animation: scale 1s ease-in infinite;
        }

        .move {
            animation: move 3s ease-in-out infinite;
        }

        .message {
            position: absolute;
            width: 100%;
            text-align: center;
            height: 40%;
            top: 47%;
        }

        .button-box {
            position: absolute;
            background: #fcfcfc;
            width: 50%;
            height: 15%;
            border-radius: 20px;
            top: 73%;
            left: 25%;
            outline: 0;
            border: none;
            box-shadow: 2px 2px 10px rgba(119, 119, 119, 0.5);
            transition: all 0.5s ease-in-out;
        }

            .button-box:hover {
                background: #efefef;
                transform: scale(1.05);
                transition: all 0.3s ease-in-out;
            }

        @keyframes bounce {
            50% {
                transform: translateY(-10px);
            }
        }

        @keyframes scale {
            50% {
                transform: scale(0.9);
            }
        }

        @keyframes roll {
            0% {
                transform: rotate(0deg);
                left: 25%;
            }

            50% {
                left: 60%;
                transform: rotate(168deg);
            }

            100% {
                transform: rotate(0deg);
                left: 25%;
            }
        }

        @keyframes move {
            0% {
                left: 25%;
            }

            50% {
                left: 60%;
            }

            100% {
                left: 25%;
            }
        }

        footer {
            position: absolute;
            bottom: 0;
            right: 0;
            text-align: center;
            font-size: 1em;
            text-transform: uppercase;
            padding: 10px;
            font-family: "Lato", sans-serif;
        }

            footer p {
                color: #ef8d9c;
                letter-spacing: 2px;
            }

            footer a {
                color: #b0db7d;
                text-decoration: none;
            }

                footer a:hover {
                    color: #ffc39e;
                }
    </style>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/moment.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        function func() {
            popupThemBai.Hide();
            popupControl.Hide();

        }
        function showError() {
            document.getElementById("container").style.display = 'block';
            document.getElementById("main_content").style.display = 'none';

        }
        function checkcbb() {
            if (document.getElementById("<%=ddlMon.ClientID%>").Text != "Chọn môn" && document.getElementById("<%=ddlKhoi.ClientID%>").Text != "Chọn khối") {

            }
            else {
                document.getElementById("<%=ddlMon.ClientID%>").disabled = true;
                document.getElementById("<%=ddlKhoi.ClientID%>").disabled = true;
            }
        }
        function checkNull() {

            var chude = document.getElementById("<%=txtTenChuDe.ClientID%>");
            if (chude.value.trim() == "") {
                swal('Vui lòng nhập chủ đề!', '', 'warning').then(function () { chude.focus(); });
                return false;
            }
            return true;
        } function checkThemBai() {

            var bai = document.getElementById("<%=txtTenBai.ClientID%>");
            if (bai.value.trim() == "") {
                swal('Vui lòng nhập tên bài!', '', 'warning').then(function () { bai.focus(); });
                return false;
            }
            return true;
        }

    </script>

    <div class="card card-block">
        <h3 style="text-align: center; font-size: 28px; font-weight: bold; color: blue">Thêm CHỦ ĐỀ, BÀI</h3>
        <div style="display: flex; flex-direction: row;">
            <div>
                <p style="color: red; font-size: 12px; padding-right: 84%">*Chú ý</p>
                <p style="font-size: 10px;">-Giáo viên tạo khối,môn trước khi thêm chủ đề, bài</p>
            </div>
        </div>
        <div>
            <div class="form-group row">
                <div class="col-sm-10 ">
                    <div class="main" id="main_content">
                        <div style="display: flex;">
                            <span style="padding-top: 5px;">Chọn khối</span>
                            <span style="padding: 0 2px;"></span>
                            <asp:DropDownList ID="ddlKhoi" runat="server" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true" Height="30px" Width="150px"></asp:DropDownList>
                            <span style="padding: 0 1%;"></span>
                            <span style="padding-top: 5px;">Chọn môn</span>
                            <span style="padding: 0 2px;"></span>
                            <asp:DropDownList ID="ddlMon" runat="server" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true" Height="30px" Width="150px"></asp:DropDownList>
                            <br />
                            <br />
                        </div>
                        <div style="display: flex; align-items: center;">
                            <span>Chủ đề</span>
                            <span style="padding: 16px"></span>
                            <asp:DropDownList ID="ddlChuDe" runat="server" OnSelectedIndexChanged="ddlChuDe_SelectedIndexChanged" AutoPostBack="true" Height="30px" Width="150px"></asp:DropDownList>
                            <span style="padding: 0 1%;"></span>
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="Button1" runat="server" Text="Thêm chủ đề" OnClick="btnThemChuDe_ServerClick" Height="40px" CssClass="btn btn-primary float-sm-right" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <br />
                        <div style="display: flex; align-items: center;">
                            <span>Bài</span>
                            <span style="padding: 32px;"></span>
                            <%-- Ghi chú: các bài là tbTracNghiem_Lesson--%>
                            <asp:DropDownList ID="ddlBai" runat="server" OnSelectedIndexChanged="ddlBai_SelectedIndexChanged" AutoPostBack="true" Height="30px" Width="150px"></asp:DropDownList>
                            <span style="padding: 0 1%;"></span>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnThemBai" runat="server" Text="Thêm bài" OnClick="btnThemBai_Click" Height="40px" CssClass="btn btn-primary float-sm-right" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                        </div>

                    </div>

                    <%--<a href="#" id="btnThemCauHoiTracNghiem" runat="server" onserverclick="btnThemCauHoiTracNghiem_ServerClick">Nhập kho dữ liệu trắc nghiệm</a>
                <br />
                <a href="#" id="btnThemCauHoiTuLuan" runat="server" onserverclick="btnThemCauHoiTuLuan_ServerClick">Nhập kho dữ liệu tự luận</a>--%>
                    <br />
                    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="400" Height="300" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
                        HeaderText="Thêm chủ đề" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
                        <ContentCollection>
                            <dx:PopupControlContentControl runat="server">
                                <asp:UpdatePanel ID="udPopup" runat="server">
                                    <ContentTemplate>
                                        <div class="popup-main">
                                            <div class="div_content col-12">
                                                <div class="col-12 form-group">
                                                    <label class="col-2 form-control-label">Chủ đề :</label>
                                                    <div class="col-10">
                                                        <asp:TextBox ID="txtTenChuDe" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="50%"> </asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                        <FooterContentTemplate>
                            <div class="mar_but button">
                                <asp:UpdatePanel ID="udSave" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnLuu" runat="server" ClientIDMode="Static" Text="Luu" CssClass="btn btn-primary" OnClientClick="return checkNull()" OnClick="btnLuu_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </FooterContentTemplate>
                        <ContentStyle>
                            <Paddings PaddingBottom="0px" />
                        </ContentStyle>
                    </dx:ASPxPopupControl>
                    <dx:ASPxPopupControl ID="popupThemBai" runat="server" Width="400" Height="300" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupThemBai" ShowFooter="true"
                        HeaderText="Thêm bài" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
                        <ContentCollection>
                            <dx:PopupControlContentControl runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="popup-main">
                                            <div class="div_content col-12">
                                                <div class="col-12 form-group">
                                                    <label class="col-2 form-control-label">Thêm bài :</label>
                                                    <div class="col-10">
                                                        <asp:TextBox ID="txtTenBai" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="50%"> </asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                        <FooterContentTemplate>
                            <div class="mar_but button">
                                <asp:UpdatePanel ID="udSave" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnLuuBai" runat="server" ClientIDMode="Static" Text="Luu" CssClass="btn btn-primary" OnClientClick="return checkThemBai()" OnClick="btnLuuBai_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </FooterContentTemplate>
                        <ContentStyle>
                            <Paddings PaddingBottom="0px" />
                        </ContentStyle>
                    </dx:ASPxPopupControl>
                </div>
            </div>
        </div>
    </div>
    <%--  --%>
    <div id="container" style="display: none">
        <div id="error-box">
            <div class="dot"></div>
            <div class="dot two"></div>
            <div class="face2">
                <div class="eye"></div>
                <div class="eye right"></div>
                <div class="mouth sad"></div>
            </div>
            <div class="shadow move"></div>
            <div class="message">
                <h1 class="alert">Error!</h1>
                <p>
                oh no, something went wrong.
            </div>
            <button class="button-box">
                <h1 class="red">try again</h1>
            </button>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

