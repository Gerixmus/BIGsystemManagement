<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="BIGsystemManagement.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="img/IMS_Infograph_banner.jpg" class="w-100 img-fluid" />
    </section>
    <section>
        <style>
            h2 {text-align: center;}
            h4 {text-align: center;}
            p {text-align: center;}
            img.center { display: block; margin: 0 auto;}
        </style>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <h2>Contact us</h2>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <img class="center" src="img/web.png""/>
                    <h4>Website</h4>
                    <p class="text-justify">Some text bigsystem is a company that does something sample text</p>
                </div>
                <div class="col-md-4">
                    <img class="center" src="img/facebook.png" />
                    <h4>Facebook</h4>
                    <p class="text-justify">Some text bigsystem is a company that does something sample text</p>
                </div>
                <div class="col-md-4">
                    <img class="center" src="img/email.png" />
                    <h4>Email</h4>
                    <p class="text-justify">Some text bigsystem is a company that does something sample text</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
