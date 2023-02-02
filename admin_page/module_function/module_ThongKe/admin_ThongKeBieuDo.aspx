<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ThongKeBieuDo.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_admin_ThongKeBieuDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="card card-block">
        <asp:Repeater ID="rpGetName" runat="server">
            <ItemTemplate>
                <label style="justify-content: center; display: flex; font-size: 30px;"><%#Eval("hocsinh_name") %></label><br />
            </ItemTemplate>
        </asp:Repeater>
        <div class="row header_header">
            <asp:UpdatePanel ID="upLop" runat="server">
                <ContentTemplate>
                    <div class="wrapper__select">
                        <div class="col-2 flex-row">
                            <label>Từ ngày:</label>
                            <input type="date" id="dteTuNgay" runat="server" class="form-control" />
                        </div>
                        <div class="col-2 flex-row ml-2 mr-2" style="margin-right: 10px;">
                            <label>Đến ngày:</label>
                            <input type="date" id="dteDenNgay" runat="server" class="form-control" />
                        </div>
                        <div class="col-3 flex-row">
                            <label>Chọn môn học:</label>
                            <asp:DropDownList ID="ddlMon" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMon_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="col-3 ml-2 mr-2 flex-row">
                            <label>Chọn bài tập:</label>
                            <asp:DropDownList ID="ddlKiemTra" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-1">
                            <a id="btnKetQua" runat="server" class="btn btn-primary" onserverclick="btnKetQua_ServerClick">Xem</a>
                        </div>
                    </div>
                    <div style="display: none">
                        <input type="text" id="txtTenBaiKiemTra" runat="server" />
                        <input type="text" id="txtDiemBaiKiemTra" runat="server" />
                        <input type="text" id="txtTitle" value="Day la ten bieu do" />
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%-- <input type="text" id="Text1" runat="server" />
        <input type="text" id="Text2" runat="server" />--%>

        <br />
        <canvas id="myChart"></canvas>
    </div>
    <script>
        function myKetQuaBaiKiemTra() {

            var kq_TenBaiKiemTra = document.getElementById("<%=txtTenBaiKiemTra.ClientID%>").value.split(';');
            //var array_TenBaiKiemTra = JSON.parse("[" + kq_TenBaiKiemTra + "]");

            var kq_DiemBaiKiemTra = document.getElementById("<%=txtDiemBaiKiemTra.ClientID%>").value.replace(',', '.');
            //var array_DiemBaiKiemTra = JSON.parse("[" + kq_DiemBaiKiemTra + "]");
            var array_DiemBaiKiemTra = kq_DiemBaiKiemTra.split(';');


            var data = {
                //can truyen ten vao day
                labels: kq_TenBaiKiemTra,
                datasets: [{
                    label: ["Điểm"],
                    //can truyen diem vao day
                    data: array_DiemBaiKiemTra,
                    //mau sac dua theo diem so
                    borderColor: "blue",
                    borderWidth: 2,

                }]
            }
            var options = {
                responsive: true,
                scales: {
                    yAxes: [{
                        display: true,
                        ticks: {
                            beginAtZero: true,
                            max: 10,
                            min: 0
                        }
                    }],
                },
                title: {
                    display: true,
                    text: "Biểu đồ kết quả làm bài",
                },
                legend: { display: false },
            };
            var ctx = document.getElementById("myChart");

            var chartInstance = new Chart(ctx, {
                type: 'line',
                data: data,
                options: options
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
