<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" Inherits="PostView" CodeFile="PostView.ascx.cs" %>

<div ID="post" runat="server">
	<%-- both are required so that we display a link on a post list and no link on a single post --%>
	<%-- set programmatically in PostView.ascx.cs --%>
	<h1 class="post-title" ID="SinglePostTitle" runat="server"><%=Server.HtmlEncode(Post.Title) %></h1>
	<h2 class="post-title" ID="PostListPostTitle" runat="server"><a href="<%=Post.RelativeOrAbsoluteLink %>"><%=Server.HtmlEncode(Post.Title) %></a></h2>
	
	<span class="date"><%=Post.DateCreated.ToString("dddd, MMMM dd, yyyy") %></span>

	<div class="text"><asp:PlaceHolder ID="BodyContent" runat="server" /></div>

	<div class="footer">
		<p ID="Categories" class="categories" runat="server">Filed under: <%=CategoryLinks(" | ") %></p>
		<p class="admin-links"><%=AdminLinks %></p>
	</div>
</div>