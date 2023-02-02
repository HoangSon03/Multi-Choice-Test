<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ThongKeTongSoLanLamBai.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_admin_ThongKeTongSoLanLamBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function myHienThiKetQuaHocSinhTrongLop(id_lop) {
            document.getElementById("<%=txtLop.ClientID%>").value = id_lop;
            document.getElementById("<%=btnShowKetQuaHocSinhTrongLop.ClientID%>").click();
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
        <div class="row header_header">
            <asp:UpdatePanel ID="upLop" runat="server">
                <ContentTemplate>
                    <div class="col-12">
                        <div class="col-4">
                            <label>Chọn khối:</label>
                            <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
           
                    <div id="div_ListLop" class="col-12" style="margin-top: 10px;">
                        <asp:Repeater ID="rpLop" runat="server">
                            <ItemTemplate>
                                <a class="btn btn-primary" id="btn_HienThiKetQuaHocSinhTrongLop" onclick="myHienThiKetQuaHocSinhTrongLop(<%#Eval("lop_id") %>)">
                                    <span><%#Eval("lop_name") %></span><br />
                                    <span><%#Eval("soluong_hocsinhlambai") %>/<%#Eval("tongsoluong_hocsinhlambai") %></span>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                </div>
                    <%-- Các hàm xử lý ẩn phía dưới--%>
                   <div style="display: none">
                        <%--  điều kiện truy xuất lớp--%>
                        <input type="text" id="txtLop" runat="server" />
                        <a href="#" id="btnShowKetQuaHocSinhTrongLop" runat="server" onserverclick="btnShowKetQuaHocSinhTrongLop_ServerClick"></a>

                       </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
