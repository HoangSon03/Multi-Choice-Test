<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterPage.master" AutoEventWireup="true" CodeFile="web_LuyenTap.aspx.cs" Inherits="web_module_web_LuyenTap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="higlobal" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hislider" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibelowtop" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="main__list">
        <div class="container">
            <div class="row ">
                <asp:Repeater runat="server" ID="rpTracNghiem">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-12 sl ">
                            <div id="" class="card card__tracnghiem">
                                <div class="card-header card-header__test">
                                    <%#Eval("luyentap_name") %>
                                </div>
                                <div class="card-body card-body__test">
                                    <img class="rounded" src="/images_card/logovn-2295.png" />
                                </div>
                                <div class="card-footer card-footer__test">
                                    <a href="/bai-luyen-tap-chi-tiet-<%#Eval("khoi_id") %>/<%# cls_ToAscii.ToAscii(Eval("luyentap_name").ToString()) %>-<%#Eval("test_id") %>.html" class="candy">Làm bài</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="hibelowbottom" runat="Server">
</asp:Content>
<asp:Content ID="Content11" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content12" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

