<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ThemGiaoVienDayKhoi.aspx.cs" Inherits="admin_page_module_function_module_QuanLyGiaoVienDayHoc_module_ThemGiaoVienDayKhoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js" integrity="sha512-rMGGF4wg1R73ehtnxXBt5mbUfN9JUJwbk21KMlnLZDJh7BkPmeovBuddZCENJddHYYMkCh9hPFnPmS9sspki8g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" integrity="sha512-yVvxUQV0QESBt1SyZbNJMAwyKvFTLMyXSyBHDO4BG5t7k/Lw34tyqlSDlKIrIENIzCl+RVUNjmCPG+V/GMesRw==" crossorigin="anonymous" referrerpolicy="no-referrer" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">

    <script>
        function myClick(id) {
            document.getElementById("<%=txtKhoiHienTai.ClientID%>").value = id;
            document.getElementById("<%=btnCheck.ClientID%>").click();
        }
        window.onload = function () {
            var khoi_ID = document.getElementById("<%=txtKhoiName.ClientID%>").value.split(',');
            //debugger
            for (var i = 0; i < khoi_ID.length; i++) {
                document.getElementById("ckKhoi_" + khoi_ID[i]).checked = true;
            }
        }

    </script>
    <script>
        function tai_lai_trang() {

            location.reload();
            return false;
        }
    </script>
    <style>
        .main_khoi {
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            justify-content: flex-start;
            /* flex-direction: row; */
            align-content: space-around;
            line-height: 30px;
        }

        .cbbGiaoVien {
            padding: 0.5rem;
            cursor: pointer;
            border-radius: 5px;
            /*background-color: #ddd;*/
            list-style: none;
            box-shadow: 0 1px 3px -2px #9098a9;
        }

        .myCheckboxCss {
            float: left !important;
            color: #000000;
            background-color: #101212;
            border-color: #64e6e5;
            background: linear-gradient( 45deg, #cbffeb, #26d7e1);
            border-radius: 25px;
            box-shadow: 0 0 6px 0px #68e7e5;
        }

        .app .content {
            padding-right: 0 !important;
            padding: 95px 20px 75px 20px;
            min-height: 100vh;
        }

        .form-group {
            margin-bottom: 1rem;
            padding: 2%;
        }

        .chosen-container-single .chosen-single span {
            display: block;
            overflow: hidden;
            margin-right: 26px;
            line-height: 35px;
            text-overflow: ellipsis;
            white-space: nowrap;
            font-size: 15px;
        }

        .chosen-container-single .chosen-single {
            height: 35px;
        }
    </style>

    <div class="card card-block">
        <h3 style="text-align: center; font-size: 28px; font-weight: bold; color: blue">GIÁO VIÊN DẠY KHỐI</h3>
        <div class="form-group row">
            <div class="col-sm-10 ">
                <div style="margin-bottom: 2%; font-size: 12px; font-weight: 700;">
                    <span style="color:red">*Chú ý:</span><p> - Hãy chọn giáo viên trước khi thêm</p><p> - Nếu muốn thêm hoặc xóa chỉ cần thêm/bỏ tích ở checkbox</p>
                </div>
                Chọn giáo viên:
                <asp:DropDownList class="cbbGiaoVien" ID="ddlGiaoVien" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGiaoVien_SelectedIndexChanged"></asp:DropDownList>
                <script>
                    $('#<%=ddlGiaoVien.ClientID%>').chosen();
                </script>
                <br />
                <br />
                Chọn khối: 
                <br />
                <div class="main_khoi">
                    <asp:Repeater runat="server" ID="ckbKhoi">
                        <ItemTemplate>
                            <div class="item_khoi" style="margin: 1% 3% 0% 0;">
                                <input class="checkboxName" type="checkbox" id="ckKhoi_<%#Eval("khoi_id")%>" onclick="myClick(<%#Eval("khoi_id")%>)" />
                                <label for="vehicle1" style="margin: 0"><%#Eval("khoi_name") %></label><br>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <br />

                <%--<a href="#" class="myCheckboxCss" runat="server" onserverclick="btnThem_Click" style="display: block">Hủy tất cả</a>--%>
                <%--<input type="checkbox" id="myCheckbox" class="myCheckboxCss" />--%>
                <%-- <script>
                    $('.myCheckboxCss').prop('checked', false);
                </script>--%>
                <a href="#" id="btnCheck" runat="server" onserverclick="btnCheck_ServerClick"></a>
                <input type="text" runat="server" id="txtKhoiName" hidden="hidden" />
                <input type="text" runat="server" id="txtKhoiHienTai" hidden="hidden" />

                <a href="#" id="btnThemGV" runat="server" onserverclick="btnThem_Click" class="btn btn-primary" data-toggle="modal" data-target="#modal_ImportExcel" style="display: none"></a>
                <%-- <asp:CheckBoxList ID="ckbKhoi" runat="server">

                </asp:CheckBoxList>--%>

                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <%-- <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" OnClick="btnThem_Click" />
                        <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary" />
                        <input type="submit" class="btn btn-primary" value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" />--%>
                        <a href="#" id="btnImportExcel" class="btn btn-primary" data-toggle="modal" data-target="#modal_ImportExcel" style="display: none">Nhập Excel</a>

                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
            <a href="/admin-quan-ly-he-thong-khoi" class="btn btn-primary float-sm-right">Quay lại</a>
            <a href="#" id="btnThem" runat="server" onserverclick="btnThem_Click" style="display: block"></a>
        </div>
    </div>
    <%-- <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="giaovien_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="2%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Tên giáo viên" FieldName="giaovien_name" HeaderStyle-HorizontalAlign="Center" Width="5%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Khối" FieldName="khoi_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                </Columns>
                <ClientSideEvents RowDblClick="btnChiTiet" />
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Nhập từ cần tìm kiếm..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView> --%>
    <%--</div>--%>
    <%-- <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Download" CommandArgument='../../uploadimages/fil-mau/kiem tra covid nam 21.pdf' Text='pdf_download'></asp:LinkButton>--%>
    <%--  </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="800px" Height="500px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="THÔNG TIN HỌC SINH" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Mã học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtMahocsinh" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group" style="display: none">
                                        <label class="col-2 form-control-label">Họ học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtHoHocSinh" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Tên học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtTenhocsinh" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Giới tính:</label>
                                        <div>
                                            <asp:RadioButton ID="rdMale" runat="server" Text="Nam" GroupName="gender" />
                                            <asp:RadioButton ID="rdFeMale" runat="server" Text="Nữ" GroupName="gender" />
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Ngày sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="dtDate" TextMode="Date" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Địa chỉ:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtDiaChi" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Họ và tên ba học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtTenBa" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Số điện thoại ba học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtSDTBa" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Email ba học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtEmailBa" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Nghề nghiệp ba học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtNgheNghiepBa" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Họ và tên mẹ học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtTenMe" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Số điện thoại mẹ học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtSDTMe" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Email mẹ học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtEmailMe" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Nghề nghiệp mẹ học sinh:</label>
                                        <div class="col-10">
                                            <asp:TextBox ID="txtNgheNghiepMe" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="90%"> </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <div class="colum-5 form-group">
                                            <input type="text" id="txtImage" runat="server" style="display: none" />
                                            <label class="form-control-label">Hình ảnh học sinh :</label>
                                            <div id="up1" class="">
                                                <asp:FileUpload CssClass="hidden-xs-up" ID="FileUpload1" runat="server" onchange="showPreview1(this)" accept=".png,.jpeg,.jpg" />
                                                <button type="button" class="btn-chang" onclick="clickavatar1()">
                                                    <img id="imgPreview1" src="/admin_images/up-img.png" style="max-width: 100%; height: 200px" />
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <div class="mar_but button">
                <asp:Button ID="btnInsertStudent" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary" OnClientClick="return checkNULL()" />
            </div>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

