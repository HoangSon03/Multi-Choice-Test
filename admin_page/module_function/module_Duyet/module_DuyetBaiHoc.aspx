<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DuyetBaiHoc.aspx.cs" Inherits="admin_page_module_function_module_Duyet_module_DuyetBaiHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">
     <script>
        function confirmDel1() {
            swal("Bạn có thực sự muốn duyệt bài học ?",
                "Nếu duyệt, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        var duyetCh = document.getElementById('<%=btnDuyetChuong.ClientID%>');
                        duyetCh.click();
                    }
                });
        }
    </script>
    <div class="card card-block">
        <div class="row">
            <div class="col-sm-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged1" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlChuong" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlChuong_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <input type="button" name="name" value="Duyệt" class="btn btn-primary" runat="server" onclick="confirmDel1()" />
                            <asp:Button CssClass="invisible" Text="Duyệt" ID="btnDuyetChuong" runat="server" OnClick="btnDuyetChuong_Click" />
                        </div>
                        <div class="form-group table-responsive">
                            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="lesson_id">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="7%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="Tên bài học" FieldName="lesson_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tên khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tên môn học" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tên chương" FieldName="chapter_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tình trạng" FieldName="hidden" HeaderStyle-HorizontalAlign="Center" Width="40%" Settings-AllowEllipsisInText="true"></dx:GridViewDataColumn>
                                </Columns>
                                <SettingsSearchPanel Visible="true" />
                                <SettingsBehavior AllowFocusedRow="true" />
                                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                                <SettingsLoadingPanel Text="Đang tải..." />
                                <SettingsPager PageSize="20" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                            </dx:ASPxGridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" Runat="Server">
</asp:Content>

