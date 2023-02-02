<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_BieuDoSoLanLamBai.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_admin_BieuDoSoLanLamBai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">

    <asp:DropDownList ID="ddlThongKe" runat="server" OnSelectedIndexChanged="ddlThongKe_SelectedIndexChanged" AutoPostBack="true" CssClass="form-group">
        <asp:ListItem Value="0" Text="Chọn thống kê" />
        <asp:ListItem Value="1" Text="Trong tuần" />
        <asp:ListItem Value="2" Text="Trong tháng" />
        <asp:ListItem Value="3" Text="Theo ngày" />
    </asp:DropDownList>
    <div id="div_TuNgayToiNgay" runat="server" class="col-12" style="margin-top: 10px">
        <div class="col-4" style="margin-right: 10px">
            <label>Từ ngày:</label>
            <input type="date" id="dteTuNgay" class="form-control" runat="server" />
        </div>
        <div class="col-4">
            <label>Đến ngày:</label>
            <input type="date" id="dteDenNgay" class="form-control" runat="server" />
        </div>
        <br />
        <div class="col-5">
            <asp:Button CssClass="btn btn-primary" ID="btnChon" runat="server" OnClick="btnChon_Click" Text="Chọn"></asp:Button>
        </div>
    </div>

    <canvas id="myChart" style="width: 100%"></canvas>

    <div style="display: none">
        <input type="text" id="txtNgay" runat="server" />
        <input type="text" id="txtSoLanLamBai" runat="server" />
        <input type="text" id="txtTenHocSinh" runat="server" />
        <input type="text" id="txtHocSinhCode" runat="server" />
        <input type="text" id="txtTitle" value="Thống kê số lần làm bài tập của các học sinh" />
    </div>

    <script>
        var kq_HocSinhCode = document.getElementById("<%=txtHocSinhCode.ClientID%>").value.replaceAll("'", '"');
        var array_hocsinhcode = JSON.parse("[" + kq_HocSinhCode + "]");

        var kq_NgayKiemTra = document.getElementById("<%=txtNgay.ClientID%>").value.replaceAll("'", '"');
        var array_TenNgayKiemTra = JSON.parse("[" + kq_NgayKiemTra + "]");

        var kq_SoLanLamBai = document.getElementById("<%=txtSoLanLamBai.ClientID%>").value;
        var elements_SoLanLamBai = kq_SoLanLamBai.replaceAll("*", '"')
        var array_SoLanLamBai = JSON.parse("[" + elements_SoLanLamBai + "]");

        var kq_tenhocsinh = document.getElementById("<%=txtTenHocSinh.ClientID%>").value.replaceAll("'", '"');
        var array_tenhocsinh = JSON.parse("[" + kq_tenhocsinh + "]");

        console.log(kq_HocSinhCode);
        console.log(array_hocsinhcode);

        var lineChartData = {
            datasets: []
        },
            array = array_SoLanLamBai;

        var delayInMillisecond = 1000; // 1 second

        setTimeout(
            array.forEach(function (a, i = 0) {
                lineChartData.datasets.push(
                    {
                        code: array_hocsinhcode[i],
                        label: array_tenhocsinh[i++],
                        borderColor: '#' + (0x1000000 + Math.random() * 0xffffff).toString(16).substr(1, 6),
                        backgroundColor: "#fff",
                        fill: false,
                        data: JSON.parse(a),
                        borderWidth: 2,
                    });
            }), delayInMillisecond)


        var options = {
            responsive: true,
            axisY: {
                onlyInteger: true
            },
            tooltips: {
                enabled: true
            },
            elements: {
                line: {
                    tension: 0.3
                }
            },
            scales: {
                yAxes: [{
                    display: true,
                    ticks: {
                        beginAtZero: true,
                        max: 10,
                        min: 0,
                        stepSize: 1,
                    }
                }]
            },
            title: {
                display: true,
                text: "Thống kê số lần làm bài tập của các học sinh",
            },

        };

        var data = {
            labels: array_TenNgayKiemTra, // ngày làm bài
            datasets: lineChartData.datasets
        }

        var lineCanvas = document.getElementById('myChart');
        var ctx = lineCanvas.getContext('2d');
        elements = [];

        var chartInstance = new Chart(ctx, {
            type: 'line',
            data: data,
            options: options,
        });

        lineCanvas.onclick = function (e) {
            var firstPoint = chartInstance.getElementAtEvent(e)[0];
            if (firstPoint) {
                var first_point_index = firstPoint._index
                //console.log("+1 first_point_index::")
                //console.log(first_point_index)

                var firstPoint_dataset_index = firstPoint._datasetIndex
                //console.log("+2 firstPoint_dataset_index::")
                //console.log(firstPoint_dataset_index)

                var label = chartInstance.data.labels[firstPoint._index];
                //console.log("+3 label::")
                console.log(label)

                var name = chartInstance.data.datasets[firstPoint._datasetIndex].label;
                //console.log("+4 name:")
                // console.log(name)
                var value = chartInstance.data.datasets[firstPoint._datasetIndex].data[firstPoint._index];

                var code = chartInstance.data.datasets[firstPoint_dataset_index].code;
                //  console.log("+4 code:")
                // console.log(code)
                //alert("Ngày: " + (label) + "  Số lần làm bài :" + (value) + "   Tên: "2 + (name));
                window.location.replace("admin-chi-tiet-lam-bai-tap-" + code);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
