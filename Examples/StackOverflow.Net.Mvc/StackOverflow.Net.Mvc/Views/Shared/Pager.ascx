<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<StackOverflow.Net.Mvc.PagerModel>" %>

<div class="pager-container">
    <ul class="pager-items">
        <% foreach (var pagerItem in Model.PageSelectors)
           { %>
                <li class="pager-item"><a class="pager-item-link" href="<%: pagerItem.Value %>"><%: pagerItem.Key %></a></li>
        <% } %>
    </ul>
</div>
<div class="page-size-container">
    <ul class="page-size-items">
        <% foreach (var pageSizeItem in Model.PageSizes)
           { %>
                <li class="page-size-item"><a class="page-size-item-link" href="<%: pageSizeItem.Value %>"><%: pageSizeItem.Key%></a></li>
        <% } %>
    </ul>
</div>