<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuestionsModel>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
	Questions
</asp:Content>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="questions-container">
        <% foreach (var question in Model.Questions)
            { %>
            <div class="question-container">
                <div class="question-vote-container">
                    <div class="question-vote-answers"><%: question.AnswerCount %><span class="question-vote-answers-text">answers</span></div>
                    <div class="question-vote-count"><%: question.UpVoteCount - question.DownVoteCount %><span class="question-vote-count-text">votes</span></div>
                    <div class="question-vote-views"><%: question.ViewCount %><span class="question-vote-views-text">views</span></div>
                </div>
                <div class="question">
                    <div class="question-title">
                        <% if (question.BountyAmount > 0)
                           {%>
                            <span class="quesion-bounty"><%: question.BountyAmount.ToString() + "+"%></span>
                        <%} %>
                        <%: Html.ActionLink(question.Title, "Question", new { action = "Questions", api = Url.RequestContext.RouteData.Values["api"], id = question.Id }, new { @class = "question-title-link" })%>
                        <a class="external-link" href="<%: Url.GetHostSiteBaseUrl() + "/questions/" + question.Id %>"><span class="external-link-image"></span></a>
                    </div>
                    <div class="question-body">
                        <% string cleanBody = question.Body.HtmlSanitize(); %>
                        <%: cleanBody.Length <= 200 ? cleanBody : cleanBody.Substring(0, 200) + "..."%>                        
                    </div>
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
            </div>
        <% } %>
    </div>
    <% Html.RenderPartial("Pager", new PagerModel(Model.SiteState)); %>
</asp:Content>

<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">Sidebar</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server"></asp:Content>
