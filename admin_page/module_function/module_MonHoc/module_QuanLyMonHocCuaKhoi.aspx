<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_QuanLyMonHocCuaKhoi.aspx.cs" Inherits="admin_page_module_function_module_MonHoc_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <style>
        .title_monhoc {
            margin: 0;
            margin-top: 20px;
            font-size: 22px;
        }

        .header_header {
            height: 60px;
            border-bottom: 1px solid black;
        }
    </style>
    <script>
        function myMon(id) {
            var idmon = document.getElementById("<%=txtMonHidden.ClientID%>").value = id;
            document.getElementById("<%=btnck.ClientID%>").click();
        }
        window.onload = function () {
            var ID_Mon = document.getElementById("<%=txtListMon.ClientID%>").value.split(',');
            for (var i = 0; i < ID_Mon.length; i++) {
                document.getElementById("ckMon" + ID_Mon[i]).checked = true
            }

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
                        var giaovien_id = document.getElementById("<%=btnHuy.ClientID%>");
                        giaovien_id.click();
                    }


                });
        }
    </script>

    <div class="card card-block">
        <h3 style="text-align: center; font-size: 28px; font-weight: bold; color: blue">GIÁO VIÊN DẠY MÔN</h3>
        <div style="display: none">
            <input type="text" id="txtMonHidden" runat="server" />
            <input type="text" id="txtListMon" runat="server" />
            <a href="#" id="btnck" runat="server" onserverclick="btnck_ServerClick"></a>
            <a href="#" id="btnHuy" runat="server" onserverclick="btnHuy_ServerClick"></a>
        </div>
        <div class="form-group row">
            <div class="col-sm-10 ">
                Chọn giáo viên:
                <asp:DropDownList ID="ddlGiaoVien" runat="server" AutoPostBack="true" AppendDataBoundItems="true" EnableViewState="true">
                    <asp:ListItem Text="Chọn Giáo Viên:" Value="Chọn Giáo Viên"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                Chọn Môn: 
                <br />
                <div class="main_khoi" style="margin: 1% 0;">
                    <asp:Repeater ID="rpMon" runat="server">
                        <ItemTemplate>

                            <input type="checkbox" id="ckMon<%#Eval("monhoc_id") %>" onclick='myMon("<%#Eval("monhoc_id") %>")'>
                            <label style="padding: 0 5px;"><%#Eval("monhoc_name")%></label>
                        </ItemTemplate>

                    </asp:Repeater>
                </div>
                <br />
                <div>
                    <dx:ASPxGridView ID="grvList" runat="server" AutoGenerateColumns="true" ClientInstanceName="grvList" KeyFieldName="giaoviendaymon_id" Width="100%">
                        <Columns>
                            <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                            </dx:GridViewCommandColumn>
                            <dx:GridViewDataColumn Caption="Tên giáo viên" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="25%">
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Môn" FieldName="monhoc_name" HeaderStyle-HorizontalAlign="Center" Width="25%"></dx:GridViewDataColumn>
                        </Columns>
                        <SettingsSearchPanel Visible="true" />
                        <SettingsBehavior AllowFocusedRow="true" />
                        <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Nhập từ cần tìm kiếm..." />
                        <SettingsLoadingPanel Text="Đang tải..." />
                        <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
                    </dx:ASPxGridView>
                </div>
            </div>

            <a href="#" id="btn_Huy" class="btn btn-primary float-sm-right" onclick="confirmDel()">Hủy tất cả</a>
        </div>
    </div>
    <script>
        $('#<%=ddlGiaoVien.ClientID%>').chosen();
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

