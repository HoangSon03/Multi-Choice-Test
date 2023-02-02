<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="web_MaTranDeThi.aspx.cs" Inherits="web_module_MaTran_DeThi_web_MaTranDeThi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">


    <div class="card card-block">
        <input type="text" name="name" value="" hidden="hidden" runat="server" id="id_key" placeholder="id_click" />

        <div class="row">
            <div class="col-sm-12">
                  <div class="col-sm-10">
                      <button class="btn btn-primary" href="#"  id="btnChiTiet" runat="server" onserverclick="btnChiTiet_ServerClick"  >Chi tiết</button>
                 </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <%--<input type="text" name="name" value="" class="link" runat="server" id="url" placeholder="đường dẫn" style="width: 1000px" />--%>
                        <%--<asp:Button Text="text" ID="build_url" runat="server" CssClass="invisible"  />--%>
                        <div class="form-group table-responsive">
                            <span class="tooltiptext" id="myTooltip">Đã sao chép đường liên kết</span>
                            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="test_id">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                                        <DataItemTemplate>
                                            <%#Container.ItemIndex+1 %>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Môn học" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Tên bài luyện tập" FieldName="luyentap_name" HeaderStyle-HorizontalAlign="Center" Width="25%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ngày tạo" FieldName="test_createdate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Chi tiết đề" HeaderStyle-HorizontalAlign="Center" Width="20%" Settings-AllowEllipsisInText="true">
                                        <DataItemTemplate>
                                            <a href="javascript:void(0)" id="<%#Eval("test_id") %>" onclick="myfunction(this.id)" class="btn btn-primary">Sao chép link</a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
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
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" Runat="Server">
</asp:Content>

