<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DanhSachBaiLuyenTap.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_DanhSachBaiLuyenTap" %>

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
        function myfunction(id) {
            document.getElementById("<%=id_key.ClientID%>").value = id;
            var dd = document.getElementById("<%=build_url.ClientID%>");
            dd.click();
        }
        function geturl() {
            var copyText = document.getElementById("<%=url.ClientID%>");
            copyText.select();
            copyText.setSelectionRange(0, 99999)
            document.execCommand("copy");
            console.log(copyText.value);
            //Swal.fire({
            //    position: 'center',
            //    icon: 'success',
            //    title: 'Đã sao chép đường liên kết',
            //    showConfirmButton: false,
            //    timer: 1500
            //})
            var tooltip = document.getElementById("myTooltip");
            tooltip.classList.add('tooltiptext__show');
            tooltip.innerHTML = "Đã sao chép đường liên kết";
            //tooltip.style.display = "block";
            setTimeout(function () {
                tooltip.style.transform = "scale(0)";
            }, 1500);
        }

    </script>

    <style>
        .link {
            position: absolute;
            top: 100px;
            z-index: -1;
        }

        #myTooltip {
            width: auto;
            height: 42px;
            color: white;
            text-align: center;
            border-radius: 6px;
            padding: 5px;
            position: fixed;
            z-index: 7;
            right: 40%;
            top: 50%;
            background: #656767;
            line-height: 30px;
        }

        .tooltiptext {
            opacity: 0;
            visibility: hidden;
            transform: scale(0);
            transition: transform 0.3s linear;
        }

            .tooltiptext.tooltiptext__show {
                opacity: 1;
                visibility: visible;
                transform: scale(1);
            }
    </style>
    <div class="card card-block">
        <input type="text" name="name" value="" hidden="hidden" runat="server" id="id_key" placeholder="id_click" />

        <div class="row">
            <div class="col-sm-12">
                  <div class="col-sm-10">
                      <button class="btn btn-primary" href="#"  id="btnChiTiet" runat="server"  onserverclick="btnChiTiet_ServerClick">Chi tiết</button>
                 </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <input type="text" name="name" value="" class="link" runat="server" id="url" placeholder="đường dẫn" style="width: 1000px" />
                        <asp:Button Text="text" ID="build_url" runat="server" CssClass="invisible" OnClick="build_url_Click" />
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
                                    <dx:GridViewDataColumn HeaderStyle-HorizontalAlign="Center" Width="20%" Settings-AllowEllipsisInText="true">
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
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

