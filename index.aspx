<%@ Page Title="" Language="C#" MasterPageFile="~/Client_Master.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content_slider" runat="Server">
    <input type="hidden" name="name" value="home" id="hidMn" />
    <div class="image-cover hero_banner hero-inner-2 shadow rlt" style="background: url(Client/Client_Assets/img/banner-2.jpg) no-repeat;" data-overlay="7">
        <div class="elix_img_box">
            <img src="Client/Client_Assets/img/preet-o.html" class="img-fluid" alt="" />
        </div>
        <div class="container">
            <div class="hero-caption small_wd mb-5">
                <h1 class="big-header-capt cl_2 mb-0">Learn on your schedule</h1>
                <p>Study any topic, anytime. Explore thousands of courses for the lowest price ever!</p>
            </div>
            <!-- Type -->
            <div class="row">
                <div class="col-lg-8 col-md-12 col-sm-12">
                    <div class="banner-search shadow_high">
                        <div class="search_hero_wrapping">
                            <div class="row">
                                <div class="col-lg-5 col-md-5 col-sm-12 br-right">
                                    <div class="form-group">
                                        <div class="input-with-icon">
                                            <input type="text" class="form-control" placeholder="Keyword" />
                                            <img src="Client/Client_Assets/img/search.svg" class="search-icon" alt="" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-5 col-md-4 col-sm-12 small-pad">
                                    <div class="form-group">
                                        <div class="input-with-icon">
                                            <select id="c-category" class="form-control">
                                                <option value="">&nbsp;</option>
                                                <option value="1">Web Designing</option>
                                                <option value="2">Business</option>
                                                <option value="3">Accounting</option>
                                                <option value="3">Development</option>
                                                <option value="3">Art & Culture</option>
                                            </select>
                                            <img src="Client/Client_Assets/img/pin.svg" class="search-icon" alt="" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-2 col-md-3 col-sm-12 pl-0">
                                    <div class="form-group none">
                                        <a href="#" class="btn search-btn full-width">Search</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_page" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>

