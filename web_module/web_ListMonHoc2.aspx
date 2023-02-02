<%@ Page Title="" Language="C#" MasterPageFile="~/WebMasterPage.master" AutoEventWireup="true" CodeFile="web_ListMonHoc2.aspx.cs" Inherits="web_module_web_ListMonHoc2" %>

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
            <h4 class="event__title">LUYỆN TẬP</h4>
            <div class="row content">
                <asp:Repeater runat="server" ID="rpMonHoc">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-12 sl sl-show mb-4 type1">
                            <div class="card card__tracnghiem">
                                <div class="card-header card-header__test">
                                    <%#Eval("monhoc_name") %>
                                </div>
                                <div class="card-body card-body__test">
                                    <img class="rounded" src="/images_card/logovn-2295.png" />
                                </div>
                                <div class="card-footer card-footer__test">
                                    <a class="candy" href="/bai-luyen-tap/<%#Eval("khoi_id") %>/<%#Eval("monhoc_id") %>.html">Vào bài làm</a>
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

