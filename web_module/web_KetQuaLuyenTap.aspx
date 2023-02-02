<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterPage.master" AutoEventWireup="true" CodeFile="web_KetQuaLuyenTap.aspx.cs" Inherits="web_module_web_KetQuaLuyenTap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <style>
        .content_image {
            width: 560px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="higlobal" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hislider" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" runat="Server">

    <script>
        function getDetails(id) {
            //var showOverlay = document.querySelector(".popup__content");
            //showOverlay.classList.toggle("popup__show");
            //var showContent = document.querySelector(".popupPoint");
            //showContent.classList.toggle("popup__show");
        };
    </script>
    <div class="main-bangdiem" id="mainBangDiem">
        <div class="container">
            <%--<h4 class="bangdiem__date">Ngày <%=date %></h4>--%>
            <h4 class="bangdiem__heading">Danh sách kết quả bài luyện tập</h4>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="bangdiem__content">
                        <table class="table table-bordered table-hover">
                            <thead>
                                <tr class="table-info table__point-head">
                                    <th scope="col">STT</th>
                                    <th scope="col">Mã học sinh</th>
                                    <th scope="col">Tên học sinh</th>
                                    <th scope="col">Bài luyện tập</th>
                                    <th scope="col">Môn học</th>
                                    <th scope="col">Lớp</th>
                                    <th scope="col">Điểm</th>
                                    <th scope="col">Ngày làm bài</th>
                                    <th scope="col">#</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater runat="server" ID="rpBangDiem">
                                    <ItemTemplate>
                                        <tr class="table-light table__point">
                                            <th scope="row"><%=STT++ %></th>
                                            <td><%#Eval("hocsinh_code") %></td>
                                            <td><%#Eval("hocsinh_name") %></td>
                                            <td><%#Eval("luyentap_name") %></td>
                                            <td><%#Eval("monhoc_name") %></td>
                                            <td><%#Eval("Khoi_name") %></td>
                                            <td><%#Eval("resulttest_result") %></td>
                                            <td><%#Eval("resulttest_datetime", "{0: dd-MM-yyyy}") %></td>
                                            <td>
                                                <a id="<%#Eval("resulttest_id") %>" class="button check__point serif glass" href="javascript:void(0)" data-toggle="modal" data-target=".bd-example-modal-lg-<%#Eval("resulttest_id") %>">Chi tiết</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--<input type="text" name="name" value="" runat="server" id="txtGetId" />--%>
                            </tbody>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

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
                                                <th scope="row"><%=STTs++ %></th>
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
   
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content12" ContentPlaceHolderID="hifootersite" runat="Server">
    <%--<script>
        $(document).ready(function () {
            $(".check__point").click(function () {
                $(".popup__content").toggleClass("popup__show");
                $(".popupPoint").toggleClass("popup__show");
            });
        });

        $(document).ready(function () {
            $(".popup__times").click(function () {
                $(".popupPoint").removeClass("popup__show");
                $(".popup__content").removeClass("popup__show");
            });
        });
    </script>--%>
</asp:Content>

