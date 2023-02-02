<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_TaoDeLuyenTap_Version2.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_TaoDeLuyenTap_Version2" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function CloseGridLookup() {
            lkChuong.ConfirmCurrentSelection();
            lkChuong.HideDropDown();
            //lkChuong.Focus();
        }
        function CloseGridLookupBai() {
            lkBai.ConfirmCurrentSelection();
            lkBai.HideDropDown();
            //lkBai.Focus();
        }
        function checkNULLBai() {
            var txtTenBai = document.getElementById('<%= txtTenBai.ClientID%>');
            var txtHinhThuc = document.getElementById('<%= txtHinhThucThi.ClientID%>').value;
            var txtTN_NB = document.getElementById('<%= txtTracNghiem_NhanBiet.ClientID%>').value;
            var txtTN_TH = document.getElementById('<%= txtTracNghiem_ThongHieu.ClientID%>').value;
            var txtTN_VD = document.getElementById('<%= txtTracNghiem_VanDung.ClientID%>').value;
            var txtTN_VDC = document.getElementById('<%= txtTracNghiem_VanDungCao.ClientID%>').value;
            var txtTL_NB = document.getElementById('<%= txtTuLuan_NhanBiet.ClientID%>').value;
            var txtTL_TH = document.getElementById('<%= txtTuLuan_ThongHieu.ClientID%>').value;
            var txtTL_VD = document.getElementById('<%= txtTuLuan_VanDung.ClientID%>').value;
            var txtTL_VDC = document.getElementById('<%= txtTuLuan_VanDungCao.ClientID%>').value;
            var txtDiem_TL_NB = document.getElementById('<%= txtTuLuan_Diem_NhanBiet.ClientID%>').value;
            var txtDiem_TL_TH = document.getElementById('<%= txtTuLuan_Diem_ThongHieu.ClientID%>').value;
            var txtDiem_TL_VD = document.getElementById('<%= txtTuLuan_Diem_VanDung.ClientID%>').value;
            var txtDiem_TL_VDC = document.getElementById('<%= txtTuLuan_Diem_VanDungCao.ClientID%>').value;
            var lkChuong = document.getElementById('<%= lkChuong.ClientID%>').text;
            var lkBai = document.getElementById('<%= lkBai.ClientID%>').text;

            if (txtTenBai.value.trim() == "") {
                swal('Tên bài học không được để trống!', '', 'warning').then(function () { txtTenBai.focus(); });
                return false;
            }
            if (lkChuong == "") {
                swal('Bạn chưa chọn chương!', '', 'warning');
                return false;
            }
            if (lkBai == "") {
                swal('Bạn chưa chọn bài!', '', 'warning');
                return false;
            }
            if (txtHinhThuc == "") {
                swal('Bạn chưa chọn hình thức thi!', '', 'warning');
                return false;
            }
            if (txtHinhThuc == "1" && txtTN_NB == "" && txtTN_TH == "" && txtTN_VD == "" && txtTN_VDC == "") {
                swal('Bạn chưa nhập ma trận đề trắc nghiệm!', '', 'warning');
                return false;
            }
            if (txtHinhThuc == "3" && txtTN_NB == "" && txtTN_TH == "" && txtTN_VD == "" && txtTN_VDC == "") {
                swal('Bạn chưa nhập ma trận đề trắc nghiệm!', '', 'warning');
                return false;
            }
            if (txtHinhThuc == "2" && txtTL_NB == "" && txtTL_TH == "" && txtTL_VD == "" && txtTL_VDC == "") {
                swal('Bạn chưa nhập ma trận đề tự luận!', '', 'warning');
                return false;
            }
            if (txtHinhThuc == "2" || txtHinhThuc == "3") {
                if (txtTL_NB != "" && txtDiem_TL_NB == "" || txtDiem_TL_NB == "0") {
                    swal('Bạn chưa nhập điểm tự luận nhận biết!', '', 'warning').then(function () { txtDiem_TL_NB.focus(); });
                    return false;
                }
                if (txtTL_TH != "" && txtDiem_TL_TH == "" || txtDiem_TL_TH == "0") {
                    swal('Bạn chưa nhập điểm tự luận thông hiểu!', '', 'warning').then(function () { txtDiem_TL_TH.focus(); });
                    return false;
                }
                if (txtTL_VD != "" && txtDiem_TL_VD == "" || txtDiem_TL_VD == "0") {
                    swal('Bạn chưa nhập điểm tự luận vận dụng!', '', 'warning').then(function () { txtDiem_TL_VD.focus(); });
                    return false;
                }
                if (txtTL_VDC != "" && txtDiem_TL_VDC == "" || txtDiem_TL_VDC == "0") {
                    swal('Bạn chưa nhập điểm tự luận vận dụng cao!', '', 'warning').then(function () { txtDiem_TL_VDC.focus(); });
                    return false;
                }
            }

            return true;
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode == 46 || (charCode > 47 && charCode < 58))
                return true; return false;
        }
    </script>
    <script>
        function myChange(id) {
            document.getElementById("<%=txtHinhThucThi.ClientID%>").value = id;
            if (id == 1) {
                document.getElementById("dv_TracNghiem").style.display = "block";
                document.getElementById("dv_TuLuan").style.display = "none";
            }
            if (id == 2) {
                document.getElementById("dv_TuLuan").style.display = "block";
                document.getElementById("dv_TracNghiem").style.display = "none";
            }
            if (id == 3) {
                document.getElementById("dv_TuLuan").style.display = "block";
                document.getElementById("dv_TracNghiem").style.display = "block";
                document.getElementById("div_LuuY").style.display = "block";
            }
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
    <div class="card card-block">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row header_header" style="margin-left: 200px">
                    <br />
                    <br />
                    <br />
                    <div class="col-sm-12">
                        <div class="col-12">
                            <label class="col-2 col-form-label">&nbsp;&nbsp;&nbsp;Tên bài:</label>
                            <div class="col-8">
                                <input type="text" class="form-control" id="txtTenBai" runat="server" />
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <%-- <div class="col-sm-4">
                            <asp:DropDownList ID="ddlChuong" runat="server" CssClass="btn btn-primary" AutoPostBack="true"></asp:DropDownList>
                        </div>--%>
                        <div class="col-sm-12">
                            <div class="col-sm-6">
                                <dx:ASPxGridLookup ID="lkChuong" runat="server" SelectionMode="Multiple" ClientInstanceName="lkChuong"
                                    KeyFieldName="chapter_id" Width="300px" TextFormatString="{0}" MultiTextSeparator=", " Caption="Chương">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                        <dx:GridViewDataColumn FieldName="chapter_name" Caption="Chương" Width="250px" />
                                        <dx:GridViewDataColumn FieldName="chapter_id" Settings-AllowAutoFilter="false" Visible="false" />
                                    </Columns>
                                    <GridViewProperties>
                                        <Templates>
                                            <StatusBar>
                                                <table class="OptionsTable" style="float: right">
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Chọn" ClientSideEvents-Click="CloseGridLookup" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StatusBar>
                                        </Templates>
                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                        <SettingsPager PageSize="10" EnableAdaptivity="true" />
                                    </GridViewProperties>
                                </dx:ASPxGridLookup>
                            </div>
                            <div class="col-sm-4">
                                <dx:ASPxGridLookup ID="lkBai" runat="server" SelectionMode="Multiple" ClientInstanceName="lkBai"
                                    KeyFieldName="lesson_id" Width="300px" TextFormatString="{0}" MultiTextSeparator=", " Caption="Bài">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" />
                                        <dx:GridViewDataColumn FieldName="lesson_id" Settings-AllowAutoFilter="false" Visible="false" />
                                        <dx:GridViewDataColumn FieldName="lesson_name" Caption="Bài" Width="250px" />
                                    </Columns>
                                    <GridViewProperties>
                                        <Templates>
                                            <StatusBar>
                                                <table class="OptionsTable" style="float: right;">
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Chọn" ClientSideEvents-Click="CloseGridLookupBai" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </StatusBar>
                                        </Templates>
                                        <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
                                        <SettingsPager PageSize="10" EnableAdaptivity="true" />
                                    </GridViewProperties>
                                </dx:ASPxGridLookup>
                            </div>
                        </div>
                    </div>
                    <div>
                        <input type="radio" id="html" name="fav_language" value="1" onchange="myChange(1)">
                        <label for="html">Trắc nghiệm</label><br>
                        <input type="radio" id="css" name="fav_language" value="2" onchange="myChange(2)">
                        <label for="css">Tự luận</label><br>
                        <input type="radio" id="javascript" name="fav_language" value="3" onchange="myChange(3)">
                        <label for="javascript">Cả 2</label>
                        <br />
                    </div>

                    <div id="dv_TracNghiem" style="display: none">
                        Tỉ lệ ma trận của đề thi :
                        <br />
                        Nhận biết :
                        <input type="text" id="txtTracNghiem_NhanBiet" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Thông hiểu :
                        <input type="text" id="txtTracNghiem_ThongHieu" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Vận dụng :
                        <input type="text" id="txtTracNghiem_VanDung" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Vận dung cao :
                        <input type="text" id="txtTracNghiem_VanDungCao" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Điểm mỗi câu :
                        <asp:DropDownList ID="ddlDiem" runat="server">
                            <asp:ListItem Value="5">0.2</asp:ListItem>
                            <asp:ListItem Value="4">0.25</asp:ListItem>
                            <asp:ListItem Value="2">0.5</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="div_LuuY" style="display: none; color: red">
                        (*)Tỉ lệ điểm ở các mức độ thuộc tự luận không được  vượt quá ma trận đề đã nhập ở phần trắc nghiệm 
                    </div>
                    <div id="dv_TuLuan" style="display: none">
                        Tự luận:
                        <br />
                        Điểm nhận biết
                        <input type="text" id="txtTuLuan_NhanBiet" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_NhanBiet" onkeypress="return isNumberKey(event)" value="0" onchange="fucnTongDiem()" runat="server" style="width: 30px" />
                        <br />
                        Điểm thông hiểu 
                        <input type="text" id="txtTuLuan_ThongHieu" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_ThongHieu" onkeypress="return isNumberKey(event)" value="0" onchange="fucnTongDiem()" runat="server" style="width: 30px" />
                        <br />
                        Điểm vận dụng 
                        <input type="text" id="txtTuLuan_VanDung" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_VanDung" onkeypress="return isNumberKey(event)" value="0" onchange="fucnTongDiem()" runat="server" style="width: 30px" />
                        <br />
                        Điểm vận dung cao 
                        <input type="text" id="txtTuLuan_VanDungCao" onkeypress="return isNumberKey(event)" runat="server" style="width: 30px" />
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_VanDungCao" onkeypress="return isNumberKey(event)" value="0" onchange="fucnTongDiem()" runat="server" style="width: 30px" />
                        <br />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <input style="display: none" id="txtHinhThucThi" type="text" runat="server" />
            <input style="display: none" id="txtLockInsert" value="0" type="text" runat="server" />
            <asp:Button Text="Tạo bài luyện tập" CssClass="btn btn-primary" OnClientClick="return checkNULLBai()" ID="btnLuu" runat="server" OnClick="btnLuu_Click" />
        </div>
        <h3>Đề luyện tập vừa tạo </h3>
        <div class="form-group row">
            <div class="col-sm-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                        <input type="submit" class="btn btn-primary Xoa btnFunction" value="Xóa" onclick="confirmDel()" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="form-group table-responsive">
                            <dx:ASPxGridView ID="grvDeLuyenTap" runat="server" Width="1200px" ClientInstanceName="grvDeLuyenTap" KeyFieldName="test_id">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="7%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                        <DataItemTemplate>
                                            <%#Container.ItemIndex+1 %>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Đề" FieldName="test_link" HeaderStyle-HorizontalAlign="Center"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ngày tạo" FieldName="test_createdate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Môn" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Người tạo" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" Width="7%" Settings-AllowEllipsisInText="true">
                                        <DataItemTemplate>
                                            <a href="/admin-de-luyen-tap-chi-tiet-<%#Eval("test_id") %>"  style="color: white" id="<%#Eval("test_id") %>"  class="btn btn-primary">Xem</a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                </Columns>
                                <%--<ClientSideEvents RowDblClick="btnChiTiet" />--%>
                                <SettingsSearchPanel Visible="true" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                <SettingsLoadingPanel Text="Đang tải..." />
                                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                            </dx:ASPxGridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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

