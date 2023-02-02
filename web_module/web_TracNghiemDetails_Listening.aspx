<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_TracNghiemDetails_Listening.aspx.cs" Inherits="web_module_web_TracNghiemDetails" %>

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
    <link rel="icon" type="image/png" href="../images/logo_mamnon.png" />
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
    <script src="../../../admin_js/sweetalert.min.js"></script>
    <!-- Learedu Stylesheet -->
    <%--<link href="css/css_trangchu/trangchu.css" rel="stylesheet" />--%>
    <!-- Learedu Color -->
    <link rel="stylesheet" href="/css/color3.css" />
    <script src="/js/jquery-3.5.1.min.js"></script>
    <link href="../css/Loading.css" rel="stylesheet" />
</head>
<style>
    .tracnghiem__heading {
        font-weight: 900;
    }

    .Answer-input {
        text-align: center;
    }

    body {
        -moz-user-select: none; /* Firefox */
        -ms-user-select: none; /* Internet Explorer */
        -khtml-user-select: none; /* KHTML browsers (e.g. Konqueror) */
        -webkit-user-select: none; /* Chrome, Safari, and Opera */
        -webkit-touch-callout: none; /* Disable Android and iOS callouts*/
    }
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
                let arrDung = [];
                var getValues = $("input[name*='dapan_']").map(function () {
                    return $(this);
                }).get();
                for (var index = 0; index < getValues.length; index++) {
                    var dapandung = getValues[index].data("dapan").toUpperCase().split('/');
                    var giatrinhapvao = getValues[index].val().trim().toUpperCase();

                    console.log(dapandung, giatrinhapvao)
                    if (dapandung.includes(giatrinhapvao) == true) {
                        count++;
                        getValues[index].css({
                            "color": "green"
                        });
                        arrDung.push("true");
                    } else {
                        getValues[index].css({
                            "color": "red"
                        });
                        arrDung.push("false");
                    }
                }
                var getGiaTriNhapVao = $("input[name*='dapan_']").map(function () {
                    return $(this).val();
                }).get();
                var getDapAnDung = $("input[name*='dapan_']").map(function () {
                    return $(this).data('dapan');
                }).get();
                document.getElementById('<%=txtValueInput.ClientID%>').value = getGiaTriNhapVao.toString();
                document.getElementById('<%=txtDanAnInput.ClientID%>').value = getDapAnDung.toString();
                console.log(arrDung);
                document.getElementById('<%=txtArr.ClientID%>').value = arrDung.toString();
                //document.getElementById("pointStart").innerHTML = count;
                document.getElementById('<%=txtSoCauDung.ClientID%>').value = count;
                //var changeImage = document.querySelector(".point__img");
                //changeImage.src = "";


                //if (count >= 9) {
                //    changeImage.src = "../../../../images/point-right.gif";
                //} else {
                //    changeImage.src = "../../../../images/point-left.gif";
                //}
            }

            function confirmDel() {
                swal("Do you really want to submit your answer ?",
                    "If you agree, the answer will not be changed.",
                    "warning",
                    {
                        buttons: true,
                        successMode: true
                    }).then(function (value) {
                        if (value == true) {
                            checkValueFinish();
                            DisplayLoadingIcon();
                            var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                            xoa.click();
                        }
                    });
            }
            //close popup
            $(document).ready(function () {
                $(".popup__times").click(function () {
                    document.getElementById("<%=btnClose.ClientID%>").click();
                });
            });
            //fun hiển thị popup
            function showPopUp() {
                $(".popup__content").toggleClass("popup__show");
                $(".popupPoint").toggleClass("popup__show");
                $('.ten-countdown').css("display", "none")
            }
            function checkShow() {
                //debugger;
                var checkNone = document.querySelector(".baitap__content");
                var time = document.getElementById("<%=txtPhutHiden.ClientID%>").value;
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
                    alert('Time Out');
                    checkValueFinish();
                    DisplayLoadingIcon();
                    var xoa = document.getElementById('<%=btnNopBai.ClientID%>');
                    xoa.click();
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
                /*Ẩn Back*/
                document.getElementById("check_back").style.display = 'none';
            }

            function stop() {
                clearTimeout(timeout);
            }
        </script>
        <script>
            function DisplayLoadingIcon() {
                $("#img-loading-icon").show();
            }
            function HiddenLoadingIcon() {
                $("#img-loading-icon").hide();
            }
        </script>
        <div class="loading" id="img-loading-icon" style="display: none">
            <div class="loading">Loading&#8230;</div>
        </div>
        <input type="text" id="txtPhutHiden" runat="server" hidden="hidden" />
        <input type="text" id="txtTitle" runat="server" hidden="hidden" />
        <a href="#" hidden="hidden" runat="server" id="btnCheckCookie" onserverclick="btnCheckCookie_ServerClick">check</a>
        <a href="#" hidden="hidden" runat="server" id="btnClose" onserverclick="btnClose_ServerClick">Close</a>
        <asp:ScriptManager runat="server" />
        <a runat="server" id="check_back" class="button pink--md serif round glass btn__pre" onserverclick="check_back_ServerClick">Back</a>
        <div class="main__tracnghiem" id="popupBlur">
            <a href="javascript:void(0)" class="button pink serif round glass" id="check__none" onclick="checkCookie()">Start</a>
            <div class="popupPoint" id="popupPoint">
                <div class="popup__content">
                    <div class="popup__heading">
                        <div class="popup__point">
                            <div class="point">
                                <%--<span id="pointStart">0</span>/<span id="pointFinish"><%=count%></span>&nbsp;câu đúng--%>
                                <%--<span id="pointStart">0</span>/<span id="pointFinish"><%=count%></span>&nbsp;câu đúng--%>
                                <%--<span id="pointStart"></span>/<span id="pointFinish"><%=count%></span>&nbsp;--%>
                                <%--<span id="pointStart"></span>/<span id="pointFinish"><%=count%></span>&nbsp;--%>
                                <%--<span id="pointStart">0</span>/<span id="pointFinish">25</span>&nbsp;câu đúng--%>
                            </div>
                            <div class="popup__times">
                            </div>
                            <i class="fa fa-times popup__times" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div class="popup__body">
                        <div class="popup__inner">
                            <img class="point__img" src="/images/English/list/success.png" />
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
                                giá trị input nhập vào:
                                <input type="text" value="" id="txtValueInput" runat="server" placeholder="checked" />
                                giá trị đáp án đúng:
                                <input type="text" value="" id="txtDanAnInput" runat="server" placeholder="checked" />
                                giá trị đúng sai
                                <input type="text" value="" id="txtArr" runat="server" placeholder="checked" />
                            </div>
                            <div class="tracnghiem__heading-box">
                                <div class="content__heading">
                                    <h3 class="tracnghiem__heading" id="title"></h3>
                                </div>
                            </div>
                            <%--part 1--%>
                            <div class="Part">
                                <div>
                                    <p class="Part_header">Part 1:</p>
                                    <p>
                                        Questions 1-7
                                    For each question, choose the correct answer.
                                    </p>
                                    <div id="div_Part1_De1" runat="server">
                                        <audio src="../../../web_module/AmThanh_Listening/De_1_Part_1.mp3" controls="controls" />
                                    </div>
                                    <div id="div_Part1_De2" runat="server">
                                        <audio src="../../../web_module/AmThanh_Listening/De_2_Part_1.mp3" controls="controls" />
                                    </div>
                                </div>
                                <div>
                                    <asp:Repeater ID="rpCauHoiPart1" runat="server" OnItemDataBound="rpCauHoiPart1_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                    <div class="tracnghiem__answer">
                                                        <div class="tracnghiem__box col-12 row">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer col-4" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
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
                            </div>
                            <%--part 2--%>
                            <div class="Part">
                                <div>
                                    <p class="Part_header">Part 2:</p>
                                    <p>
                                        Questions 8-13
                                    For each question, choose the correct answer.
                                    </p>
                                    <div id="div_Part2_De1" runat="server">
                                        <audio src="../../../web_module/AmThanh_Listening/De_1_Part_2.mp3" controls="controls" />
                                    </div>
                                    <div id="div_Part2_De2" runat="server">
                                        <audio src="../../../web_module/AmThanh_Listening/De_2_Part_2.mp3" controls="controls" />
                                    </div>
                                </div>
                                <div>
                                    <asp:Repeater ID="rpCauHoiPart2" runat="server" OnItemDataBound="rpCauHoiPart2_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=STT++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                    <div class="tracnghiem__answer">
                                                        <div class="tracnghiem__box col-12 row">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer col-4" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
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
                            </div>
                            <%--part 3--%>
                            <div class="Part">
                                <p class="Part_header">Part 3:</p>
                                <div id="div_Part3_De1" runat="server">
                                    <audio src="../../../web_module/AmThanh_Listening/De_1_Part_3.mp3" controls="controls"></audio>
                                    <br />
                                    <img src="../../../images/English/listening/de1_part3.jpg" />
                                    <%--  <div class="Part">--%>
                                    <p class="Part_header">Answer Part 3:</p>
                                    <div class="Answer col-12 row">
                                        <div class="col-2">
                                            14 :
                                        <input data-dapan="Brokley" class="Answer-input" type="text" name="dapan_1" id="giatri_0" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            15 :
                                        <input data-dapan="half past eight/eight thirty/8.30" class="Answer-input" type="text" name="dapan_2" id="giatri_1" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            16 :
                                        <input data-dapan="blue" class="Answer-input" type="text" name="dapan_3" id="giatri_2" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            17 :
                                        <input data-dapan="receptionist" class="Answer-input" type="text" name="dapan_4" id="giatri_3" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            18 :
                                        <input data-dapan="hall" class="Answer-input" type="text" name="dapan_5" id="giatri_4" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            19 :
                                        <input data-dapan="3/three" class="Answer-input" type="text" name="dapan_6" id="giatri_5" autocomplete="off" />
                                        </div>
                                    </div>
                                </div>
                                <div id="div_Part3_De2" runat="server">
                                    <audio src="../../../web_module/AmThanh_Listening/De_2_Part_3.mp3" controls="controls"></audio>
                                    <br />
                                    <img src="../../../images/English/listening/de2_part3.jpg" />
                                    <%--  <div class="Part">--%>
                                    <p class="Part_header">Answer Part 3:</p>
                                    <div class="Answer col-12 row">
                                        <div class="col-2">
                                            14 :
                                        <input data-dapan="art" class="Answer-input" type="text" name="dapan_1" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            15 :
                                        <input data-dapan="people" class="Answer-input" type="text" name="dapan_2" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            16 :
                                        <input data-dapan="animals" class="Answer-input" type="text" name="dapan_3" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            17 :
                                        <input data-dapan="actings" class="Answer-input" type="text" name="dapan_4" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            18 :
                                        <input data-dapan="eight/8 months" class="Answer-input" type="text" name="dapan_5" autocomplete="off" />
                                        </div>
                                        <div class="col-2">
                                            19 :
                                        <input data-dapan="website" class="Answer-input" type="text" name="dapan_6" autocomplete="off" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <%--</div>--%>

                            <%--part 4--%>
                            <div class="Part">
                                <div>
                                    <p class="Part_header">Part 4:</p>
                                    <p>
                                        Questions 20-25
                                        For each question, choose the correct answer.
                                    </p>
                                    <div id="div_Part4_De1" runat="server">
                                        <audio src="../../../web_module/AmThanh_Listening/De_1_Part_4.mp3" controls="controls" />
                                    </div> 
                                    <div id="div_Part4_De2" runat="server">
                                        <audio src="../../../web_module/AmThanh_Listening/De_2_Part_4.mp3" controls="controls" />
                                    </div>
                                </div>
                                <div>
                                    <asp:Repeater runat="server" ID="rpCauHoiDetals" OnItemDataBound="rpCauHoiDetals_ItemDataBound">
                                        <ItemTemplate>
                                            <fieldset class="tracnghiem__content">
                                                <legend class="tracnghiem__legend">Câu <%=STTT++ %></legend>
                                                <div class="tracnghiem__content-box">
                                                    <h4 class="tracnghiem__question"><%#Eval("noidungcauhoi") %>
                                                    </h4>
                                                    <input type="text" name="txtQuestionID" value="<%#Eval("question_id") %>" hidden="hidden" />
                                                    <div class="tracnghiem__answer">
                                                        <div class="tracnghiem__box col-12 row">
                                                            <asp:Repeater ID="rpCauTraLoi" runat="server">
                                                                <ItemTemplate>
                                                                    <input type="radio" id="test<%#Eval("answer_id") %>" value="<%#Eval("answer_true") %>" onclick="checkValue(<%#Eval("question_id") %>, this.value, <%#Eval("answer_id") %>)" name="check_<%#Eval("question_id") %>" />
                                                                    <label class="tracnghiem-title__answer col-4" for="test<%#Eval("answer_id") %>"><%#Eval("answer_content") %></label>
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
                            </div>
                            <div class="tracnghiem__button">
                                <a href="javascript:void(0)" runat="server" id="btnFinish" onclick="return confirmDel()" class="button pink__finish serif round glass popup__finish">Finish</a>
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
                        <span id="m">minutes</span> :
                        <span id="s">second</span>
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
    <!-- Main JS-->
    <script src="/js/main.js"></script>
    <style>
        .Part {
            BACKGROUND: white;
            /*text-align: center;*/
            border: 3px solid #b51a1a;
            padding: 20px;
            border-radius: 17px;
            box-shadow: 0 7px 10px rgb(0 0 0 / 30%);
            width: 97%;
            background: #fff;
            margin: 0 0 21px 0;
        }

        .Part1 {
            BACKGROUND: white;
            /* text-align: center; */
            border: 3px solid #b51a1a;
            padding: 20px;
            border-radius: 17px;
            box-shadow: 0 7px 10px rgb(0 0 0 / 30%);
            width: 97%;
            background: #fff;
            margin: 0 0 21px 0;
        }

        .Part2 {
            width: 100%;
            border: 4px solid #b51a1a;
            border-radius: 12px;
            text-align: center;
        }

            .Part2 img {
                border-radius: 17px;
                margin-left: auto;
                margin-right: auto;
            }

            .Part2 p {
                font-size: 20px;
                font-weight: 600;
                padding: 0% 0% 0% 2%;
            }

        spea

        .Answer {
            width: 100%;
            display: flex;
            margin: 1% 0% 1% 0%;
        }

        .Part_header {
            text-align: center;
            font-weight: 900;
            background: linear-gradient(to right, #ed213a, #93291e);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            margin: 0;
            padding: 0 7px;
            font-size: 30px;
        }
    </style>
    <script type='text/javascript'>
        <%-- Chống chuột phải --%>
        var message = "NoRightClicking"; function defeatIE() { if (document.all) { (message); return false; } } function defeatNS(e) { if (document.layers || (document.getElementById && !document.all)) { if (e.which == 2 || e.which == 3) { (message); return false; } } } if (document.layers) { document.captureEvents(Event.MOUSEDOWN); document.onmousedown = defeatNS; } else { document.onmouseup = defeatNS; document.oncontextmenu = defeatIE; } document.oncontextmenu = new Function("return false")
        <%-- Chống copy paste --%>
        $('body').bind('copy paste', function (e) {
            e.preventDefault(); return false;
        });

        //ngăn dùng F12, ctr-shift-i .... để inspect html
        document.onkeydown = function (e) {
            if (event.keyCode == 123) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'I'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'C'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.shiftKey && e.keyCode == 'J'.charCodeAt(0)) {
                return false;
            }
            if (e.ctrlKey && e.keyCode == 'U'.charCodeAt(0)) {
                return false;
            }
        }

        /*hàm ngăn copy paste test*/
        document.addEventListener("contextmenu", function (evt) {
            evt.preventDefault();
        });

        document.addEventListener("copy", function (evt) {
            evt.clipboardData.setData("text/plain", "");
            evt.preventDefault();
        });
    </script>
</body>
</html>
