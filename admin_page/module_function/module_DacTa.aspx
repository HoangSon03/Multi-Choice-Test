<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DacTa.aspx.cs" Inherits="admin_page_module_function_module_DacTa" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script type="text/javascript">
        function func() {
            grvList.Refresh();
            popupControl.Hide();
        }
        function btnChiTiet() {
            document.getElementById('<%=btnChiTiet.ClientID%>').click();
        }
        function checkNULL() {
            var CityName = document.getElementById('<%= txtNoiDung.ClientID%>');

            if (CityName.value.trim() == "") {
                swal('Tên form không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
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
    </script>
    <div class="card card-block">
        <br />  <br />
         <br />
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />
                        <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary" OnClick="btnChiTiet_Click" />
                        <input type="submit" class="btn btn-primary" value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="dacta_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Loại" FieldName="dacta_loai" HeaderStyle-HorizontalAlign="Center" Width="5%"></dx:GridViewDataColumn>
                     <dx:GridViewDataColumn Caption="Khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="5%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Môn" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="5%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Chương/Chủ đề" FieldName="chapter_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Bài" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Nội dung" FieldName="dacta_content" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                </Columns>
                <ClientSideEvents RowDblClick="btnChiTiet" />
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Trống" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="900" Height="600" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="Đặc tả" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12 form-group">
                                     <label class="col-2 form-control-label">Khối:</label>
                                    <div class="col-4">
                                        <dx:ASPxComboBox ID="ddlKhoi" runat="server" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true" ValueType="System.Int32" TextField="khoi_name" ValueField="khoi_id" ClientInstanceName="ddlMon" CssClass="" Width="95%"></dx:ASPxComboBox>
                                    </div>
                                    <label class="col-2 form-control-label">môn:</label>
                                    <div class="col-4">
                                        <dx:ASPxComboBox ID="ddlMon" runat="server" ValueType="System.Int32" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true" TextField="monhoc_name" ValueField="monhoc_id" ClientInstanceName="ddlMon" CssClass="" Width="95%"></dx:ASPxComboBox>
                                    </div>
                                    <label class="col-2 form-control-label">Chương/chủ đề:</label>
                                    <div class="col-4">
                                        <dx:ASPxComboBox ID="ddlChuong" runat="server" ValueType="System.Int32" OnSelectedIndexChanged="ddlChuong_SelectedIndexChanged" AutoPostBack="true" TextField="chapter_name" ValueField="chapter_id" ClientInstanceName="ddlChuong" CssClass="" Width="95%"></dx:ASPxComboBox>
                                    </div>
                                    <label class="col-2 form-control-label">Bài:</label>
                                    <div class="col-4">
                                        <dx:ASPxComboBox ID="ddlLesson" runat="server" ValueType="System.Int32" TextField="lesson_name" ValueField="lesson_id" ClientInstanceName="ddlLesson" CssClass="" Width="95%"></dx:ASPxComboBox>
                                    </div>
                                    <label class="col-2 form-control-label">Loại:</label>
                                    <div class="col-4">
                                        <asp:DropDownList ID="ddlLoai" runat="server">
                                            <asp:ListItem Value="Nhận biết" Text="Nhận biết"></asp:ListItem>
                                            <asp:ListItem Value="Thông hiểu" Text="Thông hiểu"></asp:ListItem>
                                            <asp:ListItem Value="Vận dụng" Text="Vận dụng"></asp:ListItem>
                                            <asp:ListItem Value="Vận dụng cao" Text="Vận dụng cao"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="div_content col-12">
                                <div class="col-12 form-group">
                                    <label class="col-2 form-control-label">Nội dung:</label>
                                    <div class="col-10">
                                        <asp:TextBox ID="txtNoiDung" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
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
                        <asp:Button ID="btnLuu" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary" OnClientClick="return checkNULL()" OnClick="btnLuu_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

