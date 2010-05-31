<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StackOverflow.Net.Mvc.ViewModels.HeaderModel>" %>
<div class="site-menu-container">
    <ul class="site-menu">
        <% foreach (string key in Model.SupportedSites.Keys)
           { %>
           <li class="site-menu-item<%: key == Model.CurrentSite ? " site-menu-item-selected" : string.Empty %>"><a class="site-menu-item-link" href="<%: Model.SupportedSites[key] %>"><span class="site-menu-item-link-text"><%: key %></span></a></li>
        <% } %>
    </ul>
</div>

<div class="navigation-menu-container">
    <ul class="navigation-menu">
        <% foreach (string key in Model.NavigationTabs.Keys)
           { %>
           <li class="navigation-menu-item<%: key == Model.CurrentNavigationTab ? " navigation-menu-item-selected" : string.Empty %>"><a class="navigation-menu-item-link" href="<%: Model.NavigationTabs[key] %>"><span class="navigation-menu-item-link-text"><%: key %></span></a></li>
        <% } %>
    </ul>
</div>

<div class="sub-navigation-menu-container">
    <ul class="sub-navigation-menu">
        <% foreach (string key in Model.SubNavigationTabs.Keys)
           { %>
           <li class="sub-navigation-menu-item<%: key == Model.CurrentSubNavigationTab ? " sub-navigation-menu-item-selected" : string.Empty %>"><a class="sub-navigation-menu-item-link" href="<%: Model.SubNavigationTabs[key] %>"><span class="sub-navigation-menu-item-link-text"><%: key %></span></a></li>
        <% } %>
    </ul>
</div>