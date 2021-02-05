<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminservicemanagement.aspx.cs" Inherits="BIGsystemManagement.adminservicemanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('#myTable').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <style>
            img.center { display: block; margin: 0 auto;}
            h3 {text-align: center;}
        </style>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <img class="center" src="img/service.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h3>Service management</h3>                              
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Service ID</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder=""></asp:TextBox>
                                        <asp:Button class="btn btn-primary col-6" ID="Button4" runat="server" Text="Show" OnClick="Button4_Click" />
                                    </div> 
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Type of Service</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Description</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success col-6 btn-lg" ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-primary col-6 btn-lg" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button class="btn btn-danger col-6 btn-lg" ID="Button3" runat="server" Text="Delete" OnClick="Button3_Click" />
                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Home</a><br /><br />
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <h3>Services</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div> 


                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiGsystemManagementDBConnectionString %>" SelectCommand="SELECT * FROM [service_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="service_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="service_id" HeaderText="service_id" ReadOnly="True" SortExpression="service_id" />
                                        <asp:BoundField DataField="type_of_service" HeaderText="type_of_service" SortExpression="type_of_service" />
                                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
