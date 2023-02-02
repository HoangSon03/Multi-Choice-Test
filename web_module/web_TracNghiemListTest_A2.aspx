<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterPage.master" AutoEventWireup="true" CodeFile="web_TracNghiemListTest_A2.aspx.cs" Inherits="web_module_web_TracNghiemListTest_A2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="higlobal" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hislider" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" Runat="Server">
    <style>
        .dalambai {
            pointer-events: none;
        }

        .container {
        }

        .heading-title {
            width: 48.5%;
            margin: auto;
            display: block;
            /* margin: 0% 0px 0 0; */
            padding: 2%;
        }

        .content {
            position: relative;
            height: 464.375px;
            width: 75%;
            margin: auto;
            margin-top: 1%;
        }

        .event__title {
            position: relative;
            margin: 0;
            font-size: 4rem;
            font-weight: 900;
            color: #fff;
            z-index: 1;
            overflow: hidden;
        }

            .event__title span {
                color: #ff022c;
            }

        .card-body {
            padding: 0rem;
        }

        .card-body__test img {
            position: relative;
        }

        .card-header {
            font-family: cursive;
            font-size: 3rem;
            color: #ff4d88;
            -webkit-text-stroke: 2px white;
            position: absolute;
            top: 28.5%;
            margin-left: 15.8%;
            background: transparent;
        }

        .button-53 {
            background-color: #ff5767;
            border: 0 solid #E5E7EB;
            box-sizing: border-box;
            color: #000000;
            display: flex;
            font-family: ui-sans-serif,system-ui,-apple-system,system-ui,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
            font-size: 1rem;
            font-weight: 700;
            justify-content: center;
            line-height: 1.75rem;
            padding: .75rem 1.65rem;
            position: relative;
            text-align: center;
            text-decoration: none #000000 solid;
            text-decoration-thickness: auto;
            width: 100%;
            max-width: 460px;
            position: relative;
            cursor: pointer;
            transform: rotate(-0.5deg);
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
        }

            .button-53:focus {
                outline: 0;
            }

            .button-53:after {
                content: '';
                position: absolute;
                border: 1px solid #000000;
                bottom: 4px;
                left: 4px;
                width: calc(100% - 1px);
                height: calc(100% - 1px);
            }

            .button-53:hover:after {
                bottom: 2px;
                left: 2px;
            }

        @media (min-width: 768px) {
            .button-53 {
                padding: .75rem 3rem;
                font-size: 1.25rem;
            }
        }

        a:hover {
            color: #ffffff;
            text-decoration: none;
        }
    </style>
    <%--    <script>
        function checkTime(id) {
            document.getElementById('<%=txtId.ClientID%>').value = id;
            document.getElementById('<%=btnTime.ClientID%>').click();
        }
    </script>--%>
    <%--<asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
    <div class="main__list">
        <div class="container">

            <image class="heading-title" src="/images/English/list/exammodules.png"></image>

            <div class="row content">
                <asp:Repeater ID="rpTracNghiemListTest" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-12">
                            <div id="card" class="card card__tracnghiem">

                                <div class="card-body card-body__test">
                                    <img class="rounded" src="/images/English/list/back3.png" />
                                    <div class="card-header card-header__test">
                                        <%#Eval("baithicate_name") %>
                                    </div>
                                </div>
                                <div class="card-footer card-footer__test <%#Eval("checktest") %>">
                                    <a class="button-53" href="<%#Eval("test_link") %>" class="candy">Start</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>
<asp:Content ID="Content12" ContentPlaceHolderID="hifootersite" Runat="Server">
</asp:Content>

