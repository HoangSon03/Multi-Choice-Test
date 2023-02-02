<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_TaoCauHoiLuyenTap_version2.aspx.cs" Inherits="admin_page_module_function_module_CauHoiLuyenTap_module_TaoCauHoiLuyenTap_version2" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script>
        function checkNULLBai() {
            var CityName = document.getElementById('<%= txtTenBai.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Tên bài học không được để trống!', '', 'warning').then(function () { CityName.focus(); });
                return false;
            }
            return true;
        }
    </script>
    <script>
        function myChange(id) {
            document.getElementById("<%=txtHinhThucThi.ClientID%>").value = id;
            if (id == 1) {
                document.getElementById("dv_TracNghiem").style.display = "block";
                document.getElementById("dv_TuLuan").style.display = "none";
            }
            if (id == 2) {
                document.getElementById("dv_TuLuan").style.display = "block";
                document.getElementById("dv_TracNghiem").style.display = "none";
            }
            if (id == 3) {
                document.getElementById("dv_TuLuan").style.display = "block";
                document.getElementById("dv_TracNghiem").style.display = "block";
                document.getElementById("div_LuuY").style.display = "block";
            }
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
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row header_header">

                    <div class="col-12">
                        <label class="col-2 col-form-label">&nbsp;&nbsp;&nbsp;Link youtube:</label>
                        <div class="col-8">
                            <input type="text" class="form-control" id="txtLink" runat="server" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="col-12">
                        <label class="col-2 col-form-label">&nbsp;&nbsp;&nbsp;Tên bài:</label>
                        <div class="col-8">
                            <input type="text" class="form-control" id="txtTenBai" runat="server" />
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class="col-sm-12">
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlKhoi" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlKhoi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="btn btn-primary" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddlChuong" runat="server" CssClass="btn btn-primary" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <%--Ghi chú: sử dụng 0.25 or 0.5 or 1--%>
                    <div>
                        <input type="radio" id="html" name="fav_language" value="1" onchange="myChange(1)">
                        <label for="html">Trắc nghiệm</label><br>
                        <input type="radio" id="css" name="fav_language" value="2" onchange="myChange(2)">
                        <label for="css">Tự luận</label><br>
                        <input type="radio" id="javascript" name="fav_language" value="3" onchange="myChange(3)">
                        <label for="javascript">Cả 2</label>
                        <br />
                    </div>
                    <div id="div_LuuY" style="display:none;color:red">
                        (*)Tỉ lệ điểm ở các mức độ thuộc tự luận không được  vượt quá ma trận đề
                        
                    </div>
                    <div id="dv_TracNghiem" style="display:none">
                       Tỉ lệ ma trận của đề thi :
                        <br />
                        Nhận biết :
                        <input type="text" id="txtTracNghiem_NhanBiet" runat="server" style="width:30px"/>
                        Thông hiểu :
                        <input type="text" id="txtTracNghiem_ThongHieu" runat="server" style="width:30px"/>
                        Vận dụng :
                        <input type="text" id="txtTracNghiem_VanDung" runat="server" style="width:30px"/>
                        Vận dung cao :
                        <input type="text" id="txtTracNghiem_VanDungCao" runat="server" style="width:30px"/>
                        Điểm mỗi câu :
                        <asp:DropDownList  ID="ddlDiem" runat="server">
                            <asp:ListItem Value="5">0.2</asp:ListItem>
                            <asp:ListItem Value="4">0.25</asp:ListItem>
                            <asp:ListItem Value="2">0.5</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                        </asp:DropDownList>
                        <%--<input type="text" id="txtTracNghiem_Diem" runat="server" style="width:30px"/>--%>
                       
                    </div>
                    <div id="dv_TuLuan"  style="display:none">
                        Tự luận:
                        <br />
                       Điểm nhận biết
                        <input type="text" id="txtTuLuan_NhanBiet" runat="server" style="width:30px"/>
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_NhanBiet" onchange="fucnTongDiem()" runat="server" style="width:30px"/>
                        <br />
                       Điểm thông hiểu 
                        <input type="text" id="txtTuLuan_ThongHieu" runat="server" style="width:30px"/>
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_ThongHieu" onchange="fucnTongDiem()" runat="server" style="width:30px"/>
                        <br />
                       Điểm vận dụng 
                        <input type="text" id="txtTuLuan_VanDung" runat="server" style="width:30px"/>
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_VanDung" onchange="fucnTongDiem()" runat="server" style="width:30px"/>
                        <br />
                       Điểm vận dung cao 
                        <input type="text" id="txtTuLuan_VanDungCao"  runat="server" style="width:30px"/>
                        Điểm mỗi câu :
                        <input type="text" id="txtTuLuan_Diem_VanDungCao" onchange="fucnTongDiem()" runat="server" style="width:30px"/>
                        <br />
                        <input hidden="hidden"  type="text" id="txtTongDiem" style="width:30px"/>
                    </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <input id="txtHinhThucThi" type="text" runat="server" />
            <asp:Button Text="Tạo bài luyện tập" CssClass="btn btn-primary" runat="server" ID="btnLuu" OnClick="btnLuu_Click" />
        </div>
    </div>
    <script>
        function fucnTongDiem() {

        }
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

