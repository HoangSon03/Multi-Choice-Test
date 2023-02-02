<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_QuanLyCauHoiTracNghiem.aspx.cs" Inherits="admin_page_module_function_module_TracNghiem_module_QuanLyCauHoiTracNghiem" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrator</title>
    <link rel="stylesheet" href="/admin_css/vendor.css" />
    <link rel="stylesheet" href="/admin_css/app-blue.css" />
    <link href="/admin_css/admin_style.css" rel="stylesheet" />
    <link href="/admin_css/datepicker.min.css" rel="stylesheet" />
    <script src="/admin_js/sweetalert.min.js"></script>
    <script src="/admin_js/js_base/jquery-1.9.1.js"></script>
    <link href="../../../admin_css/Loading.css" rel="stylesheet" />
</head>
<body>
    <style>
        .header_header {
            height: 70px;
            border-bottom: 1px solid gray;
        }

        .radio_text_type {
            margin-right: 3px;
            margin-left: 20px;
        }

        .question_radio {
            margin-top: 10px;
            font-size: 16px;
            display: -webkit-inline-box;
        }

        .file {
            margin-top: 40px;
        }

        .title_h2 {
            font-size: 19px;
            margin-bottom: 0;
        }

        .title_h2_c {
            margin-top: 10px;
            font-size: 19px;
            margin-bottom: 0;
        }

        .title_them_question {
            text-align: center;
        }

        .button_quaylai them_chuong {
            float: right;
        }

        .button_quaylai {
            float: right;
        }

        .tracnghiem-answer__image {
            max-width: 100%;
            height: 217px;
            width: auto;
            display: block;
            margin: 0 auto;
            margin-bottom: 21px;
            border-radius: 10px;
            border: 1px solid #ccc;
            box-shadow: 0 7px 10px rgba(0,0,0,0.3);
        }

        .content_image {
            white-space: break-spaces;
        }

        .invisible {
            position: absolute;
        }

        .btnFunction {
            margin-right: 8px;
        }

        .widthContent {
            /*max-width: 980px;
            display: flex;*/
        }

        #ctl10 {
            position: relative;
        }

        .textContent {
            /*position: absolute;*/
            /* bottom: -28px; */
            /*    top: -48px;
            left: 16px;*/
            font-size: 1.2rem;
            color: red;
        }

        #edtContent_DesignIFrame {
            width: 400px !important;
            height: 377px !important;
        }

        .title_h2_c {
            margin: 12px 0;
        }

        .marginFooter {
            margin: 8px 15px;
            max-width: 980px;
        }

        .title_h2_c-active {
            color: red;
            font-size: 1.6rem;
            font-weight: 500;
        }

        .btn-primary:focus {
            outline: none;
        }

        input type[checkbox] {
            height: 25px;
            width: 25px;
        }
    </style>
    <form id="form1" runat="server">
        <div class="loading" id="img-loading-icon" style="display: none">
            <div class="loading">Loading&#8230;</div>
        </div>
        <asp:ScriptManager ID="smScriptManager" runat="server"></asp:ScriptManager>
        <script>
            //document.onreadystatechange = function () {
            //    var state = document.readyState;
            //    console.log(state);
            //    if (state != 'complete') {
            //        $("#img-loading-icon").show();
            //    } else {
            //        $("#img-loading-icon").hide();
            //    }
            //}

            function btnChiTiet() {
                document.getElementById('<%=btnChiTiet.ClientID%>').click();
            }
            function setForm() {
                var a = document.querySelector('input[name="kieucauhoi"]:checked').value;
                document.getElementById("<%=txtKieuCauHoi.ClientID%>").value = a;
                if (a == 2) {
                    document.getElementById("dvnoidungcauhoi").style.display = "none";
                }
                else {
                    document.getElementById("dvnoidungcauhoi").style.display = "block";
                }
                console.log(a);
            }
            $(document).ready(function () {
                setForm();
                getquestion();
            });
            function getquestion() {
                var a = document.querySelector('input[name="loaicauhoi"]:checked').value;
                document.getElementById("<%=txtLoaiCauHoi.ClientID%>").value = a;
                console.log("getquestion:" + a);
            }
            function setCheckedDCH() {
                var value = document.getElementById("<%=txtKieuCauHoi.ClientID%>").value;
                $("input[name=kieucauhoi][value=" + value + "]").attr('checked', 'checked');
                console.log("kieucauhoi:" + value)
            }
            function setChecked() {
                var value = document.getElementById("<%=txtLoaiCauHoi.ClientID%>").value;
                $("input[name=loaicauhoi][value=" + value + "]").attr('checked', 'checked');
                console.log("Mức độ:" + value)
            }
            function confirmDel() {
                swal("Bạn có thực sự muốn xóa?",
                    "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                    "warning",
                    {
                        buttons: true,
                        dangerMode: true
                    }).then(function (value) {
                        if (value == true) {
                            var xoa = document.getElementById('<%=btnXoa.ClientID%>');
                            xoa.click();
                        }
                    });
            }
            function clickavatar1() {
                $("#up1 input[type=file]").click();
            }
            function showPreview1(input) {
                if (input.files && input.files[0]) {

                    var filerdr = new FileReader();
                    filerdr.onload = function (e) {

                        $('#imgPreview1').attr('src', e.target.result);
                    }
                    filerdr.readAsDataURL(input.files[0]);
                }
            }
            function showImg1_1(img) {
                $('#imgPreview1').attr('src', img);
                $('#imgPreview2').attr('src', img);
                $("input[type=checkbox]").css("display", "block");
            }
            function lockImg() {
                $('#imgPreview1').css("display", "none");
                $('#audio').css("display", "block");
            }
            function lockAudio() {
                $('#audio').css("display", "none");
                $('#imgPreview1').css("display", "block");
            }
            function lockDCH() {
                $('#DangCauHoi_').css("position", "absolute");
                $('#DangCauHoi_').css("top", "45%");
                $('#DangCauHoi_').css("left", "0");
            }
        </script>
        <div class="card card-block">
            <div class="form-group row">
                <div class="col-sm-6">
                    <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary btnFunction" OnClick="btnChiTiet_Click" />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                            <input type="submit" class="btn btn-primary Xoa btnFunction" value="Xóa" onclick="confirmDel()" />

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:Button ID="btnTaiLaiTrang" Text="Tải lại trang" CssClass="btn btn-primary btnFunction" runat="server" OnClick="btnTaiLaiTrang_Click" />
                    <asp:Button ID="btnNhapExcel" Text="Nhập file Excel" CssClass="btn btn-primary btnFunction" runat="server" OnClick="btnNhapExcel_Click" />
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </div>
                <div style="text-align: right">
                    <asp:Button ID="btnQuayLai" Text="Quay lại" CssClass="btn btn-primary" runat="server" OnClick="btnQuayLai_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-sm-12">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group table-responsive">
                                <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="question_id">
                                    <Columns>
                                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="7%">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                            <DataItemTemplate>
                                                <%#Container.ItemIndex+1 %>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Bài học" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Nội dung câu hỏi" FieldName="question_content" HeaderStyle-HorizontalAlign="Center" Width="30%" Settings-AllowEllipsisInText="true">
                                            <DataItemTemplate>
                                                <div>
                                                    <%#Eval("question_content") %>
                                                </div>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Loại CH" FieldName="question_level" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Dạng CH" FieldName="question_dangcauhoi" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                        <%--<dx:GridViewDataColumn Caption="Giáo viên" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>--%>
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
            <div class="row mb-2">
                <div class="col-sm-12">
                    <div style="display: none">
                        <input type="text" id="txtKieuCauHoi" placeholder="txtKieuCauHoi" runat="server" />
                    </div>
                    <div class="col-sm-12">
                        <h1 class="title_them_question">Thêm câu hỏi</h1>
                    </div>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-sm-4 question_radio" id="DangCauHoi_">
                                    <h2 class="title_h2">Kiểu câu hỏi:</h2>
                                    <input class="radio_text_type" type="radio" id="type1" name="kieucauhoi" value="1" onclick="setForm()" />Text + Image 
                                <input class="radio_text_type" type="radio" id="type2" name="kieucauhoi" value="2" onclick="setForm()" />Video 
                                </div>


                                <div class="col-sm-4 question_radio">
                                    <h2 class="title_h2">Mức độ:</h2>
                                    <input class="radio_text_type" type="radio" id="21" name="loaicauhoi" value="Dễ" onclick="getquestion()" />Dễ
                                    <input class="radio_text_type" type="radio" id="22" name="loaicauhoi" value="Vừa" onclick="getquestion()" />Vừa 
                                    <input class="radio_text_type" type="radio" id="34" name="loaicauhoi" value="Khó" onclick="getquestion()" />Khó 
                                </div>
                            </div>
                            <input hidden="hidden" type="text" value="" runat="server" id="txtLoaiCauHoi" placeholder="loại câu hỏi" />
                            <div class="row">
                                <div class="col-sm-3">
                                    <div>
                                        <div class="colum-5 form-group">
                                            <div id="up1" class="">
                                                <asp:FileUpload CssClass="hidden-xs-up" ID="FileUpload1" runat="server" onchange="showPreview1(this)" accept=".png,.jpg,.mp3" />
                                                <button type="button" class="btn-chang" onclick="clickavatar1()">
                                                    <img id="imgPreview1" src="/admin_images/up-img.png" style="max-width: 100%; height: 200px" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 widthContent">
                    <span class="textContent">Lưu ý: - Bạn cần nhập nội dung đáp án theo thứ tự A,B,C,D</span>
                    <span class="textContent">- Chỉ chọn 1 đáp án đúng </span>

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="col-sm-12 question_radio">
                                <h2 class="title_h2 mr-2">Dạng câu hỏi:</h2>
                                <asp:DropDownList runat="server" ID="ddlLoaiCauHoi" OnSelectedIndexChanged="ddlLoaiCauHoi_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Chọn dạng" Value="" Selected="True" Enabled="true" />
                                    <asp:ListItem Text="Nhận biết" Value="Nhận biết" />
                                    <asp:ListItem Text="Thông hiểu" Value="Thông hiểu" />
                                    <asp:ListItem Text="Vận dụng" Value="Vận dụng" />
                                    <asp:ListItem Text="Vận dụng cao" Value="Vận dụng cao" />
                                </asp:DropDownList>
                                <h2 class="title_h2 mr-2">Đặc tả:</h2>
                                <asp:DropDownList runat="server" ID="ddlDacTa">
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-4">
                                <div id="dvnoidungcauhoi">
                                    <h2 class="title_h2_c">Nội dung câu hỏi:</h2>
                                    <dx:ASPxHtmlEditor ID="edtContent" ClientInstanceName="edtContent" runat="server" Width="100%" Height="130px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                        <SettingsHtmlEditing EnablePasteOptions="true" />
                                        <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                        <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                        <Toolbars>
                                            <dx:HtmlEditorToolbar>
                                                <Items>
                                                    <dx:ToolbarFontSizeEdit>
                                                        <Items>
                                                            <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                            <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                        </Items>
                                                    </dx:ToolbarFontSizeEdit>
                                                    <dx:ToolbarBoldButton BeginGroup="True" />
                                                    <dx:ToolbarItalicButton />
                                                    <dx:ToolbarUnderlineButton />
                                                    <dx:ToolbarStrikethroughButton />
                                                    <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                    <dx:ToolbarJustifyCenterButton />
                                                    <dx:ToolbarJustifyRightButton />
                                                    <dx:ToolbarJustifyFullButton />
                                                    <dx:ToolbarBackColorButton BeginGroup="True" />
                                                    <dx:ToolbarFontColorButton />
                                                </Items>
                                            </dx:HtmlEditorToolbar>
                                        </Toolbars>
                                    </dx:ASPxHtmlEditor>
                                    <%--<textarea runat="server" id="txtcontent" name="w3review" rows="2" class="form-control"></textarea>--%>
                                </div>
                            </div>
                            <div class="col-sm-8">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h2 class="title_h2_c">Câu A:<input type="checkbox" id="DaA" runat="server" /></h2>
                                        <dx:ASPxHtmlEditor ID="edtDapAnA" ClientInstanceName="edtDapAnA" runat="server" Width="100%" Height="300px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                            <SettingsHtmlEditing EnablePasteOptions="true" />
                                            <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                            <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                            <Toolbars>
                                                <dx:HtmlEditorToolbar>
                                                    <Items>
                                                        <dx:ToolbarFontSizeEdit>
                                                            <Items>
                                                                <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                            </Items>
                                                        </dx:ToolbarFontSizeEdit>
                                                        <dx:ToolbarBoldButton BeginGroup="True" />
                                                        <dx:ToolbarItalicButton />
                                                        <dx:ToolbarUnderlineButton />
                                                        <dx:ToolbarStrikethroughButton />
                                                        <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                        <dx:ToolbarJustifyCenterButton />
                                                        <dx:ToolbarJustifyRightButton />
                                                        <dx:ToolbarJustifyFullButton />
                                                        <dx:ToolbarBackColorButton BeginGroup="True" />
                                                        <dx:ToolbarFontColorButton />
                                                    </Items>
                                                </dx:HtmlEditorToolbar>

                                            </Toolbars>
                                        </dx:ASPxHtmlEditor>
                                    </div>
                                    <div class="col-sm-6">
                                        <h2 class="title_h2_c">Câu B:
                                            <input type="checkbox" id="DaB" runat="server" /></h2>
                                        <dx:ASPxHtmlEditor ID="edtDapAnB" ClientInstanceName="edtDapAnB" runat="server" Width="100%" Height="300px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                            <SettingsHtmlEditing EnablePasteOptions="true" />
                                            <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                            <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                            <Toolbars>
                                                <dx:HtmlEditorToolbar>
                                                    <Items>
                                                        <dx:ToolbarFontSizeEdit>
                                                            <Items>
                                                                <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                            </Items>
                                                        </dx:ToolbarFontSizeEdit>
                                                        <dx:ToolbarBoldButton BeginGroup="True" />
                                                        <dx:ToolbarItalicButton />
                                                        <dx:ToolbarUnderlineButton />
                                                        <dx:ToolbarStrikethroughButton />
                                                        <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                        <dx:ToolbarJustifyCenterButton />
                                                        <dx:ToolbarJustifyRightButton />
                                                        <dx:ToolbarJustifyFullButton />
                                                        <dx:ToolbarBackColorButton BeginGroup="True" />
                                                        <dx:ToolbarFontColorButton />
                                                    </Items>
                                                </dx:HtmlEditorToolbar>
                                            </Toolbars>
                                        </dx:ASPxHtmlEditor>
                                    </div>
                                    <div class="col-sm-6">
                                        <h2 class="title_h2_c">Câu C:
                                            <input type="checkbox" id="DaC" runat="server" /></h2>
                                        <dx:ASPxHtmlEditor ID="edtDapAnC" ClientInstanceName="edtDapAnC" runat="server" Width="100%" Height="300px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                            <SettingsHtmlEditing EnablePasteOptions="true" />
                                            <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                            <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                            <Toolbars>
                                                <dx:HtmlEditorToolbar>
                                                    <Items>
                                                        <dx:ToolbarFontSizeEdit>
                                                            <Items>
                                                                <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                            </Items>
                                                        </dx:ToolbarFontSizeEdit>
                                                        <dx:ToolbarBoldButton BeginGroup="True" />
                                                        <dx:ToolbarItalicButton />
                                                        <dx:ToolbarUnderlineButton />
                                                        <dx:ToolbarStrikethroughButton />
                                                        <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                        <dx:ToolbarJustifyCenterButton />
                                                        <dx:ToolbarJustifyRightButton />
                                                        <dx:ToolbarJustifyFullButton />
                                                        <dx:ToolbarBackColorButton BeginGroup="True" />
                                                        <dx:ToolbarFontColorButton />
                                                    </Items>
                                                </dx:HtmlEditorToolbar>
                                            </Toolbars>
                                        </dx:ASPxHtmlEditor>
                                    </div>
                                    <div class="col-sm-6">
                                        <h2 class="title_h2_c">Câu D:
                                            <input type="checkbox" id="DaD" runat="server" /></h2>
                                        <dx:ASPxHtmlEditor ID="edtDapAnD" ClientInstanceName="edtDapAnD" runat="server" Width="100%" Height="300px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                            <SettingsHtmlEditing EnablePasteOptions="true" />
                                            <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                            <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                            <Toolbars>
                                                <dx:HtmlEditorToolbar>
                                                    <Items>
                                                        <dx:ToolbarFontSizeEdit>
                                                            <Items>
                                                                <dx:ToolbarListEditItem Value="1" Text="1 (8pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="2" Text="2 (10pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="3" Text="3 (12pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="4" Text="4 (14pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="5" Text="5 (18pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="6" Text="6 (24pt)"></dx:ToolbarListEditItem>
                                                                <dx:ToolbarListEditItem Value="7" Text="7 (36pt)"></dx:ToolbarListEditItem>
                                                            </Items>
                                                        </dx:ToolbarFontSizeEdit>
                                                        <dx:ToolbarBoldButton BeginGroup="True" />
                                                        <dx:ToolbarItalicButton />
                                                        <dx:ToolbarUnderlineButton />
                                                        <dx:ToolbarStrikethroughButton />
                                                        <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                        <dx:ToolbarJustifyCenterButton />
                                                        <dx:ToolbarJustifyRightButton />
                                                        <dx:ToolbarJustifyFullButton />
                                                        <dx:ToolbarBackColorButton BeginGroup="True" />
                                                        <dx:ToolbarFontColorButton />
                                                    </Items>
                                                </dx:HtmlEditorToolbar>
                                            </Toolbars>
                                        </dx:ASPxHtmlEditor>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="col-sm-12 marginFooter">
                                    <h2 class="title_h2_c title_h2_c-active">Giải thích đáp án:
                                    </h2>
                                    <dx:ASPxHtmlEditor ID="edtGiaiThich" ClientInstanceName="edtGiaiThich" runat="server" Width="100%" Height="200px" Border-BorderStyle="Solid" Border-BorderWidth="1px" Border-BorderColor="#dddddd">
                                        <SettingsHtmlEditing EnablePasteOptions="true" />
                                        <Settings AllowHtmlView="true" AllowContextMenu="Default" />
                                        <settingsimageupload uploadfolder="~/editorimages"></settingsimageupload>
                                        <Toolbars>
                                            <dx:HtmlEditorToolbar>
                                                <Items>
                                                    <dx:ToolbarBoldButton BeginGroup="True" />
                                                    <dx:ToolbarItalicButton />
                                                    <dx:ToolbarUnderlineButton />
                                                    <dx:ToolbarStrikethroughButton />
                                                    <dx:ToolbarJustifyLeftButton BeginGroup="True" />
                                                    <dx:ToolbarJustifyCenterButton />
                                                    <dx:ToolbarJustifyRightButton />
                                                    <dx:ToolbarJustifyFullButton />
                                                    <dx:ToolbarBackColorButton BeginGroup="True" />
                                                    <dx:ToolbarFontColorButton />
                                                </Items>
                                            </dx:HtmlEditorToolbar>
                                        </Toolbars>
                                    </dx:ASPxHtmlEditor>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row mt-2">
                        <div class="col-sm-7">
                            <asp:Button ID="btnLuu" type="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary " OnClick="btnLuu_Click" />
                            <asp:Button ID="btnLuuvaThemmoi" runat="server" Text="Lưu và thêm mới" CssClass="btn btn-primary" OnClick="btnLuuvaThemmoi_Click1" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
