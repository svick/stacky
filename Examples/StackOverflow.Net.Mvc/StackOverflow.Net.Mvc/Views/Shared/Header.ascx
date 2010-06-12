<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Stacky.Mvc.HeaderModel>" %>
<% if (Model.SupportedSites.Count > 0)
   { %>
<div class="site-menu-container">
    <ul class="site-menu">
        <% foreach (string key in Model.SupportedSites.Keys)
           { %>
           <li class="site-menu-item<%: key == Model.CurrentSite ? " site-menu-item-selected" : string.Empty %>"><a class="site-menu-item-link" href="<%: Model.SupportedSites[key] %>"><%: key %></a></li>
        <% } %>
    </ul>
    <div class="search-container">
        <% Html.BeginForm(); %>
            <div class="search-bar"><%: Html.TextBox("SearchText", string.Empty, new { @class = "search-text-box" }) %></div>
        <% Html.EndForm(); %>
    </div>
</div>
<% } %>

<% if (Model.NavigationTabs.Count > 0)
   { %>
<div class="navigation-menu-container">
    <ul class="navigation-menu">
        <% foreach (string key in Model.NavigationTabs.Keys)
           { %>
           <li class="navigation-menu-item<%: key == Model.CurrentNavigationTab ? " navigation-menu-item-selected" : string.Empty %>"><a class="navigation-menu-item-link" href="<%: Model.NavigationTabs[key] %>"><%: key %></a></li>
        <% } %>
    </ul>
</div>
<% } %>

<% if (Model.SubNavigationTabs.Count > 0)
   { %>
<div class="sub-navigation-menu-container">
    <ul class="sub-navigation-menu">
        <% foreach (string key in Model.SubNavigationTabs.Keys)
           { %>
           <li class="sub-navigation-menu-item<%: key == Model.CurrentSubNavigationTab ? " sub-navigation-menu-item-selected" : string.Empty %>"><a class="sub-navigation-menu-item-link" href="<%: Model.SubNavigationTabs[key] %>"><%: key%></a></li>
        <% } %>
    </ul>
</div>
<% } %>