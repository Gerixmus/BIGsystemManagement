<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminordermanagement.aspx.cs" Inherits="BIGsystemManagement.adminordermanagement" %>
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
                                <img class="center" src="img/checklist.png" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <h3>Order Management</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Order ID (only for existing orders)</label>
                                <div class="form-group">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder=""></asp:TextBox>
                                            <asp:Button class="btn btn-primary" ID="Button4" runat="server" Text="Show" OnClick="Button4_Click"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>User ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder=""></asp:TextBox>                               
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Service ID</label>
                                <div class="form-group">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder=""></asp:TextBox>
                                            <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Show" OnClick="Button3_Click"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Service name</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Activity Description</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Start Date</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>End Date</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary col-12 btn-lg" ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-secondary col-12 btn-lg" ID="Button2" runat="server" Text="Mark as received" OnClick="Button2_Click" />
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
                                <h3>Current Orders</h3>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div> 


                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BiGsystemManagementDBConnectionString %>" SelectCommand="SELECT * FROM [order_manager_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="order_id" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="order_id" HeaderText="order_id" SortExpression="order_id" InsertVisible="False" ReadOnly="True" />
                                        <asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id" />
                                        <asp:BoundField DataField="activity_description" HeaderText="activity_description" SortExpression="activity_description" />
                                        <asp:BoundField DataField="member_name" HeaderText="member_name" SortExpression="member_name" />
                                        <asp:BoundField DataField="service_id" HeaderText="service_id" SortExpression="service_id" />
                                        <asp:BoundField DataField="start_date" HeaderText="start_date" SortExpression="start_date" />
                                        <asp:BoundField DataField="end_date" HeaderText="end_date" SortExpression="end_date" />
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
