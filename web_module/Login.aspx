<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="web_module_Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Đăng Nhập</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../images/logo_mamnon.png" rel="icon" type="image/png" />
    <!--===============================================================================================-->
    <%--<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>--%>
    <%--<link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="css/css_login/util.css">
	<link rel="stylesheet" type="text/css" href="css/css_login/style.css">--%>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/animate.min.css" rel="stylesheet" />
    <link href="../css/css_login/style.css" rel="stylesheet" />
    <link href="../css/css_login/util.css" rel="stylesheet" />
    <link href="../css/css_login/animate.css" rel="stylesheet" />
    <script src="../admin_js/sweetalert.min.js"></script>
</head>
<body>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-pic js-tilt">
                    <img src="../images/logo.png" />
                </div>

                <form class="login100-form validate-form" id="frmLoign" runat="server">
                    <span class="login100-form-title">ĐĂNG NHẬP
                    </span>

                    <div class="wrap-input100 validate-input">
                        <input runat="server" id="txtUsername" class="input100" type="text" name="email" placeholder="User name" autocomplete="off">
                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-user" aria-hidden="true"></i>
                        </span>
                    </div>
                    <asp:Button ID="btnLogin" runat="server" class="btn_login" OnClientClick="return checknull()" OnClick="btnLogin_Click" Text="login" />
                    <%--<div class="container-login100-form-btn">
                        <a id="btnLogin" class="btn_login" runat="server"  onserverclick="btnLogin_ServerClick">Đăng nhập</a>
					</div>--%>
                </form>
            </div>
        </div>
    </div>
    <script>
        function checknull() {
            var checkName = document.getElementById('<%= txtUsername.ClientID%>');
            if (checkName.value.trim() == "") {
                swal('Tên đăng nhập không được để trống', '', 'warning').then(function () { checkName.focus(); });
                return false;
            }
            return true;
        }
    </script>




    <!--===============================================================================================-->
    <%--	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="vendor/select2/select2.min.js"></script>
	<script src="vendor/tilt/tilt.jquery.min.js"></script>--%>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/popper.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/select2.min.js"></script>
    <script src="../js/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <script src="../js/main.js"></script>
    <script src="../admin_js/sweetalert.min.js"></script>
    <script src="../admin_js/azia.js"></script>

    <script src="../admin_js/datepicker.min.js"></script>
</body>
</html>
