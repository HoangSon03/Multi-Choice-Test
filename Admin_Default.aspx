<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div id="container">
        <div class="card card-block">
            <br />
            <br />
            <br />
            <div style="text-align: center">
                <div>
                    <div class="form-group row">
                        <div class="col-sm-10 ">
                            <div class="main" id="main_content">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div style="display: flex; margin-left: 100px">
                                            <b>Chọn khối</b>
                                            <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true" Width="150px"></asp:DropDownList>
                                            <b>Chọn môn</b>
                                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true" Width="150px"></asp:DropDownList>
                                            <b>Chủ đề</b>
                                            <asp:DropDownList ID="ddlChuDe" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlChuDe_SelectedIndexChanged" AutoPostBack="true" Width="150px"></asp:DropDownList>
                                            <b>Chọn Bài</b>
                                            <%-- Ghi chú: các bài là tbTracNghiem_Lesson--%>
                                            <asp:DropDownList ID="ddlBai" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlBai_SelectedIndexChanged" AutoPostBack="true" Width="250px"></asp:DropDownList>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <div style="margin-left: 100px">
                                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnThemChuDe" runat="server" Text="Thêm chủ đề" OnClick="btnThemChuDe_ServerClick" CssClass="btn btn-primary" />
                                            <asp:Button ID="btnThemBai" runat="server" Text="Thêm bài" OnClick="btnThemBai_Click" Height="40px" CssClass="btn btn-primary" />
                                              <asp:Button ID="btnThemDacTa" runat="server" Text="Thêm đặc tả" OnClick="btnThemDacTa_Click" Height="40px" CssClass="btn btn-primary" />
                                            <a href="#" id="btnThemCauHoiTracNghiem" runat="server" class="btn btn-primary" onserverclick="btnThemCauHoiTracNghiem_ServerClick">Nhập kho dữ liệu trắc nghiệm</a>
                                            <a href="#" id="btnThemCauHoiTuLuan" runat="server" class="btn btn-primary" onserverclick="btnThemCauHoiTuLuan_ServerClick">Nhập kho dữ liệu tự luận</a>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                </div>
                            </div>
                            <dx:ASPxPopupControl ID="popupControl" runat="server" Width="460px" Height="180px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
                                HeaderText="Thêm chủ đề" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
                                <ContentCollection>
                                    <dx:PopupControlContentControl runat="server">
                                        <asp:UpdatePanel ID="udPopup" runat="server">
                                            <ContentTemplate>
                                                <div class="popup-main">
                                                    <div>
                                                        <asp:TextBox ID="txtTenChuDe" runat="server" ClientIDMode="Static" CssClass="form-control" Width="400px"> </asp:TextBox>
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
                            <dx:ASPxPopupControl ID="popupThemBai" runat="server" Width="460px" Height="180px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupThemBai" ShowFooter="true"
                                HeaderText="Thêm bài" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
                                <ContentCollection>
                                    <dx:PopupControlContentControl runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="popup-main">
                                                    <div>
                                                        <asp:TextBox ID="txtTenBai" runat="server" ClientIDMode="Static" CssClass="form-control" Width="400px"> </asp:TextBox>
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
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

