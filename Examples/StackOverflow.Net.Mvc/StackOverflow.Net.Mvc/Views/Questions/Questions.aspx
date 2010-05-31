<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<StackOverflow.PagedList<StackOverflow.Question>>" %>

<asp:Content ID="TitleContent" ContentPlaceHolderID="TitleContent" runat="server">
	Questions
</asp:Content>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server"></asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="questions-container">
        <% foreach (var question in Model)
            { %>
            <div class="question-container">
                <div class="question-vote-container">
                    <div class="question-vote-answers"><%: question.AnswerCount %><span class="question-vote-answers-text">answers</span></div>
                    <div class="question-vote-count"><%: question.UpVoteCount - question.DownVoteCount %><span class="question-vote-count-text">votes</span></div>
                    <div class="question-vote-views"><%: question.ViewCount %><span class="question-vote-views-text">views</span></div>
                </div>
                <div class="question">
                    <div class="question-title">
                        <%: Html.ActionLink(question.Title, "Question", new { action = "Questions", api = Url.RequestContext.RouteData.Values["api"], id = question.Id }, new { @class = "question-title-link" })%>
                        <span class="question-external-link"><a class="external-link" href="<%: Url.GetHostSiteBaseUrl() + "/questions/" + question.Id %>"><span class="external-link-image"></span></a></span>
                    </div>
                    <div class="question-body">
                        <% string cleanBody = question.Body.HtmlSanitize(); %>
                        <%: cleanBody.Length <= 200 ? cleanBody : cleanBody.Substring(0, 200) + "..."%>                        
                    </div>
                </div>
                <div class="tags-container">
                    <% foreach (string tag in question.Tags)
                        {%>
                        <div class="tag"><%: Html.ActionLink(tag, "Tagged", new { action = "Questions", api = Url.RequestContext.RouteData.Values["api"], id = tag }, new { @class = "question-tag" })%>
                        <span class="tag-external-link"><a class="external-link" href="<%: Url.GetHostSiteBaseUrl() + "/questions/tagged/" + tag %>"><span class="external-link-image"></span></a></span></div>
                    <% } %>
                </div>
                <div class="user-container">
                    
                </div>
            </div>
        <% } %>
    </div>
</asp:Content>

<asp:Content ID="SidebarContent" ContentPlaceHolderID="SidebarContent" runat="server">Sidebar</asp:Content>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="ScriptContent" runat="server"></asp:Content>
