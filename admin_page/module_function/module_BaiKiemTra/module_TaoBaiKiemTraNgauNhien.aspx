<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_TaoBaiKiemTraNgauNhien.aspx.cs" Inherits="admin_page_module_function_module_BaiKiemTraTest_module_TaoBaiKiemTraNgauNhien" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script type="text/javascript">
        function CloseGridLookup() {
            lkChapter.ConfirmCurrentSelection();
            lkChapter.HideDropDown();
            lkChapter.Focus();
        }
    </script>
    <style>
        .header_header {
            height: 70px;
            border-bottom: 1px solid gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script>
        function confirmDel() {
            swal("Bạn có thực sự muốn tạo bài kiểm tra này?",
                "Nếu có, dữ liệu sẽ không thể thay đổi.",
                "warning",
                {
                    buttons: true,
                    successMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnLuu.ClientID%>');
                        xoa.click();
                    }
                });
        }
        function displayButton() {
            document.getElementById("txtLuu").style.display = "block"
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        };
        function checkNULL() {
            var CityName = document.getElementById('<%= txtSoCauHoi.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Vui lòng nhập số câu hỏi!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }
    </script>
    <div class="card card-block">
        <div class="row header_header">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="form-control" Style="outline: solid" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-sm-2">
                        <asp:DropDownList ID="ddlMon" runat="server" CssClass="form-control" Style="outline: solid" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3">
                        <dx:ASPxGridLookup ID="lkChapter" runat="server" SelectionMode="Multiple" ClientInstanceName="lkChapter"
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row mt-2">
            <asp:UpdatePanel ID="udButton" runat="server">
                <ContentTemplate>
                    <div class="row" style="margin: 0">
                        <div class="col-6">
                            <label class="col-3 col-form-label">Bài kiểm tra:</label>
                            <div class="col-6">
                                <input type="text" class="form-control" id="txtLoai" runat="server" placeholder="" />
                            </div>
                        </div>
                        <div class="col-6" runat="server" id="dvSoCauHoi">
                            <label class="col-2 col-form-label">Số câu hỏi:</label>
                            <div class="col-4">
                                <input type="text" class="form-control" id="txtSoCauHoi" runat="server" placeholder="" onkeypress="return isNumberKey(event)" />
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnTaoDe" runat="server" CssClass="btn btn-primary" OnClientClick="return checkNULL()" Text="Tạo đề" OnClick="btnTaoDe_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="form-group table-responsive">
                    <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="question_id" Width="100%">
                        <Columns>
                            <dx:GridViewDataColumn Caption="Câu" HeaderStyle-HorizontalAlign="Center" Width="2%">
                                <DataItemTemplate>
                                    <%#Container.ItemIndex+1 %>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="2%"></dx:GridViewCommandColumn>
                            <dx:GridViewDataColumn Caption="Chương" FieldName="chapter_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Nội dung câu hỏi" FieldName="question_content" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Loại câu hỏi" FieldName="question_type" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Người tạo" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                        </Columns>
                        <SettingsSearchPanel Visible="true" />
                        <SettingsBehavior AllowFocusedRow="true" />
                        <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                        <SettingsLoadingPanel Text="Đang tải..." />
                        <SettingsPager PageSize="50" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                    </dx:ASPxGridView>
                </div>
                <input type="submit" id="txtLuu" class="btn btn-primary" value="Lưu" onclick="confirmDel()" style="display: none" />
                <asp:Button ID="btnLuu" runat="server" CssClass="invisible" OnClick="btnLuu_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

