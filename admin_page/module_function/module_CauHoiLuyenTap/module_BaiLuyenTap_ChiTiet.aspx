<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_BaiLuyenTap_ChiTiet.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_BaiLuyenTap_ChiTiet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Meta -->
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="keywords" content="SITE KEYWORDS HERE" />
    <meta name="description" content="" />
    <meta name='copyright' content='' />
    <%-- <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />--%>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Title -->
    <title>Trắc nghiệm Online</title>
    <!-- Favicon -->
    <link rel="icon" type="image/png" href="/images/logovn-2295.png" />
    <!-- Web Font -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900" rel="stylesheet" />
    <!-- Font IcoFont CSS -->
    <link href="/css/icofont.css" rel="stylesheet" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="/css/bootstrap.min.css" />
    <!-- Font Awesome CSS -->
    <link rel="stylesheet" href="/css/font-awesome.min.css" />
    <!-- Fancy Box CSS -->
    <link rel="stylesheet" href="/css/jquery.fancybox.min.css" />
    <!-- Owl Carousel CSS -->
    <link rel="stylesheet" href="/css/owl.carousel.min.css" />
    <link rel="stylesheet" href="/css/owl.theme.default.min.css" />
    <!-- Animate CSS -->
    <link rel="stylesheet" href="/css/animate.min.css" />
    <!-- Slick Nav CSS -->
    <link rel="stylesheet" href="/css/slicknav.min.css" />
    <!-- Magnific Popup -->
    <link rel="stylesheet" href="/css/magnific-popup.css" />
    <%--Trắc Nghiệm--%>
    <link href="/css/css_tracnghiem/tracnghiem.css" rel="stylesheet" />
    <script src="../admin_js/sweetalert.min.js"></script>
    <!-- Learedu Stylesheet -->
    <%--<link href="css/css_trangchu/trangchu.css" rel="stylesheet" />--%>
    <!-- Learedu Color -->
    <link rel="stylesheet" href="/css/color3.css" />
    <%--css Khoa Hoc--%>
</head>


