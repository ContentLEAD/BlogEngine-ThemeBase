using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BlogEngine.Core;
using System.Text.RegularExpressions;

public partial class StandardSite : System.Web.UI.MasterPage
{
    private static Regex reg = new Regex(@"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}");
	
	bool _isSingle;
	bool _isCategoryArchive;
	bool _isDateArchive;
	
	DateTime _archiveDate;
	Category _archiveCategory;
	
	protected DateTime ArchiveDate { get { return _archiveDate; } private set { _archiveDate = value; } }
	protected Category ArchiveCategory { get { return _archiveCategory; } private set { _archiveCategory = value; } }
	
	protected bool IsSinglePost { get { return _isSingle; } private set { _isSingle = value; } }
	protected bool IsCategoryArchive { get { return _isCategoryArchive; } private set { _isCategoryArchive = value; } }
	protected bool IsDateArchive { get { return _isDateArchive; } private set { _isDateArchive = value; } }
	
	protected string GetHeaderText()
	{
		if (IsSinglePost)
			return string.Empty;
		
		if (IsDateArchive)
			return "Archive: " + ArchiveDate.ToString("MMMM yyyy");
		
		if (IsCategoryArchive)
			return "Category: " + ArchiveCategory.Title;
		
		return "News";
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		this.loggedInStyle.Visible = Security.IsAuthenticated;
		
		// fun fact: blogengine's Utils.IsCurrentRequestForHomepage (as of 2.7)
		// fails to recognize if the current page is the landing page if there is a query string e.g., /blog/?page=1
		Regex r = new Regex("^" + Utils.AbsoluteWebRoot + @"(\?.*$|Default\.aspx(\?.*)?$|$)", RegexOptions.IgnoreCase);
        IsSinglePost = !r.IsMatch(HttpContext.Current.Request.Url.ToString());
		
		// date archive
		if (Request.QueryString["year"] != null && Request.QueryString["month"] != null)
		{
			IsDateArchive = true;
			ArchiveDate = new DateTime(int.Parse(Request.QueryString["year"]), int.Parse(Request.QueryString["month"]), 1);
		}
		// category archive
		else if (Request.QueryString["id"] != null && System.IO.Path.GetFileName(Request.Path).ToLower() != "post.aspx")
		{
			IsCategoryArchive = true;
			ArchiveCategory = Category.Load(Guid.Parse(Request.QueryString["id"]));
		}
		
		NewsHeader.Visible = !IsSinglePost;
		
		if (IsDateArchive)
			bodyTag.Attributes.Add("class", "archive date-archive");
		else if (IsCategoryArchive)
			bodyTag.Attributes.Add("class", "archive category-archive");
		else if (IsSinglePost)
			bodyTag.Attributes.Add("class", "single");
    }

    protected override void Render(HtmlTextWriter writer)
    {
        using (HtmlTextWriter htmlwriter = new HtmlTextWriter(new System.IO.StringWriter()))
        {
            base.Render(htmlwriter);
            string html = htmlwriter.InnerWriter.ToString();
			
            html = reg.Replace(html, string.Empty).Trim();
			
            writer.Write(html);
        }
    }
}
