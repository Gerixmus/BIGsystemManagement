<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminusermanagement.aspx.cs" Inherits="BIGsystemManagement.adminusermanagement" %>
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
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <img class="center" src="img/girl.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h3>User details</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <label>User ID</label>
                                <div class="form-group">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder=""></asp:TextBox>
                                            <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Show" OnClick="Button3_Click"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>   
                            <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success" ID="LinkButton1" runat="server" Text="G" OnClick="LinkButton1_Click"><i class="far fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-warning" ID="LinkButton2" runat="server" Text="Y" OnClick="LinkButton2_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-danger" ID="LinkButton3" runat="server" Text="R" OnClick="LinkButton3_Click"><i class="far fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>  
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="" ReadOnly="True" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Phone Nr</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="" ReadOnly="True" TextMode="Phone"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="" ReadOnly="True" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger col-12 btn-lg" ID="Button1" runat="server" Text="Delete User" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <a href="homepage.aspx"><< Back to Home</a><br /><br />
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <h3>User List</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div> 


                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiGsystemManagementDBConnectionString %>" SelectCommand="SELECT * FROM [user_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="phone_nr" HeaderText="Phone Nr" SortExpression="phone_nr" />
                                        <asp:BoundField DataField="email_address" HeaderText="Email" SortExpression="email_address" />
                                        <asp:BoundField DataField="date_of_birth" HeaderText="Birthday" SortExpression="date_of_birth" />
                                        <asp:BoundField DataField="password" HeaderText="Password" SortExpression="password" />
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
