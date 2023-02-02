<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ThongKeBieuDo_4.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_admin_ThongKeBieuDo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chartjs-plugin-datalabels@0.7.0"></script>
    <script src="https://code.jquery.com/jquery-latest.js"></script>
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

        <div style="display: none;">
            <input type="text" id="txtTenMonHoc" runat="server" />
            <input type="text" id="txtSoLanKiemTra" runat="server" />
        </div>
        <br />
        <dx:ASPxPopupControl ID="popupControl" runat="server" Width="700" Height="700" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl"
            HeaderText="Chi tiết" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <asp:UpdatePanel ID="udPopup" runat="server">
                        <ContentTemplate>
                            <div class="popup-main">
                                <div class="div_content col-12">
                                    <asp:Repeater ID="rpGetNameStudent" runat="server">
                                        <ItemTemplate>
                                            <div class="col-12 form-group">
                                                <label class="col-2 form-control-label">Tên học sinh:</label>
                                                <div class="col-10">
                                                    <h6 class="card-title cardTitleSize"><%#Eval("hocsinh_name") %></h6>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
        <canvas id="pie-chart" onclick="btnTrungGian()"></canvas>
        <a id="btnThem" runat="server" onserverclick="btnThem_ServerClick" hidden>Test</a>
    </div>
    <script>
        <%--function btnTrungGian() {
            document.getElementById("<%=btnThem.ClientID%>").click();
        }--%>
    </script>
    <script>
        for (var a = [], i = 0; i < 25; ++i) a[i] = "#" + (Math.random() * 0xFFFFFF << 0).toString(16).padStart(6, '0');

        var kq_TenMonHoc = document.getElementById("<%=txtTenMonHoc.ClientID%>").value.replaceAll("'", '"');
        var array_TenMonHoc = JSON.parse("[" + kq_TenMonHoc + "]");
        var kq_SoLanLamBai = document.getElementById("<%=txtSoLanKiemTra.ClientID%>").value.replaceAll("'", "");
        var array_SoLanLamBai = JSON.parse("[" + kq_SoLanLamBai + "]");

        var data = [{
            data: array_SoLanLamBai,
            backgroundColor: a,
            borderColor: "#fff"
        }];
        var options = {
            tooltips: {
                enabled: true
            },
            plugins: {
                datalabels: {
                    formatter: (value, ctx) => {
                        let sum = ctx.dataset._meta[0].total;
                        let percentage = (value * 100 / sum).toFixed(2) + "%";
                        return percentage;
                    },
                    color: '#ffffff'
                }
            }
        };
        var ctx = document.getElementById('pie-chart').getContext('2d'),
            elements = [];
        var myChart = new Chart(ctx, {
            type: 'pie',
            data: {
                labels: array_TenMonHoc,
                datasets: data
            },
            options: options
        });

    </script>
</asp:Content>

