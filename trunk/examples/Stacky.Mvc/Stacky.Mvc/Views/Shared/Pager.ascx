<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Stacky.Mvc.PagerModel>" %>
<% if (Model.PageSelectors.Count > 0)
   { %>
<div class="pager-container">
    <ul class="pager-items">
        <% foreach (var pagerItem in Model.PageSelectors)
           { %>
                <li class="pager-item<%: pagerItem.Key == Model.CurrentPage ? " pager-item-selected" : string.Empty %>"><a class="pager-item-link" href="<%: pagerItem.Value %>"><%: pagerItem.Key %></a></li>
        <% } %>
    </ul>
</div>
<% } %>

<% if (Model.PageSizes.Count > 0)
   { %>
<div class="page-size-container">
    <ul class="page-size-items">
        <% foreach (var pageSizeItem in Model.PageSizes)
           { %>
                <li class="page-size-item<%: pageSizeItem.Key == Model.CurrentPageSize ? " page-size-item-selected" : string.Empty %>"><a class="page-size-item-link" href="<%: pageSizeItem.Value %>"><%: pageSizeItem.Key %></a></li>
        <% } %>
    </ul>
</div>
<% } %>