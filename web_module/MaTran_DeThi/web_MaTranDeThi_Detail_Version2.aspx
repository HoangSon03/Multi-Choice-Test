<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_MaTranDeThi_Detail_Version2.aspx.cs" Inherits="web_module_web_MaTranDeThi_Detail_Version2" %>

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


<body onload="hideLesson()">
    <form id="form1" runat="server">
        <script>

            function printDiv(divName) {
                var printContents = document.getElementById(divName).innerHTML;
                var originalContents = document.body.innerHTML;
                document.body.innerHTML = printContents;
                window.print();
                document.body.innerHTML = originalContents;
            }


            function checkValue(ques_id, value, id_check) {
                $("input[name='value_" + ques_id + "']").val(value);
                $("input[name='ID_" + ques_id + "']").val(id_check);
            }
            function checkValueFinish() {
                var getValues = $("input[name*='value_']").map(function () {
                    return $(this).val();
                }).get();
                var getId = $("input[name*='ID_']").map(function () {
                    return $(this).val();
                }).get();

                var getQuestionID = $("input[name='txtQuestionID']").map(function () {
                    return $(this).val();
                }).get();
                document.getElementById('<%=txtChecked.ClientID%>').value = getId;
                document.getElementById('<%=txtIDQuestion.ClientID%>').value = getQuestionID;
                document.getElementById('<%=txtValueChecked.ClientID%>').value = getValues;
                var count = 0;
                for (var index = 0; index < getValues.length; index++) {
                    if (getValues[index] == "True") {
                        count++;
                    }
                }
                document.getElementById("pointStart").innerHTML = count;
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;
                var changeImage = document.querySelector(".point__img");
                changeImage.src = "";
                //debugger;
                var total = document.getElementById("pointFinish").innerHTML;
                total = parseInt(total);
                var countPoint = (count / total) * 10;
                //console.log(typeof (total));
                //console.log(typeof (count));
                //console.log(typeof (countPoint));
                if (countPoint >= 8) {
                    changeImage.src = "../images/point-right.gif";
                } else {
                    changeImage.src = "../images/point-left.gif";
                }
            }
            function confirmDel() {
                swal("Bạn có thực sự muốn nộp bài?",
                    "Nếu đồng ý, đáp án sẽ không được thay đổi.",
                    "warning",
                    {
                        buttons: true,
                        successMode: true
                    }).then(function (value) {
                        if (value == true) {

                            //tính ra được thời gian làm bài và thêm vào db
                            timeFinish = (total - timeleft) - 1;
                            document.getElementById("<%=txtFinish.ClientID%>").value = timeFinish
                            checkValueFinish();

                            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                            xoa.click();
                            $(document).ready(function () {
                                $(".popup__content").toggleClass("popup__show");
                                $(".popupPoint").toggleClass("popup__show");
                            });
                        }
                    });
                $(document).ready(function () {
                    $(".popup__times").click(function () {
                        $(".popupPoint").removeClass("popup__show");
                        $(".popup__content").removeClass("popup__show");
                        var getValue = document.getElementById('<%=txtValueChecked.ClientID%>').value.split(',');
                        var getId = document.getElementById('<%=txtChecked.ClientID%>').value.split(',');

                        for (var index = 0; index < getId.length; index++) {
                            $("#test" + getId[index] + "").attr('checked', 'checked');

                            if (getValue[index] == "True") {
                                $("#test" + getId[index] + "").next().css("color", "green");
                                $("#test" + getId[index] + "").next().toggleClass('checked__rdoo');
                            } else {
                                $("#test" + getId[index] + "").next().css("color", "red");
                                $("#test" + getId[index] + "").next().toggleClass('checked__rdo');
                            }
                        }
                        document.getElementById("popupBlur").style.pointerEvents = "none";
                    });
                });
            }
            //các biến thiết lập thời gian làm bài
            var total = 70;
            var timeleft = 70;
            var timeFinish = 0;
            //hàm đếm ngược
            function countDown() {
                $("#div_BaiTap").show();     //hide
                document.getElementById("btnTriggerTime").disabled = true;
                var downloadTimer = setInterval(function () {
                    if (timeleft <= 0) {
                        clearInterval(downloadTimer);
                        document.getElementById('content-id').style.pointerEvents = "none";
                        document.getElementById("countdown").innerHTML = "HẾT THỜI GIAN LÀM BÀI !";
                    } else {
                        minutes = parseInt(timeleft / 60, 10);
                        seconds = parseInt(timeleft % 60, 10);

                        minutes = minutes < 10 ? "0" + minutes : minutes;
                        seconds = seconds < 10 ? "0" + seconds : seconds;

                        document.getElementById("countdown").innerHTML = minutes + ":" + seconds;
                    }
                    timeleft -= 1;
                }, 1000);
            }
            function hideLesson() {
                /* $("#div_BaiTap").hide();   */
            }

            //ngăn dùng F12, ctr-shift-i .... để inspect html
            //document.onkeydown = function (e) {
            //    if (event.keyCode == 123) {
            //        return false;
            //    }
            //    if (e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)) {
            //        return false;
            //    }
            //    if (e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)) {
            //        return false;
            //    }
            //    if (e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)) {
            //        return false;
            //    }
            //    if (e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)) {
            //        return false;
            //    }
            //}

            /*hàm ngăn copy paste test*/
            //document.addEventListener("contextmenu", function (evt) {
            //    evt.preventDefault();
            //});

            //document.addEventListener("copy", function (evt) {
            //    evt.clipboardData.setData("text/plain", "");
            //    evt.preventDefault();
            //});
        </script>
        <style>
            * {
                user-select: none;
            }
        </style>
        <%--//--%>

        <asp:ScriptManager runat="server" />
        <%-- Start Khung ma trận đề--%>
        <div>
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
        </div>


        <%-- End Khung ma trận đề--%>
        <%-- Start đề thi--%>
        <%-- Start đặc tả ma trận đề--%>
        <div>
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
        </div>
        <%-- End đặc tả ma trận đề--%>
        <div class="content-app" id="content-id">
            <div class="main__tracnghiem" id="popupBlur">
                <div class="popupPoint" id="popupPoint">
                    <div class="popup__content">
                        <div class="popup__heading">
                            <div class="popup__point">
                                <div class="point">
                                    <span id="pointStart">0</span>/<span id="pointFinish"><%=count%></span>&nbsp;câu đúng
                                </div>
                                <div class="popup__times">
                                </div>
                                <i class="fa fa-times popup__times" aria-hidden="true"></i>
                            </div>
                        </div>
                        <div class="popup__body">
                            <div class="popup__inner">
                                <img class="point__img" src="../images/point-left.gif" alt="Alternate Text" />
                            </div>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container" hidden="hidden">
                            <input type="text" value="" id="txtSoCauDung" runat="server" placeholder="số câu đúng" />
                            <input type="text" name="txtChecked" value="" id="txtChecked" runat="server" placeholder="checked" />
                            <input type="text" value="" id="txtIDQuestion" runat="server" placeholder="id c^^au hỏi" />
                            <input type="text" name="txtValue" value="" id="txtValueChecked" runat="server" placeholder="value" />
                        </div>

                        <div id="div_NhacNho" runat="server">
                            <h5>Lưu ý : Thí sinh nên nộp bài trước 10 giây cuối cùng. Để tránh trường hợp hết thời gian làm bài, thí sinh không thể nộp bài</h5>
                            <h5>Nhấn nút làm bài để hiện bài tập và thời gian làm bài</h5>
                            <asp:Button CssClass="button pink serif round glass popup__finish" ID="btnLamBai" runat="server" OnClick="btnLamBai_Click" OnClientClick="countDown()" Text="Làm Bài" />
                            <%--  <button id="btnTriggerTime" onclick="countDown()">Làm bài</button>--%>
                            <div id="countdown"></div>
                        </div>
                        <div id="div_BaiTap" runat="server">
                            <div class="tracnghiem__heading-box">
                                <div class="content__heading">
                                    <h3 class="tracnghiem__heading">BÀI LUYỆN TẬP</h3>
                                </div>
                            </div>
                            <div>
                                <%-- link test: bai-luyen-tap-chi-tiet-{id_khoi}/{name}-{id_test}.html--%>
                                <asp:Repeater runat="server" ID="rpCauHoiDetals" OnItemDataBound="rpCauHoiDetals_ItemDataBound">
                                    <ItemTemplate>
                                        <fieldset class="tracnghiem__content">
                                            <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                            <div class="tracnghiem__content-box">
                                                <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                </h4>
                                                <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
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
                                            <div style="display: none">
                                                <input type="text" name="value_<%#Eval("question_id") %>" />
                                                <input type="text" name="ID_<%#Eval("question_id") %>" />
                                            </div>
                                        </fieldset>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div>
                                <asp:Repeater ID="rpBaiTapTuaLuan" runat="server">
                                    <ItemTemplate>
                                        <%#Eval("luyentap_baitaptuluan") %>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        </div>

                        <div class="tracnghiem__button" id="div_BtnNopBai" runat="server">
                            <a href="javascript:void(0)" runat="server" id="btnFinish" onclick="confirmDel()" class="button pink serif round glass popup__finish">Nộp Bài</a>
                            <asp:Button Text="text" runat="server" ID="btnNopBai" CssClass="invisible" OnClick="btnNopBai_Click" />
                        </div>
                        <input class="button pink serif round glass popup__finish" id="btnInDe" runat="server" type="button" onclick="printDiv('div_BaiTap')" value="In đề" />
                        <%--lấy ra giá trị thời gian hoàn thành bài luyện tập--%>
                        <div style="display: none;">
                            <input type="text" id="txtFinish" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
