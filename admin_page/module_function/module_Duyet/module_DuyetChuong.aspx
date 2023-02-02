<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DuyetChuong.aspx.cs" Inherits="admin_page_module_function_module_Duyet_module_DuyetChuong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script>
        function confirmDel1() {
            console.log(document.getElementById('hibodywrapper_grvListCh_DXSelBtn0').checked);
            swal("Bạn có thực sự muốn duyệt chương ?",
                "Nếu duyệt, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    debugger;
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
                            <asp:DropDownList ID="ddlKhoi_M" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlKhoi_M_SelectedIndexChanged1" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged1" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <input type="button" name="name" value="Duyệt" class="btn btn-primary" runat="server" onclick="confirmDel1()" />
                            <asp:Button CssClass="invisible" Text="Duyệt" ID="btnDuyetChuong" runat="server" OnClick="btnDuyetChuong_Click" />
                        </div>
                        <div class="form-group table-responsive">
                            <dx:ASPxGridView ID="grvListCh" runat="server" ClientInstanceName="grvListCh" KeyFieldName="chapter_id">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="7%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="Tên chương" FieldName="chapter_name" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tên môn học" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tên khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tình trạng" FieldName="hidden" HeaderStyle-HorizontalAlign="Center" Width="20%" Settings-AllowEllipsisInText="true"></dx:GridViewDataColumn>
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
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

