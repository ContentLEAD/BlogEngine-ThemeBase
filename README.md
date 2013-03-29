BlogEngine-ThemeBase
====================

An extended version of the default BlogEngine theme, feature-fitted for rapid integrations. Includes simple, nonintrusive styles acting as a consistent starting point.

## Style Documentation ##
The base styles allow the designer to target types of pages such as single post, category archive, and date archive. These styles are constructed by the master page (site.master.cs).

### Page Types ###
#### Single post (***.single***) ####
Single posts can be targeted using the **.single** class on the body tag.

*Example*: Apply a red background to a single post's content.
> `body.single .post { background-color: red; }`

#### Date archive (***.date-archive***) ####
Date archives can be targeted using the **.date.archive** class on the body tag.

*Example*: Apply a blue background to the first post in a date archive.
> `body.date-archive .post0 { background-color: blue; }`

#### Category archive (***.category-archive***) ####
Category archives can be targeted using the **.category-archive** class on the body tag.

*Example*: Apply a green background to the widget zone in category archives.
> `body.category-archive .widgetzone { background-color: green; }`

#### Generic archive (***.archive***) ####
Both date and category archives (*but not the home page*) can be targeted by using the **.archive** class on the body tag.

*Example*: Flip date and category archive pages upside-down.
> `body.archive { -moz-transform: rotate(180deg); -webkit-transform: rotate(180deg); }`

### Page Elements ###
#### Post list (***.posts***) ####
The list of posts displayed in archives, categories, and the home page can be targeted using the **.posts** class.

*Example*: Apply italics to every other post excerpt on the home page, category, and date archives.
> `.posts .post:nth-child(even) .text { font-style: italic; }`

#### Post list header ####
The h1 tag at the top of post list pages can be targeted using the **.news-header** class.

*Example*: Apply a border to post list headers.
> `h1.news-header { border: 1px solid black; }`

#### Post titles ####
Post titles can be targeted using the **.post-title** class.

*Example*: Apply a 50px padding to all post titles.
> `.post-title { padding: 50px; }`

**Note**: This class is applied to h1 tags on single post pages and h2 tags on post list pages.