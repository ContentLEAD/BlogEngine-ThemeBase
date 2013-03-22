using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BlogEngine.Core;
using System.Text.RegularExpressions;

public partial class PostView : BlogEngine.Core.Web.Controls.PostViewBase
{
	bool _isSingle;
	
	protected bool IsSinglePost { get { return _isSingle; } set { _isSingle = value; } }
	
	public PostView()
		: base()
	{
		// fun fact: blogengine's Utils.IsCurrentRequestForHomepage (as of 2.7)
		// fails to recognize if the current page is the landing page if there is a query string e.g., /blog/?page=1
		Regex r = new Regex("^" + Utils.AbsoluteWebRoot + @"(\?.*$|Default.aspx(\?.*)?$|$)", RegexOptions.IgnoreCase);
        IsSinglePost = !r.IsMatch(HttpContext.Current.Request.Url.ToString());
	}
	
	protected void Page_Load(object sender, EventArgs e)
	{
		Categories.Visible = CategoryLinks(" | ") != "";
		
		SinglePostTitle.Visible = IsSinglePost;
		PostListPostTitle.Visible = !IsSinglePost;
		
		// mimic the default blogengine css classes, and add .single if appropriate
		post.Attributes.Add("class", "post xfolkentry post" + Index );
	}
	
	protected override void Render(HtmlTextWriter writer)
    {
		base.Render(writer);
	}
}