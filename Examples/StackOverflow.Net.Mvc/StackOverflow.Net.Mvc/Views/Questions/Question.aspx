<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuestionModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Question
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="question-container">
        <div class="question-title">
            <a class="question-title-link" href="<%: "/Questions/Question/" + Model.State.HostSite + "/" + Model.Question.Id %>"><%: Model.Question.Title %></a>
        </div>
        <div class="question-vote-container">
            
        </div>
    <%: Model.Question.AcceptedAnswerId %><br />
    <%: Model.Question.AnswerCount %><br />
    <%= Model.Question.Body %><br />
    <%: Model.Question.BountyAmount %><br />
    <%: Model.Question.ClosedDate %><br />
    <%: Model.Question.ClosedReason %><br />
    <%: Model.Question.CommentsUrl %><br />
    <%: Model.Question.CommunityOwned %><br />
    <%: Model.Question.CreationDate %><br />
    <%: Model.Question.DownVoteCount %><br />
    <%: Model.Question.FavoriteCount %><br />
    <%: Model.Question.Id %><br />
    <%: Model.Question.LastActivityDate %><br />
    <%: Model.Question.LastEditDate %><br />
    <%: Model.Question.LockedDate %><br />
    <%: Model.Question.Owner %><br />
    <%: Model.Question.Score %><br />
    <%: Model.Question.TimelineUrl %><br />
    
    <%: Model.Question.UpVoteCount %><br />
    <%: Model.Question.ViewCount %><br />
    
    <% foreach(var tag in Model.Question.Tags)
       { %>
        <%: tag %><br />
    <% } %>

    <% foreach (var comment in Model.Question.Comments)
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
    <% foreach (var answer in Model.Question.Answers)
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
</asp:Content>
