<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_KetQuaBaiLuyenTap.aspx.cs" Inherits="admin_page_module_function_module_KetQuaHocTap_admin_KetQuaBaiLuyenTap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">

    <div class="main-omt">
        <div class="omt-header">
            <i class="fa fa-list-alt omt__icon" aria-hidden="true"></i>
            <h4 class="header-title">Kết quả luyện tập của học sinh</h4>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="omt-top">
                    <div class="wrapper__select">
                        <div class="col-3" style="margin-right: 10px;">
                            <input type="date" id="dteTuNgay" runat="server" class="form-control" />
                        </div>
                        <div class="col-3" style="margin-right: 10px;">
                            <input type="date" id="dteDenNgay" runat="server" class="form-control" />
                        </div>
                        <div class="col-2" style="margin-right: 10px;">
                            <asp:DropDownList ID="ddlLop" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLop_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-2" style="margin-right: 10px;">
                            <asp:DropDownList ID="ddlHocSinh" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-1">
                            <a href="#" id="btnXem" class="btn btn-primary" runat="server" onserverclick="btnXem_ServerClick">Xem</a>
                        </div>
                    </div>
                </div>
                <div style="display: none">
                    <input type="text" id="txtHocSinh" runat="server" />
                    <input type="text" id="txtRatting" runat="server" />
                    <a href="#" id="btnChiTietHocSinh" runat="server"></a>
                </div>
                <div class="wrapper__select">
                    <table class="table table-striped table-hover table_baogiang">
                        <thead>
                            <tr class="tbheader">
                                <th scope="col">#</th>
                                <th scope="col">Tên học sinh</th>
                                <th scope="col">Lớp</th>
                                <th scope="col">Môn học</th>
                                <th scope="col">Bài tập</th>
                                <th scope="col">Điểm</th>
                                <th scope="col">Ngày làm bài</th>
                                <th scope="col">Thời gian</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%=STT++%></td>
                                        <td><%#Eval("hocsinh_name") %></td>
                                        <td><%#Eval("lop_name") %></td>
                                        <td><%#Eval("monhoc_name") %></td>
                                        <td><%#Eval("luyentap_name") %></td>
                                        <td><%#Eval("resulttest_result") %></td>
                                        <td><%#Eval("resulttest_datetime", "{0: dd-MM-yyyy}") %> </td>
                                        <td><%#Eval("result_thoigianlambai") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <style>
        .table tr.tbheader {
            background: #a3a7a199;
        }

        .table_baogiang td, .table_baogiang th {
            text-align: center;
            border: 1px solid #2d3846 !important;
        }

        .main-omt {
            border: 1px solid #32c5d2;
            background-color: #fff;
        }

            .main-omt .omt-header {
                background-color: #32c5d2;
                padding: 4px 7px;
                display: flex;
            }

        .omt-header .header-title {
            font-size: 20px;
            padding: 10px 10px;
            color: white;
        }

        .omt-header .omt__icon {
            font-size: 30px;
            padding: 8px 10px;
            color: white;
        }

        .omt-top {
            display: flex;
            /*padding: 0 20px;*/
        }

            .omt-top .form-omt {
                width: 17%;
                height: 40px !important;
                margin-right: 15px;
                margin-top: 10px;
            }

        .fixed-table-container {
            padding-top: 20px;
        }

        .table-left {
            width: 33.333% !important;
            min-height: 1px;
            padding-left: 15px;
            padding-right: 15px;
        }

        .portlet {
            width: 100% !important;
            border: 1px solid #e7ecf1 !important;
        }

        .portlet-title {
            border-bottom: 1px solid #eef1f5;
            min-height: 48px;
        }

        .caption-title {
            padding: 0;
            display: inline-block;
            margin-left: 5%;
            margin-top: 5px;
            font-size: 25px;
            font-weight: bold;
        }

        .group-tabs ul {
            width: 100%;
        }

            .group-tabs ul li {
                position: relative;
                display: inline-block;
                width: 100%;
                min-height: 20px;
                padding: 10px;
                border-bottom: 1px solid #F4F6F9;
            }

        .click {
            background-color: red;
        }

        .form-group .table-title p {
            font-size: 0.9rem;
        }

        .table-raiting {
            position: relative;
            top: -15px;
            margin: 0;
        }

        .wrapper__select {
            margin-top: 10px;
            margin-left: 10px;
            width: 100%;
        }

            .wrapper__select table {
                width: 98.5%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

