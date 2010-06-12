<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuestionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Question
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Question question = Model.Question; %>
    <div class="question-container">
        <div class="question-title">
            <% if (question.BountyAmount > 0)
               {%>
                <span class="quesion-bounty"><%: question.BountyAmount.ToString() + "+"%></span>
            <%} %>
            <a class="question-title-link" href="<%: "/Questions/Question/" + Model.State.HostSite + "/" + question.Id %>"><%: question.Title %></a>
        </div>
        <div class="question-vote-container">
            <div class="question-vote-count"><%: question.UpVoteCount - question.DownVoteCount %><span class="question-vote-count-text">votes</span></div>
        </div>
        <div class="question-favorite-container">
            <div class="question-favorite-count"><%: question.FavoriteCount %><span class="question-favorite-image"></span></div>
        </div>
        <div class="quesiton-body">
            <%= question.Body %>
        </div>
        <div class="tags-container">
            <% foreach (string tag in question.Tags)
                {%>
                <div class="tag"><%: Html.ActionLink(tag, "Tagged", new { action = "Questions", api = Url.RequestContext.RouteData.Values["api"], id = tag }, new { @class = "tag-link" })%>
                    <a class="external-link" href="<%: Url.GetHostSiteBaseUrl() + "/questions/tagged/" + tag %>"><span class="external-link-image"></span></a>
                </div>
            <% } %>
        </div>
        <div class="quesion-activity">
            <% if (question.CommunityOwned)
                {%>
                <span class="quesion-activity">Community Wiki</span>
                <span class="quesion-user"><%: Html.ActionLink(question.Owner.DisplayName, "User", new { action = "Users", api = Url.RequestContext.RouteData.Values["api"], id = question.Owner.UserId }, new { @class = "question-user-link" })%></span>
            <% }
                else
                {%>
                <span class="quesion-activity">modified <%: question.LastActivityDate %></span>
                <% if (question.Owner != null)
                    { %>
                    <span class="quesion-user"><%: Html.ActionLink(question.Owner.DisplayName, "User", new { action = "Users", api = Url.RequestContext.RouteData.Values["api"], id = question.Owner.UserId }, new { @class = "question-user-link" })%></span>
                    <% }
                    else
                    { %>
                    <span class="quesion-user">???</span>
                <% } %>
            <% } %>
        </div>
    <%: question.AcceptedAnswerId %><br />
    
    

    <%: question.ClosedDate %><br />
    <%: question.ClosedReason %><br />
    <%: question.CommentsUrl %><br />
    <%: question.CommunityOwned %><br />
    <%: question.CreationDate %><br />
    <%: question.DownVoteCount %><br />
    <%: question.FavoriteCount %><br />
    <%: question.Id %><br />
    <%: question.LastActivityDate %><br />
    <%: question.LastEditDate %><br />
    <%: question.LockedDate %><br />
    <%: question.Owner %><br />
    <%: question.Score %><br />
    <%: question.TimelineUrl %><br />
    

    <%: question.ViewCount %><br />
    
    <% foreach (var comment in question.Comments)
       { %>
        <%= comment.Body %><br />
        <%: comment.CreationDate %><br />
        <%: comment.EditCount %><br />
        <%: comment.Id %><br />
        <%: comment.OwnerDisplayName %><br />
        <%: comment.OwnerUserId %><br />
        <%: comment.PostType %><br />
        <%: comment.ReplyToUserId %><br />
        <%: comment.Score %><br />
    <% } %>
    </div>
    
    <% Html.RenderPartial("Pager", new PagerModel(Model.State)); %>
    <% foreach (var answer in question.Answers)
       { %>
        <%: answer.Accepted %><br />
        <%= answer.Body %><br />
        <%: answer.CommentsUrl %><br />
        <%: answer.CommunityOwned %><br />
        <%: answer.CreationDate %><br />
        <%: answer.DownVoteCount %><br />
        <%: answer.FavoriteCount %><br />
        <%: answer.Id %><br />
        <%: answer.LastActivityDate %><br />
        <%: answer.LastEditDate %><br />
        <%: answer.OwnerDisplayName %><br />
        <%: answer.OwnerUserId %><br />
        <%: answer.QuestionId %><br />
        <%: answer.Score %><br />
        <%: answer.Title %><br />
        <%: answer.UpVoteCount %><br />
        <%: answer.ViewCount %><br />
        
        <% foreach (var comment in answer.Comments)
       { %>
        <%= comment.Body %><br />
        <%: comment.CreationDate %><br />
        <%: comment.EditCount %><br />
        <%: comment.Id %><br />
        <%: comment.OwnerDisplayName %><br />
        <%: comment.OwnerUserId %><br />
        <%: comment.PostType %><br />
        <%: comment.ReplyToUserId %><br />
        <%: comment.Score %><br />
    <% } %>
    <% } %>
    <% Html.RenderPartial("Pager", new PagerModel(Model.State)); %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SidebarContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('pre code').addClass('prettyprint');
            prettyPrint();
        });
    </script>
</asp:Content>
