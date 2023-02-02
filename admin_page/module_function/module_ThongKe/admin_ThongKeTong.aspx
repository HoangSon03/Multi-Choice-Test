<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ThongKeTong.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_admin_ThongKeTong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function myHienThiKetQuaHocSinhTrongLop(id_lop) {
            document.getElementById("<%=txtLop.ClientID%>").value = id_lop;
            document.getElementById("<%=btnShowKetQuaHocSinhTrongLop.ClientID%>").click();
        }
        function my_SoLanLamBai(id_mahocsinh) {
            document.getElementById("<%=txtMaHocSinh.ClientID%>").value = id_mahocsinh;
            document.getElementById("<%=btnShowKetQuaLamBaitapHocSinh.ClientID%>").click();
        }
        function my_BieuDo(id_mahocsinh) {
            document.getElementById("<%=txtMaHocSinh.ClientID%>").value = id_mahocsinh;
                    document.getElementById("<%=btnShowKetQuaLamBaitapHocSinh.ClientID%>").click();
                }
        function myBangDiemTungHocSinh(id_test) {
            document.getElementById("<%=txtTest.ClientID%>").value = id_test;
            document.getElementById("<%=btnShowketQuaDiemBaiTapCuaTungHocSinh.ClientID%>").click();
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
                    <div id="div_TuNgayToiNgay1" runat="server" class="col-12" style="margin-top: 10px">
                        <div class="col-4" style="margin-right: 10px">
                            <label>Từ ngày:</label>
                            <input type="date" id="dteTuNgay1" class="form-control" />
                        </div>
                        <div class="col-4">
                            <label>Đến ngày:</label>
                            <input type="date" id="dteDenNgay1" class="form-control" />
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
                    <%-- List danh sách học sinh của 1 lớp--%>

                    <div id="div_SoLanLamBai" runat="server" class="col-12" style="margin-top: 10px; width: 100%">
                        <div class="form-group table-responsive">
                            <table class="table table-bordered table-hover table_baogiang">
                                <thead>
                                    <tr class="table-info table__point-head">
                                        <th scope="col">STT</th>
                                        <th scope="col">Mã học sinh</th>
                                        <th scope="col">Tên học sinh</th>
                                        <th scope="col">Số lần làm bài</th>
                                        <th scope="col">#</th>
                                        <th scope="col">Xem biểu đồ</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="rpSoLanLamBai">
                                        <ItemTemplate>
                                            <tr class="table-light table__point">
                                                <th scope="row"><%#Container.ItemIndex+1 %></th>
                                                <td><%#Eval("hocsinh_code") %></td>
                                                <td><%#Eval("hocsinh_name") %></td>
                                                <td><%#Eval("hocsinh_solanlambai") %></td>
                                                <td>
                                                    <a id="solanlambai" class="button check__point serif glass" href="javascript:void(0)" data-toggle="modal" onclick="my_SoLanLamBai('<%#Eval("hocsinh_code") %>')">Chi tiết</a>
                                                </td>
                                                <td>
                                                    <a id="thongke" class="button check__point serif glass" href="../../../admin-thong-ke-bieu-do-<%#Eval("hocsinh_code")%>" >Xem biểu đồ</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <%--<input type="text" name="name" value="" runat="server" id="txtGetId" />--%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <%--End List danh sách học sinh của 1 lớp--%>
                    <%-- List danh sách bảng điểm học sinh của 1 lớp--%>
                    <div id="div_BangDiemChiTietCuaHocSinh" runat="server" class="form-group table-responsive">
                        <table class="table table-bordered table-hover table_baogiang">
                            <thead>
                                <tr class="table-info table__point-head">
                                    <th scope="col">STT</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Tên bài tập</th>
                                    <th scope="col">Số lần làm bài</th>
                                    <th scope="col">Tình trạng</th>
                                    <th scope="col">#</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpBangDiemChiTietCuaHocSinh">
                                    <ItemTemplate>
                                        <tr class="table-light table__point">
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_name") %></td>
                                            <td><%#Eval("luyentap_name") %></td>
                                            <td><%#Eval("hocsinh_solanlambai") %></td>
                                            <td><%#Eval("luyentap_tinhtrang") %></td>
                                            <td>
                                                <a id="solanlambai" class="button check__point serif glass" href="javascript:void(0)" data-toggle="modal" onclick="myBangDiemTungHocSinh('<%#Eval("test_id") %>')">Chi tiết</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--<input type="text" name="name" value="" runat="server" id="txtGetId" />--%>
                            </tbody>
                        </table>
                    </div>
                    <%--End List danh sách bảng điểm học sinh của 1 lớp--%>
                    <%-- List danh sách bảng điểm chi tiết của 1 học sinh--%>
                    <div id="div_BangDiemChiTietCuaTungBaiTapHocSinh" runat="server" class="form-group table-responsive">
                        <table class="table table-bordered table-hover table_baogiang">
                            <thead>
                                <tr class="table-info table__point-head">
                                    <th scope="col">STT</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Tên bài tập</th>
                                    <th scope="col">Điểm</th>
                                    <th scope="col">Thời gian làm bài</th>
                                    <th scope="col">Ngày làm bài tập</th>
                                    <th scope="col">#</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpBangDiemChiTietCuaTungBaiTapHocSinh">
                                    <ItemTemplate>
                                        <tr class="table-light table__point">
                                            <th scope="row"><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("hocsinh_name") %></td>
                                            <td><%#Eval("luyentap_name") %></td>
                                            <td><%#Eval("resulttest_result") %></td>
                                            <td><%#Eval("result_thoigianlambai") %></td>
                                            <td><%#Eval("resulttest_datetime", "{0: dd/MM/yyyy hh:mm:ss}") %></td>
                                            <td>
                                                 <a id="<%#Eval("resulttest_id") %>" class="button check__point serif glass" href="javascript:void(0)" data-toggle="modal" data-target=".bd-example-modal-lg-<%#Eval("resulttest_id") %>">Xem bài kiểm tra</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--<input type="text" name="name" value="" runat="server" id="txtGetId" />--%>
                            </tbody>
                        </table>
                    </div>
                    <%--End List danh sách bảng điểm học sinh của 1 lớp--%>
                    <%--//popup--%>
                    <asp:Repeater ID="rpPopupChiTiet" runat="server" OnItemDataBound="rpPopupChiTiet_ItemDataBound">
                        <ItemTemplate>
                            <div class="modal fade bd-example-modal-lg-<%#Eval("resulttest_id") %>" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-lg modal-point-content">
                                    <div class="modal-header modal__point">
                                        <h4 class="popup__heading-point">Bài kiểm tra chi tiết</h4>                                                             
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span class="span-icon__popup" aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-content">
                                        <div class="popup__body popup__body-point">
                                            <table class="table table-bordered table-hover">
                                                <thead>
                                                    <tr class="table-info table__point-head">
                                                        <th scope="col">STT</th>
                                                        <th scope="col">Nội dung câu hỏi</th>
                                                        <th scope="col">Đáp án đúng</th>
                                                        <th scope="col">Đáp án đã chọn</th>
                                                        <%--<th scope="col">#</th>--%>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater runat="server" ID="rpBangDiemDetails">
                                                        <ItemTemplate>
                                                            <tr class="table-light table__point">
                                                                <th scope="row"><%=STT4++ %></th>
                                                                <td><%#Eval("noidungcauhoi") %></td>
                                                                <td><%#Eval("content_dapandung") %></td>
                                                                <td><%#Eval("content_dapanchon") %></td>
                                                                <%--<td></td>--%>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- Các hàm xử lý ẩn phía dưới--%>
                    <div style="display: none">
                        <%--  điều kiện truy xuất lớp--%>
                        <input type="text" id="txtLop" runat="server" />
                        <a href="#" id="btnShowKetQuaHocSinhTrongLop" runat="server" onserverclick="btnShowKetQuaHocSinhTrongLop_ServerClick"></a>
                        <%-- điều kiện truy xuất học sinh--%>
                        <input type="text" id="txtMaHocSinh" runat="server" />
                        <a href="#" id="btnShowKetQuaLamBaitapHocSinh" runat="server" onserverclick="btnShowKetQuaLamBaitapHocSinh_ServerClick"></a>
                        <%-- điều kiện truy xuất id học sinh--%>
                        <a href="#" id="btnShowBieuDo" runat="server" onserverclick="btnShowBieuDo_ServerClick"></a>
                        <%-- điều kiện truy xuất từng bài tập của học sinh--%>
                        <input type="text" id="txtTest" runat="server" />
                        <a href="#" id="btnShowketQuaDiemBaiTapCuaTungHocSinh" runat="server" onserverclick="btnShowketQuaDiemBaiTapCuaTungHocSinh_ServerClick"></a>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </div>
    <style>
        .table_baogiang td, .table_baogiang th {
            text-align: center;
            border: 1px solid #2d3846 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
