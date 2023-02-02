<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ChiTiet_LamBaiTap.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_ChiTiet_LamBaiTap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="form-group">
        <label id="txtName" runat="server" style="justify-content: center; display: flex; font-size: 30px;" />
    </div>

    <div class="card card-block">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="form-group">
                    <div class="col-4 flex-row">
                        <label>Từ ngày:</label>
                        <input type="date" id="dteTuNgay" runat="server" class="form-control" />
                    </div>
                    <div class="col-4 flex-row ml-2 mr-2">
                        <label>Đến ngày:</label>
                        <input type="date" id="dteDenNgay" runat="server" class="form-control" />
                    </div>
                    <div class="col-1">
                        <a id="btnXem" runat="server" class="btn btn-primary" onserverclick="btnXem_ServerClick">Xem</a>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="card card-block">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="form-group table-responsive">
                    <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="resulttest_id" Width="100%">
                        <Columns>
                            <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                <DataItemTemplate>
                                    <%#Container.ItemIndex+1 %>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Ngày làm bài" FieldName="ngaylambai" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Môn học" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Tên bài luyện tập" FieldName="luyentap_name" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Điểm" FieldName="resulttest_result" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Thời gian làm bài" FieldName="result_thoigianlambai" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                        </Columns>
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
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

