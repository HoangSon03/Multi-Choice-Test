<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_TracNghiemDetails.aspx.cs" Inherits="web_module_web_TracNghiemDetails" %>

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
    <script src="../../admin_js/sweetalert.min.js"></script>
    <!-- Learedu Stylesheet -->
    <%--<link href="css/css_trangchu/trangchu.css" rel="stylesheet" />--%>
    <!-- Learedu Color -->
    <link rel="stylesheet" href="/css/color3.css" />
    <script src="https://plus.google.com/js/client:platform.js"></script>
</head>
<style>
    
</style>
<body>
    <form id="form1" runat="server">
        <script>
            function checkValue(ques_id, value, id_check) {
                //var getValue = $("input[name='check_" + ques_id + "']:checked").val();
                $("input[name='value_" + ques_id + "']").val(value);
                $("input[name='ID_" + ques_id + "']").val(id_check);
            }
            function checkValueFinish() {
                //debugger;
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

                var getValues = $("input[name*='dapan_']").map(function () {
                    return $(this);
                }).get();
                for (var index = 0; index < getValues.length; index++) {
                    var dapandung = getValues[index].data("dapan");
                    var giatrinhapvap = getValues[index].val();

                    console.log(dapandung, giatrinhapvap)
                    if (dapandung == giatrinhapvap.toUpperCase()) {
                        count++;
                        getValues[index].css({
                            "color": "green"
                        });
                    } else {
                        getValues[index].css({
                            "color": "red"
                        });
                    }
                }

                document.getElementById("pointStart").innerHTML = count;
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;
                var changeImage = document.querySelector(".point__img");
                changeImage.src = "";


                if (count >= 9) {
                    changeImage.src = "../../images/point-right.gif";
                } else {
                    changeImage.src = "../../images/point-left.gif";
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
                            checkValueFinish();
                            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                            xoa.click();
                            $(document).ready(function () {
                                $(".popup__content").toggleClass("popup__show");
                                $(".popupPoint").toggleClass("popup__show");
                                $('.ten-countdown').css("display", "none")
                            });
                        }
                    });
                $(document).ready(function () {

                    $(".popup__times").click(function () {
                        // debugger;
                        $(".popupPoint").removeClass("popup__show");
                        $(".popup__content").removeClass("popup__show");
                        var getValue = document.getElementById('<%=txtValueChecked.ClientID%>').value.split(',');
                        var getId = document.getElementById('<%=txtChecked.ClientID%>').value.split(',');

                        //debugger;
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

            function checkShow() {
                var checkNone = document.querySelector(".baitap__content");
                document.querySelector("#check__none").style.display = "none";
                checkNone.classList.add("baitap__show");
                document.getElementById('h_val').value = "00";
                document.getElementById('m_val').value = document.getElementById("<%=txtPhutHiden.ClientID%>").value;
                document.getElementById('s_val').value = "00";
                document.getElementById('title').innerHTML = document.getElementById("<%=txtTitle.ClientID%>").value;
                start();
            }
            function checkCookie() {
                document.getElementById('<%=btnCheckCookie.ClientID%>').click();
            }


            //Timer

            var h = null; // Giờ
            var m = null; // Phút
            var s = null; // Giây

            var timeout = null; // Timeout

            function start() {
                /*BƯỚC 1: LẤY GIÁ TRỊ BAN ĐẦU*/
                if (h === null) {
                    h = parseInt(document.getElementById('h_val').value);
                    m = parseInt(document.getElementById('m_val').value);
                    s = parseInt(document.getElementById('s_val').value);
                }

                /*BƯỚC 1: CHUYỂN ĐỔI DỮ LIỆU*/
                // Nếu số giây = -1 tức là đã chạy ngược hết số giây, lúc này:
                //  - giảm số phút xuống 1 đơn vị
                //  - thiết lập số giây lại 59
                if (s === -1) {
                    m -= 1;
                    s = 59;
                }

                // Nếu số phút = -1 tức là đã chạy ngược hết số phút, lúc này:
                //  - giảm số giờ xuống 1 đơn vị
                //  - thiết lập số phút lại 59
                if (m === -1) {
                    h -= 1;
                    m = 59;
                }

                // Nếu số giờ = -1 tức là đã hết giờ, lúc này:
                //  - Dừng chương trình
                if (h == -1) {
                    clearTimeout(timeout);
                    alert('Hết giờ');
                    return false;
                }

                /*BƯỚC 1: HIỂN THỊ ĐỒNG HỒ*/
                document.getElementById('h').innerText = h.toString();
                document.getElementById('m').innerText = m.toString();
                document.getElementById('s').innerText = s.toString();

                /*BƯỚC 1: GIẢM PHÚT XUỐNG 1 GIÂY VÀ GỌI LẠI SAU 1 GIÂY */
                timeout = setTimeout(function () {
                    s--;
                    start();
                }, 1000);
            }

            function stop() {
                clearTimeout(timeout);
            }
        </script>
        <input type="text" id="txtPhutHiden" runat="server" hidden="hidden" />
        <input type="text" id="txtTitle" runat="server" hidden="hidden" />
        <a href="#" hidden="hidden" runat="server" id="btnCheckCookie" onserverclick="btnCheckCookie_ServerClick">check</a>
        <asp:ScriptManager runat="server" />
        <a href="/trang-chu" runat="server" class="button pink--md serif round glass btn__pre">Quay lại</a>
        <div class="main__tracnghiem" id="popupBlur">
            <a href="javascript:void(0)" class="button pink serif round glass" id="check__none" onclick="checkCookie()">Bắt đầu làm bài</a>
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
                            <img class="point__img" src="../../images/point-left.gif" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="baitap__content">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container">
                            <div style="display: none">
                                <input type="text" value="" id="txtSoCauDung" runat="server" placeholder="số câu đúng" />
                                <input type="text" name="txtChecked" value="" id="txtChecked" runat="server" placeholder="checked" />
                                <input type="text" value="" id="txtIDQuestion" runat="server" placeholder="id c^^au hỏi" />
                                <input type="text" name="txtValue" value="" id="txtValueChecked" runat="server" placeholder="value" />
                            </div>
                            <div class="tracnghiem__heading-box">
                                <div class="content__heading">
                                    <h3 class="tracnghiem__heading" id="title"></h3>
                                </div>
                            </div>
                            <div class="Part">
                                <p >Part 1:</p>
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

                                            <div style="display: block">
                                                <input type="text" name="value_<%#Eval("question_id") %>" />
                                                <input type="text" name="ID_<%#Eval("question_id") %>" />
                                            </div>
                                        </fieldset>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                         <%--   
                            <div class="Part2">
                                <img src="/images/English/B1/Part1_1.png" />
                                <img src="/images/English/B1/Part1_2.png" />
                                <p>Answer</p>
                                <div class="Answer">
                                    <div>
                                        6 :
                                        <input data-dapan="G" class="Answer-input" type="text" name="dapan_1" />
                                    </div>
                                    <div>
                                        7 :
                                        <input data-dapan="C" class="Answer-input" type="text" name="dapan_2" />
                                    </div>
                                    <div>
                                        8 :
                                        <input data-dapan="E" class="Answer-input" type="text" name="dapan_3" />
                                    </div>
                                    <div>
                                        9 :
                                        <input data-dapan="B" class="Answer-input" type="text" name="dapan_4" />
                                    </div>
                                    <div>
                                        10 :
                                        <input data-dapan="H" class="Answer-input" type="text" name="dapan_5" />
                                    </div>
                                </div>
                            </div>--%>
                            <%--<asp:Repeater runat="server" ID="Rp_cau_hoi_lon" OnItemDataBound="Rp_cau_hoi_lon_ItemDataBound">
                                <ItemTemplate>
                                    <fieldset class="tracnghiem__content">
                                        <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                        <div class="tracnghiem__content-box">
                                            <img src="<%#Eval("QuestionBig_content") %>" class="tracnghiem__question" />

                                            <input type="text" name="txtQuestionID" value="<%#Eval("QuestionBig_id") %>" hidden="hidden" />
                                           
                                            <asp:Repeater runat="server" ID="Rp_cau_hoi_lon" OnItemDataBound="rpcauhoi_ItemDataBound">
                                                <ItemTemplate>
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
                                                    <div style="display: block">
                                                        <input type="text" name="value_<%#Eval("question_id") %>" />
                                                        <input type="text" name="ID_<%#Eval("question_id") %>" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </fieldset>
                                </ItemTemplate>
                            </asp:Repeater>--%>
                          <%--  <div class="Part2">
                                <img src="/images/English/B1/Part1_4.png" />
                                <img src="/images/English/B1/Part1_5.png" />
                                <p>Answer</p>
                                <div class="Answer">
                                    <div>
                                        16 :
                                        <input data-dapan="G" class="Answer-input" type="text" name="dapan_6" />
                                    </div>
                                    <div>
                                        17 :
                                        <input data-dapan="D" class="Answer-input" type="text" name="dapan_7" />
                                    </div>
                                    <div>
                                        18 :
                                        <input data-dapan="A" class="Answer-input" type="text" name="dapan_8" />
                                    </div>
                                    <div>
                                        19 :
                                        <input data-dapan="B" class="Answer-input" type="text" name="dapan_9" />
                                    </div>
                                    <div>
                                        20 :
                                        <input data-dapan="E" class="Answer-input" type="text" name="dapan_11" />
                                    </div>
                                </div>
                            </div>--%>
                            <%--<asp:Repeater runat="server" ID="Rp_cau_hoi_lon2" OnItemDataBound="Rp_cau_hoi_lon2_ItemDataBound">
                                <ItemTemplate>
                                    <fieldset class="tracnghiem__content">
                                        <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                        <div class="tracnghiem__content-box">
                                            <img src="<%#Eval("QuestionBig_content") %>" class="tracnghiem__question" />

                                            <input type="text" name="txtQuestionID" value="<%#Eval("QuestionBig_id") %>" hidden="hidden" />
                                            <asp:Repeater runat="server" ID="Rp_cau_hoi_lon2" OnItemDataBound="Rp_cau_hoi_lon2_ItemDataBound1">
                                                <ItemTemplate>
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
                                                    <div style="display: block">
                                                        <input type="text" name="value_<%#Eval("question_id") %>" />
                                                        <input type="text" name="ID_<%#Eval("question_id") %>" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </fieldset>
                                </ItemTemplate>
                            </asp:Repeater>--%>

                            <%--<div class="Part2">
                                <img src="/images/English/B1/Part1_7.png" />
                                <p>Answer</p>
                                <div class="Answer">
                                    <div>
                                        27 :
                                        <input data-dapan="IT" class="Answer-input" type="text" name="dapan_12" />
                                    </div>
                                    <div>
                                        28 :
                                        <input data-dapan="MOST" class="Answer-input" type="text" name="dapan_13" />
                                    </div>
                                    <div>
                                        29 :
                                        <input data-dapan="ALL" class="Answer-input" type="text"name="dapan_14"/>
                                    </div>
                                    <div>
                                        30 :
                                        <input data-dapan="FORWARD" class="Answer-input" type="text" name="dapan_15" />
                                    </div>
                                    <div>
                                        31 :
                                        <input data-dapan="AT" class="Answer-input" type="text" name="dapan_16" />
                                    </div>
                                    <div>
                                        32 :
                                        <input data-dapan="IF" class="Answer-input" type="text" name="dapan_17" />
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                        <div class="tracnghiem__button">
                            <a href="javascript:void(0)" runat="server" id="btnFinish" onclick="return confirmDel()" class="button pink__finish serif round glass popup__finish">Nộp Bài</a>
                            <asp:Button Text="text" runat="server" ID="btnNopBai" CssClass="invisible" OnClick="btnNopBai_Click" />
                            <br />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="ten-countdown">
                    <%-- <strong>Thời Gian:
                    <br />
                    </strong>--%>
                    <input type="text" id="h_val" placeholder="Giờ" value="" hidden="hidden" />
                    <input type="text" id="m_val" placeholder="Phút" value="" hidden="hidden" />
                    <input type="text" id="s_val" placeholder="Giây" value="" hidden="hidden" />
                    <%--<input type="button" value="Start" onclick="start()" />
                <input type="button" value="Stop" onclick="stop()" />--%>
                    <div>
                        <span id="h" hidden="hidden">Giờ</span>
                        <span id="m">Phút</span> :
                        <span id="s">Giây</span>
                    </div>
                </div>

            </div>


            <%--<div id="ten-countdown"></div>--%>
        </div>

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
    <!-- Google Maps JS -->
    <script src="http://maps.google.com/maps/api/js?key=AIzaSyC0RqLa90WDfoJedoE3Z_Gy7a7o8PCL2jw"></script>
    <script src="/js/gmaps.min.js"></script>
    <script src="/js/isotop.js"></script>
    <script src="/js/index.js"></script>
    <!-- Main JS-->
    <script src="/js/main.js"></script>
</body>
</html>
