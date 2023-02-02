<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_QuanLyChuong.aspx.cs" Inherits="admin_page_module_function_module_TracNghiem_module_QuanLyChuong" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script type="text/javascript">
       function confirmDel() {
            swal("Bạn có thực sự muốn thêm?",
                "Nếu thêm, dữ liệu sẽ không thể khôi phục.",
                "succsess",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnLuu.ClientID%>');
                        xoa.click();
                    }
                });
        }
    </script>
    <div class="card card-block">
        <div class="col-sm-12">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <h1>Nhập tên chương:</h1>
                    <div class="col-sm-3">
                        <asp:TextBox runat="server" ID="txtTenChuong" />
                    </div>
                    <div class="col-sm-2">
                        <input type="submit" class="btn btn-primary" value="Lưu" onclick="confirmDel()" />
                        <asp:Button ID="btnLuu" type="btnLuu" runat="server" Text="Lưu" CssClass="invisible" OnClick="btnLuu_Click" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