<body>
    <form id="form1" runat="server">
        <script>

            function printDiv(divName) {
                var printContents = document.getElementById(divName).innerHTML;
                var originalContents = document.body.innerHTML;
                document.body.innerHTML = printContents;
                window.print();
                document.body.innerHTML = originalContents;
            }
            function fucnGetValue(idCH, dangCH, typeCH) {
                document.getElementById("<%=txtID.ClientID%>").value = idCH;
                document.getElementById("<%=txtDang.ClientID%>").value = dangCH;
                document.getElementById("<%=txtType.ClientID%>").value = typeCH;
                document.getElementById("<%=btnThayDoi.ClientID%>").click();

            }
            function fucnGetValueNew(idCH, idBai) {
                document.getElementById("<%=txtIDnew.ClientID%>").value = idCH;
                document.getElementById("<%=txtBainew.ClientID%>").value = idBai;
                document.getElementById("<%=btnLuaChon.ClientID%>").click();

            }
        </script>
        <style>
            * {
                user-select: none;
            }
        </style>
        <%--//--%>

        <asp:ScriptManager runat="server" />
        <%-- Start Khung ma trận đề--%>
        <%--<div>
            MA TRẬN ĐỀ KIỂM TRA .........
            NĂM HỌC: ..........
            MÔN ...........
        </div>
        <div>
            KHUNG MA TRẬN ĐỀ
            <table border="1" class="format" style="margin: auto; text-align: center">
                <tr>
                    <th rowspan="3">TT</th>
                    <th rowspan="3">Chương/chủ đề</th>
                    <th rowspan="3">Nội dung/đơn vị kiến thức</th>
                    <th colspan="8">Mức độ nhận thức</th>
                    <th rowspan="3">Tổng % điểm</th>
                </tr>
                <tr>
                    <th colspan="2">Nhận biết</th>
                    <th colspan="2">Thông hiểu</th>
                    <th colspan="2">Vận dụng</th>
                    <th colspan="2">Vận dung cao</th>
                </tr>
                <tr>
                    <th>TNKQ</th>
                    <th>TL</th>
                    <th>TNKQ</th>
                    <th>TL</th>
                    <th>TNKQ</th>
                    <th>TL</th>
                    <th>TNKQ</th>
                    <th>TL</th>
                </tr>
                <asp:Repeater ID="rpMaTranDeThi" runat="server" OnItemDataBound="rpMaTranDeThi_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>1</td>
                            <td><%#Eval("chapter_name") %></td>
                            <td><%#Eval("lesson_name") %></td>
                            <asp:Repeater ID="rpMaTranChiTiet" runat="server">
                                <ItemTemplate>
                                    <td><%#Eval("matranchitiet_socau") %> câu<br />
                                        (<%#Eval("matranchitiet_diem") %>đ)<br />
                                        <%#Eval("matranchitiet_phantram") %>%</td>
                                </ItemTemplate>
                            </asp:Repeater>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="3">Tổng</td>
                    <td><%=sum_count_NB_TN%></td>
                    <td><%=sum_count_NB_TL%></td>
                    <td><%=sum_count_TH_TN%></td>
                    <td><%=sum_count_TH_TL%></td>
                    <td><%=sum_count_VD_TN%></td>
                    <td><%=sum_count_VD_TL%></td>
                    <td><%=sum_count_VDC_TN%></td>
                    <td><%=sum_count_VDC_TL%></td>
                    <td><%=(sum_count_NB_TN+sum_count_NB_TL+sum_count_TH_TN+sum_count_TH_TL+sum_count_VD_TN+sum_count_VD_TL+sum_count_VDC_TN+sum_count_VDC_TL)%></td>
                </tr>
                <tr>
                    <td colspan="3">Tỉ lệ %</td>
                    <td colspan="2"><%=tileNhanBiet%>%</td>
                    <td colspan="2"><%=tileThongHieu%>%</td>
                    <td colspan="2"><%=tileVanDung%>%</td>
                    <td colspan="2"><%=tileVanDungCao%>%</td>
                    <td><%=(tileVanDung+tileVanDungCao+tileNhanBiet+tileThongHieu) %>%</td>
                </tr>

                <tr>
                    <td colspan="3">Tỉ lệ chung</td>
                    <td colspan="4"><%=(tileNhanBiet+tileThongHieu) %>%</td>
                    <td colspan="4"><%=(tileVanDung+tileVanDungCao) %>%</td>
                    <td><%=(tileVanDung+tileVanDungCao+tileNhanBiet+tileThongHieu) %>%</td>
                </tr>
            </table>
        </div>--%>


        <%-- End Khung ma trận đề--%>
        <%-- Start đề thi--%>
        <%-- Start đặc tả ma trận đề--%>
        <%--<div>
            BẢNG ĐẶC TẢ ĐỀ KIỂM TRA ...
            MÔN ...
        </div>
        <div>
            <table border="1" class="format" style="margin: auto; text-align: center">
                <tr>
                    <td rowspan="2">TT</td>
                    <td rowspan="2">Chương/ Chủ đề</td>
                    <td rowspan="2">Nội dung/ Đơn vị kiến thức</td>
                    <td rowspan="2">Mức độ đánh giá</td>
                    <td colspan="4">Số câu hỏi theo mức độ nhận thức</td>
                </tr>
                <tr>
                    <td>Nhận biết</td>
                    <td>Thông hiểu</td>
                    <td>Vận dụng</td>
                    <td>Vận dụng cao</td>
                </tr>
                <asp:Repeater ID="rpDacTa" runat="server" OnItemDataBound="rpDacTa_ItemDataBound">
                    <ItemTemplate>
                        <tr>

                            <td><%=STT1++ %></td>
                            <td><%#Eval("chapter_name") %></td>
                            <td><%#Eval("lesson_name") %></td>
                            <td><%#Eval("dacta_content") %></td>
                            <asp:Repeater ID="rpDetailDangCauHoi" runat="server">
                                <ItemTemplate>
                                    <td><%#Eval("question_nhanbiet") %></td>
                                    <td><%#Eval("question_thonghieu") %></td>
                                    <td><%#Eval("question_vandung") %></td>
                                    <td><%#Eval("question_vandungcao") %></td>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>--%>
        <%-- End đặc tả ma trận đề--%>
        <div class="content-app" id="content-id">
            <div class="main__tracnghiem" id="popupBlur">
                <%--<asp:UpdatePanel runat="server">
                    <ContentTemplate>--%>
                <div id="div_BaiTap" runat="server">
                    <div class="tracnghiem__heading-box">
                        <div class="content__heading">
                            <h3 class="tracnghiem__heading">BÀI LUYỆN TẬP</h3>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-6">
                                <div style="display: none">
                                    <input id="txtID" runat="server" />
                                    <input id="txtDang" runat="server" />
                                    <input id="txtType" runat="server" />
                                    <input id="txtIDnew" runat="server" />
                                    <input id="txtBainew" runat="server" />
                                </div>
                                <a id="btnThayDoi" runat="server" onserverclick="btnThayDoi_ServerClick"></a>
                                <a id="btnLuaChon" runat="server" onserverclick="btnLuaChon_ServerClick"></a>
                                <div name="Div_TracNghiem">
                                    <asp:Repeater runat="server" ID="rpCauHoiDetals" OnItemDataBound="rpCauHoiDetals_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                <a class="btn btn-primary" onclick="fucnGetValue(<%#Eval("question_id") %>,'<%#Eval("question_dangcauhoi") %>','<%#Eval("question_type") %>')" style="color: white">Thay đổi </a>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <div class="tracnghiem__answer">
                                                        <div class="tracnghiem__box">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                    </div>
                                                </div>
                                            </fieldset>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div name="Div_TuLuan">
                                    <asp:Repeater ID="rpBaiTapTuaLuan" runat="server">
                                        <ItemTemplate>
                                            <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                            <a class="btn btn-primary" style="color: white">Thay đổi </a>
                                            <%#Eval("luyentap_baitaptuluan") %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <a id="btnCapNhat" runat="server" class="btn btn-primary" onserverclick="btnCapNhat_ServerClick">Lưu thay đổi </a>
                                <a id="btnQuayLai" class="btn btn-primary" href="/admin-tao-bai-luyen-tap-ngau-nhien">Quay lại </a>

                            </div>
                            <div class="col-6 div_ThayThe" style="border: 3px solid #dc3545; border-radius: 10px;">
                                Danh sách câu hỏi thay thế
                                        <div class="col-12">
                                            <asp:DropDownList ID="ddlChuong" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlChuong_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                <div class="col-12">
                                    <asp:DropDownList ID="ddlBai" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlBai_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div name="Div_ThayThe" id="divThayThe" runat="server">
                                    <asp:Repeater runat="server" ID="rpThayThe">
                                        <ItemTemplate>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                <a class="btn btn-primary" style="color: white" onclick="fucnGetValueNew(<%#Eval("question_id") %>,<%#Eval("lesson_id") %>)">Lựa chọn</a>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                </div>
                                            </fieldset>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <%-- End đề thi--%>
    </form>
    <script src="/js/jquery-3.5.1.min.js"></script>
    <script src="/js/jquery-migrate.min.js"></script>
    <!-- Popper JS-->
    <script src="/js/popper.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="/js/bootstrap.min.js"></script>
    <!-- Colors JS-->
    <script src="/js/colors.js"></script>
    <!-- Jquery Steller JS -->
    <script src="/js/jquery.stellar.min.js"></script>
    <!-- Particle JS -->
    <script src="/js/particles.min.js"></script>
    <!-- Fancy Box JS-->
    <script src="/js/facnybox.min.js"></script>
    <!-- Magnific Popup JS-->
    <script src="/js/jquery.magnific-popup.min.js"></script>
    <!-- Masonry JS-->
    <script src="/js/masonry.pkgd.min.js"></script>
    <!-- Circle Progress JS -->
    <script src="/js/circle-progress.min.js"></script>
    <!-- Owl Carousel JS-->
    <script src="/js/owl.carousel.min.js"></script>
    <!-- Waypoints JS-->
    <script src="/js/waypoints.min.js"></script>
    <!-- Slick Nav JS-->
    <script src="/js/slicknav.min.js"></script>
    <!-- Counter Up JS -->
    <script src="/js/jquery.counterup.min.js"></script>
    <!-- Easing JS-->
    <script src="/js/easing.min.js"></script>
    <!-- Wow Min JS-->
    <script src="/js/wow.min.js"></script>
    <!-- Scroll Up JS-->
    <script src="/js/jquery.scrollUp.min.js"></script>
    <!-- Main JS-->
    <script src="/js/main.js"></script>
</body>
</html>
