# Q) Assignment 1: Basic CRUD Application

An MVC application(that I created in the tutorial I followed from MS Learn) now satisfies all the following criteria of Assignment 1: Basic CRUD Application

```
Objective: 
Create a simple ASP.NET Core MVC application that implements CRUD (Create, Read, Update, Delete) operations for a single entity.

Requirements:

Create a new ASP.NET Core MVC project
Choose a simple entity (e.g., "Movie") with at least 4 properties 
Implement the following features:
List all items (Index view)
View details of a single item (Details view)
Create new items (Create view with form)
Edit existing items (Edit view with form)
Delete items (Delete confirmation view)
Use Entity Framework Core for data access
Implement basic validation using data annotations
Style the pages using Bootstrap(default in MVC)
```

But now I want to try and add more features to it. What can I try (beginner friendly) - I have heard of pagination, for that I need to add more data (currently my Movie table only has 4 rows)? Ideas that help solidify my foundational principles & help me learn more?

# A) Good next-step plan. Below are beginner-friendly feature ideas that **teach important web/MVC/EF fundamentals**, ordered from easiest → slightly harder, with short “why”, key concepts learned, and concrete starter code or instructions for the most useful items (pagination, seeding more data, sorting). Pick a few and implement them one-by-one

---

## Priority list (what to try next)

1. **Add more seed data (so you can test other features)** — *necessary before pagination*
2. **Pagination (server-side)**
3. **Sorting (column sort: title, date, price)**
4. **Combine paging + sorting + search/filter** (learn how query params compose)
5. **Better ViewModel separation** (use a dedicated Index viewmodel)
6. **Client-side validation & display templates** (customize display/edit templates)
7. **File upload (movie poster image)** — stores filename in DB, file on disk
8. **Partial views & AJAX refresh for search/filter** (progressive enhancement)
9. **Basic authentication & authorization** (restrict Create/Edit/Delete)
10. **Logging, error handling, small unit tests**

---

## 1) Seed more data (quick): add 100 movies for testing

Modify `SeedData` to create many test rows if none exist. This is safe for a dev DB.

```csharp
// inside SeedData.Initialize(...)
if (!context.Movie.Any())
{
    // existing sample movies first (or skip)
    for (int i = 1; i <= 200; i++)
    {
        context.Movie.Add(new Movie {
            Title = $"Sample Movie {i}",
            ReleaseDate = DateTime.Now.AddDays(-i * 30),
            Genre = i % 3 == 0 ? "Comedy" : i % 3 == 1 ? "Drama" : "Action",
            Price = 4.99m + (i % 10),
            Rating = (i % 2 == 0) ? "PG" : "R"
        });
    }
    context.SaveChanges();
}
```

* Run the app (or re-run migrations/seed call) to populate LocalDB.
* Advantage: lets you test pagination/sorting realistically.

---

## 2) Pagination (server-side) — simple implementation with Skip/Take

**Why:** large result sets must be loaded a page at a time; learn LINQ deferred execution and query composition.

### Controller (Index) — add `pageNumber` and `pageSize`

```csharp
public async Task<IActionResult> Index(string? movieGenre, string? searchString, int pageNumber = 1, int pageSize = 10)
{
    var moviesQuery = _context.Movie.AsQueryable();

    if (!string.IsNullOrEmpty(searchString))
        moviesQuery = moviesQuery.Where(m => m.Title.Contains(searchString));

    if (!string.IsNullOrEmpty(movieGenre))
        moviesQuery = moviesQuery.Where(m => m.Genre == movieGenre);

    // total for UI
    var totalCount = await moviesQuery.CountAsync();

    var movies = await moviesQuery
        .OrderBy(m => m.Title)                // deterministic ordering required for paging
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var vm = new MovieGenreViewModel {
        Movies = movies,
        // include paging metadata
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalCount = totalCount,
        Genres = new SelectList(await _context.Movie.Select(m => m.Genre).Distinct().ToListAsync())
    };

    return View(vm);
}
```

### View: basic paging links

```razor
@for (int p = 1; p <= Math.Ceiling((double)Model.TotalCount / Model.PageSize); p++)
{
    <a asp-action="Index" asp-route-pageNumber="@p" asp-route-searchString="@Request.Query["searchString"]" asp-route-movieGenre="@Request.Query["movieGenre"]">@p</a>
}
```

* Learnings: `Skip/Take`, why `OrderBy` is required, how to carry query parameters between pages.

**Tip:** later you can switch to a library like `X.PagedList.Mvc` for helpers, but implement core logic yourself first.

---

## 3) Sorting

**Why:** learn query parameters and toggling ascending/descending order.

Add parameters: `sortOrder` and implement:

```csharp
switch(sortOrder)
{
    case "title_desc":
        moviesQuery = moviesQuery.OrderByDescending(m => m.Title); break;
    case "date":
        moviesQuery = moviesQuery.OrderBy(m => m.ReleaseDate); break;
    // default as needed
    default:
        moviesQuery = moviesQuery.OrderBy(m => m.Title); break;
}
```

In view, output links that toggle `sortOrder` (and preserve other query params).

---

## 4) Combine paging + sorting + filtering

* Build query by applying filters → ordering → `Skip/Take`.
* Preserve current `searchString`, `movieGenre`, and `sortOrder` in your paging links.
* This teaches query composition and stateful URLs (so results are shareable/bookmarkable).

---

## 5) Use a proper **Index ViewModel**

Create a dedicated viewmodel to avoid overusing domain models in views. Example:

```csharp
public class MovieIndexViewModel
{
    public IEnumerable<Movie> Movies { get; set; }
    public SelectList Genres { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public string? CurrentFilter { get; set; }
    public string? CurrentSort { get; set; }
    public string? CurrentGenre { get; set; }
}
```

* Teaches separation of concerns and cleaner views.

---

## 6) File upload (poster)

**Why:** learn model binding for files, saving on disk, updating DB with filename, displaying images in views.

Steps:

* Add `IFormFile Poster` to a create/edit viewmodel.
* In POST action, save file to `wwwroot/images` and store filename in `Movie.PosterPath`.
* Use `<img src="~/images/@Model.PosterPath" />` in Index/Details.

---

## 7) Partial views & AJAX for search/filter (optional)

* Render movie list as a partial view.
* Use AJAX to fetch updated partial when user types or changes genre.
* Teaches progressive enhancement and basic JS fetch/jQuery.

---

## 8) Client-side validation & display templates

* Customize `EditorTemplates` and `DisplayTemplates` for common types (e.g., currency).
* Learn how data annotations generate `data-*` attributes used by jQuery Unobtrusive Validation.

---

## 9) Authentication & Authorization (basic)

* Add individual user accounts or simple cookie auth.
* Restrict Create/Edit/Delete to logged-in users.
* Teaches middleware, Identity basics, and `[Authorize]` attributes.

---

## 10) Tests & Logging

* Add simple unit tests for controller actions (mock `DbContext` with in-memory provider).
* Add `ILogger<T>` to controllers and log events (read/updates/errors).

---

## Implementation order I recommend

1. Seed more data.
2. Implement simple server-side pagination.
3. Add sorting.
4. Combine with search/filter.
5. Convert Index to a ViewModel.
6. Add poster upload.
7. Add partial + AJAX.
8. Add authentication.

This order ensures incremental learning: each step builds on previous ones.

---

## Small checklist / practical tips

* Always call `.OrderBy(...)` before `.Skip(...)`.
* Keep paging sizes modest (10–20).
* Use `Distinct()` on genre query to avoid duplicates.
* Keep seed code guarded so it only runs in dev.
* Use a ViewModel to avoid overposting; remove `[Bind]` approach later and use dedicated viewmodels.
* Commit and test often — implement one feature, run app, verify behavior.

---

If you want, I can:

* Provide a complete minimal working example for pagination + sorting + viewmodel (controller + view + vm).
* Or produce the SeedData change and show exactly how to call it from `Program.cs`.

# Q) I have seeded the data(step 1 as above), teach me the pagination step, explaining to a first-timer why & what we are doing. Attaching my Controller file & Index.cshtml. Also, if you need them, I have attached Models > Movie.cs & MovieGenreViewModel.cs. Teach me

# A) Overview — what we’re adding and why

You already have an `Index` action that filters by genre and search (see your controller).
Pagination adds these capabilities:

* Return only a **page** of results (e.g., 10 movies), not the whole table.
* Show UI controls (Previous / 1 2 3 / Next) so the user can move between pages.
* Keep the search and genre filters working while paging.

Why pagination matters (beginner-friendly):

* **Performance:** databases and web pages get slow when you fetch/display hundreds of rows. Paging loads a small, fixed number.
* **User experience:** users can scan smaller lists and move to the section they want.
* **Learning:** you’ll practice LINQ query composition, deferred execution, and converting queries to SQL with `Skip`/`Take`.

---

## What we change (high-level)

1. Add paging properties to your view model (`MovieGenreViewModel`).
2. Change the `Index` action to:

   * accept `pageNumber` and `pageSize`,
   * count total matching rows,
   * apply ordering, `Skip`, `Take`,
   * return the page + paging metadata to the view.
3. Update `Index.cshtml` to render pager controls and preserve filters (genre/search) when navigating.

Files you already have:

* `MoviesController.cs` (current `Index` action).
* `MovieGenreViewModel.cs`.

---

## 1) ViewModel — add paging metadata

Edit `MovieGenreViewModel` to include paging fields. Replace or extend the class with:

```csharp
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie>? Movies { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }

        // Paging properties
        public int PageNumber { get; set; }    // current page (1-based)
        public int PageSize { get; set; }      // items per page
        public int TotalCount { get; set; }    // total matching items
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
```

Why these fields:

* `PageNumber` and `PageSize` let the view show the active page and set page size.
* `TotalCount` is needed to calculate the number of pages.
* `TotalPages` is a convenience property for rendering pager links.

---

## 2) Controller changes — Index action (complete replacement)

Replace your current `Index` action with this revised action. It preserves the filtering logic you already have and adds paging. (This builds on the current controller you uploaded.)

```csharp
// GET: Movies
public async Task<IActionResult> Index(
    string? movieGenre,
    string? searchString,
    int pageNumber = 1,
    int pageSize = 10)   // default page size
{
    if (_context.Movie == null)
    {
        return Problem("Entity set 'MvcMovieContext.Movie' is null.");
    }

    // Base queries (deferred; not executed yet)
    IQueryable<string> genreQuery = from m in _context.Movie
                                    orderby m.Genre
                                    select m.Genre;

    var moviesQuery = from m in _context.Movie
                      select m;

    // Apply search filter (case-insensitive)
    if (!string.IsNullOrEmpty(searchString))
    {
        moviesQuery = moviesQuery.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
    }

    // Apply genre filter
    if (!string.IsNullOrEmpty(movieGenre))
    {
        moviesQuery = moviesQuery.Where(x => x.Genre == movieGenre);
    }

    // Count total results (execute COUNT(*) query)
    var totalCount = await moviesQuery.CountAsync();

    // Important: ordering before Skip/Take to guarantee deterministic results.
    // Choose the column you want to order by (Title is common).
    var pagedMovies = await moviesQuery
        .OrderBy(m => m.Title) // required before Skip
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var movieGenreVM = new MovieGenreViewModel
    {
        Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        Movies = pagedMovies,
        MovieGenre = movieGenre,
        SearchString = searchString,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalCount = totalCount
    };

    return View(movieGenreVM);
}
```

Key explanations (beginner-friendly):

* **Deferred execution:** `moviesQuery` is an `IQueryable`. No SQL runs until you call `.CountAsync()` or `.ToListAsync()`. Building filters first means the SQL generated will include `WHERE` clauses for the filters.
* **COUNT vs data fetch:** We call `CountAsync()` to find how many rows match the filters so we can compute total pages. This executes a `SELECT COUNT(*) ...` SQL query (fast on DB side).
* **OrderBy before Skip:** SQL `OFFSET`/`FETCH` semantics require a deterministic ordering. If you skip before ordering, results can be unpredictable. `Skip/Take` without `OrderBy` is unsupported by some providers or produces non-deterministic ordering.
* **Skip/Take:** `Skip((pageNumber - 1) * pageSize)` moves past rows for earlier pages; `Take(pageSize)` limits rows returned for the page. EF translates these to SQL `OFFSET ... FETCH NEXT ...` (or `ROW_NUMBER()` depending on DB).
* **Asynchronous IO:** We use `CountAsync()` and `ToListAsync()` so the thread isn't blocked while the DB responds. This is the recommended pattern in web apps.

---

## 3) View changes — render pager

In `Index.cshtml`, you already display movies from `MovieGenreViewModel`. Add a pager area (using Bootstrap pagination) near the bottom or top of the list. Example Razor snippet to add where appropriate:

```razor
@model MvcMovie.Models.MovieGenreViewModel

<!-- existing search/filter UI -->

<!-- Movies table/list here -->

@if (Model != null && Model.TotalPages > 1)
{
    <nav aria-label="Page navigation">
        <ul class="pagination">
            @* Previous button *@
            <li class="page-item @(Model.PageNumber == 1 ? "disabled" : "")">
                <a class="page-link"
                   asp-action="Index"
                   asp-route-pageNumber="@(Model.PageNumber - 1)"
                   asp-route-pageSize="@Model.PageSize"
                   asp-route-searchString="@Model.SearchString"
                   asp-route-movieGenre="@Model.MovieGenre">Previous</a>
            </li>

            @* Page number links *@
            @for (int p = 1; p <= Model.TotalPages; p++)
            {
                <li class="page-item @(p == Model.PageNumber ? "active" : "")">
                    <a class="page-link"
                       asp-action="Index"
                       asp-route-pageNumber="@p"
                       asp-route-pageSize="@Model.PageSize"
                       asp-route-searchString="@Model.SearchString"
                       asp-route-movieGenre="@Model.MovieGenre">@p</a>
                </li>
            }

            @* Next button *@
            <li class="page-item @(Model.PageNumber == Model.TotalPages ? "disabled" : "")">
                <a class="page-link"
                   asp-action="Index"
                   asp-route-pageNumber="@(Model.PageNumber + 1)"
                   asp-route-pageSize="@Model.PageSize"
                   asp-route-searchString="@Model.SearchString"
                   asp-route-movieGenre="@Model.MovieGenre">Next</a>
            </li>
        </ul>
    </nav>
}
```

Notes:

* `asp-route-...` preserves your current filters so clicking a page link keeps the `movieGenre` and `searchString` selection. This is how the pagination and filter UI stay in sync.
* `disabled` and `active` classes are Bootstrap helpers for styling.
* You can limit the number of page links shown (e.g., show only 5 pages around current) for very large `TotalPages`. Start simple with all pages.

---

## 4) Testing checklist (how to verify)

1. Seed enough rows (you already did that). If you need more data, re-run seed code.
2. Run the app and go to the Movies index. You should see only `pageSize` rows (e.g., 10).
3. Click page numbers — ensure results change and the URL contains `?pageNumber=2&pageSize=10&searchString=...` etc.
4. Try filters (search & genre) and confirm they stay applied when you click page links.
5. Check that going to page 1 disables Previous, last page disables Next.

---

## 5) Common pitfalls & how to avoid them

* **No OrderBy:** `Skip`/`Take` without `OrderBy` yields inconsistent results. Always order before skipping.
* **Counting after paging:** If you call `.Skip().Take().Count()` you’ll get the page count, not total count. Do `CountAsync()` on the filtered query **before** `Skip/Take`.
* **Large PageSize:** don’t set huge `pageSize` (e.g., 1000) in production.
* **Performance:** If filters or sorting use non-indexed columns, DB may be slower on large datasets—index columns used for filtering/sorting when needed.

---

## 6) Where this integrates with your existing code

* Your current `Index` filtering logic (search & genre) is taken from your controller. The new code preserves that logic and adds pagination.
* The `Movie` model and your filters (e.g., `Genre`) remain unchanged.
* ViewModel additions were added to `MovieGenreViewModel`.

---

## 7) Next improvements (optional, once paging works)

* Add **page size selector** (let user choose 10/25/50).
* Add **sorting** links (Title, ReleaseDate, Price); combine sorting with paging.
* Implement **ellipsized pager** (show '1 ... 4 5 6 ... 20') for many pages.
* Use a helper or library such as `X.PagedList` once you understand the manual approach.

---

If you want, I can now:

* Provide a complete `Index.cshtml` file with your current markup plus the pager inserted (I already have your `Index.cshtml` uploaded).
* Or give the minimal CSS/HTML to make the pager look nicer.

### SelectList() Method

In C#, the `SelectList` class is used to create a list of `SelectListItem` objects for use in dropdown lists within ASP.NET MVC and Razor Pages applications. It can be instantiated using various constructors that accept different parameters to define the list items, data value and text fields, selected value, and disabled values.

One common constructor initializes a `SelectList` using an `IEnumerable` of items, a data value field, and a data text field:

```csharp
public SelectList(IEnumerable items, string dataValueField, string dataTextField)
```

This constructor maps the `dataValueField` and `dataTextField` properties from the items to the `Value` and `Text` properties of the resulting `SelectListItem` objects, respectively  For example, when using a list of anonymous objects:

```csharp
var items = new[] { new { ID = "1", Name = "name1" }, new { ID = "2", Name = "name2" } };
ViewBag.Items = new SelectList(items, "ID", "Name");
```

Another constructor allows specifying a selected value:

```csharp
public SelectList(IEnumerable items, object selectedValue)
```

This sets the `Selected` property of the `SelectListItem` whose `Value` matches the `selectedValue` parameter  For instance:

```csharp
var selectList = new SelectList(new[] { "10", "15", "25" }, "15");
```

This creates a list where the item with value "15" is selected  A more comprehensive constructor also supports specifying disabled values:

```csharp
public SelectList(IEnumerable items, object selectedValue, IEnumerable disabledValues)
```

This enables marking certain items as disabled in the dropdown  Additionally, the `SelectList` can be initialized with a list of `SelectListItem` objects directly, which is useful when manually adding items with specific properties like `Selected` or `Disabled`

The `SelectList` class also supports grouping of items using a `DataGroupField` parameter in its constructor, allowing for hierarchical dropdowns  For example, when using a list of objects with a `Group` property, the `SelectList` can group items by that field

In Razor Pages, `SelectList` is commonly used in page models to populate dropdowns. For example:

```csharp
public SelectList Staff { get; set; }

public void OnGet()
{
    var staff = new List
    {
        new Person { Id = 1, Name = "Mike", Department = "IT" },
        new Person { Id = 2, Name = "Pete", Department = "Sales" }
    };
    Staff = new SelectList(staff, nameof(Person.Id), nameof(Person.Name), null, nameof(Person.Department));
}
```

This binds the `Id` property to the `Value`, the `Name` property to the `Text`, and uses `Department` as the group field  The `SelectList` can also be created from a dictionary, where keys and values are used for `Value` and `Text` respectively

In summary, the `SelectList` constructor provides flexible options for creating dropdown lists in C#, supporting data binding, selection, grouping, and disabling of items

# Q) Paging works perfectly, and I have added page selector

```
// Index.cshtml addition:
<form asp-controller="Movies" asp-action="Index" method="get">
    <p>

        // existing code 

        <label>Items Per Page:
        <select asp-for="PageSize" asp-items="Model.SizeSelection">
            <option value="">10(default)</option>
        </select>
        </label> 
    </p>
</form>
```

```
// MovieGenreViewModel.cs addition:
public SelectList? SizeSelection { get; set; }      // dropdown for PageSize
```

```
// MoviesController.cs addition:
var movieGenreVM = new MovieGenreViewModel
{      
       // existing code
       SizeSelection = new SelectList(new[] { 25, 50 }, 10)
}
```

Now, I have to add sorting. Teach me.

# A) Big-picture: why add sorting (before the how)

* **Why:** Sorting lets users order results (e.g., by Title, ReleaseDate, Price). It complements paging and filtering to make lists usable.
* **What we must do:** accept a `sortOrder` parameter, use it to apply an `OrderBy`/`OrderByDescending` to the `IQueryable` **before** `Skip`/`Take`, and provide UI links that toggle sort direction while preserving filters and page size.
* **Key principles you’ll practice:** query composition (deferred `IQueryable`), ordering before paging, preserving state in query strings, and making the UI reflect current sort.

(Your current controller and viewmodel are the starting point: see your `MoviesController.cs` and `MovieGenreViewModel.cs`.  )

---

## High-level changes required

1. Controller: add `string? sortOrder` parameter and compute sort toggles via `ViewData`. Apply ordering to the `moviesQuery` based on `sortOrder` before paging.
2. ViewModel / View: keep `PageNumber`, `PageSize`, filters; in the view render column headers as links that set `asp-route-sortOrder` to the toggle value and preserve other route params (search, genre, pageSize).
3. View: indicate active sort (CSS `active` or icon) and ensure clicking a sort link resets to page 1 (usually desirable).

---

## Controller — step-by-step (what & why)

1. **Add `sortOrder` parameter** so the action can receive `?sortOrder=...` from links:

   ```csharp
   public async Task<IActionResult> Index(string? movieGenre, string? searchString,
                                         string? sortOrder, int pageNumber = 1, int pageSize = 10)
   ```

2. **Record current sort and compute toggles** using `ViewData` so the view can build links that toggle direction:

   ```csharp
   ViewData["CurrentSort"] = sortOrder;
   ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : ""; // empty = title asc
   ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
   ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
   ```

   * Logic: if `sortOrder` is `null` or `""`, Title ascending is active; the Title link should set `title_desc` to toggle to descending.
   * For Date/Price we toggle between `Date` ↔ `date_desc` and `Price` ↔ `price_desc`.

3. **Apply ordering to the `IQueryable`** before `Skip/Take`:

   ```csharp
   switch (sortOrder)
   {
       case "title_desc":
           moviesQuery = moviesQuery.OrderByDescending(m => m.Title);
           break;
       case "Date":
           moviesQuery = moviesQuery.OrderBy(m => m.ReleaseDate);
           break;
       case "date_desc":
           moviesQuery = moviesQuery.OrderByDescending(m => m.ReleaseDate);
           break;
       case "Price":
           moviesQuery = moviesQuery.OrderBy(m => m.Price);
           break;
       case "price_desc":
           moviesQuery = moviesQuery.OrderByDescending(m => m.Price);
           break;
       default: // title ascending
           moviesQuery = moviesQuery.OrderBy(m => m.Title);
           break;
   }
   ```

   * **Why before paging:** SQL paging (`OFFSET`/`FETCH`/`ROW_NUMBER`) needs a deterministic order — otherwise pages are inconsistent.
   * **Why on `IQueryable`:** so EF translates ordering to SQL; sorting after `.ToListAsync()` would sort in-memory (inefficient).

4. **Then do Count, Skip, Take, ToListAsync** (as you did for pagination).

---

## Full integrated Index action (copy-paste-ready)

This is the complete Index method that combines filter + sorting + paging. Replace your existing Index with this:

```csharp
// GET: Movies
public async Task<IActionResult> Index(
    string? movieGenre,
    string? searchString,
    string? sortOrder,
    int pageNumber = 1,
    int pageSize = 10)
{
    if (_context.Movie == null)
    {
        return Problem("Entity set 'MvcMovieContext.Movie' is null.");
    }

    // Store current sort & compute toggles for view links
    ViewData["CurrentSort"] = sortOrder;
    ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
    ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
    ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

    // Base queries (deferred)
    IQueryable<string> genreQuery = from m in _context.Movie
                                    orderby m.Genre
                                    select m.Genre;

    var moviesQuery = from m in _context.Movie
                      select m;

    // Filters
    if (!string.IsNullOrEmpty(searchString))
    {
        moviesQuery = moviesQuery.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
    }

    if (!string.IsNullOrEmpty(movieGenre))
    {
        moviesQuery = moviesQuery.Where(x => x.Genre == movieGenre);
    }

    // Apply sorting (must happen before Skip/Take)
    switch (sortOrder)
    {
        case "title_desc":
            moviesQuery = moviesQuery.OrderByDescending(m => m.Title);
            break;
        case "Date":
            moviesQuery = moviesQuery.OrderBy(m => m.ReleaseDate);
            break;
        case "date_desc":
            moviesQuery = moviesQuery.OrderByDescending(m => m.ReleaseDate);
            break;
        case "Price":
            moviesQuery = moviesQuery.OrderBy(m => m.Price);
            break;
        case "price_desc":
            moviesQuery = moviesQuery.OrderByDescending(m => m.Price);
            break;
        default:
            moviesQuery = moviesQuery.OrderBy(m => m.Title);
            break;
    }

    // Total count for paging
    var totalCount = await moviesQuery.CountAsync();

    // Apply paging
    var pagedMovies = await moviesQuery
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var movieGenreVM = new MovieGenreViewModel
    {
        Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
        Movies = pagedMovies,
        MovieGenre = movieGenre,
        SearchString = searchString,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalCount = totalCount
    };

    return View(movieGenreVM);
}
```

(You can compare and integrate this into your controller that currently contains the filter/pagination code. )

---

## View — how to create sortable column headers (what & why)

* Replace static column headers (e.g., `Title`, `Release Date`, `Price`) with links that set `asp-route-sortOrder` to the toggle values you stored in `ViewData`.
* Preserve other route params: `pageSize`, `searchString`, `movieGenre` so filters/paging are not lost when changing sort.

Example header cells (Razor):

```razor
<th>
    <a asp-action="Index"
       asp-route-sortOrder="@(ViewData["TitleSortParm"])"
       asp-route-pageSize="@Model.PageSize"
       asp-route-searchString="@Model.SearchString"
       asp-route-movieGenre="@Model.MovieGenre">
       Title
    </a>
</th>
<th>
    <a asp-action="Index"
       asp-route-sortOrder="@(ViewData["DateSortParm"])"
       asp-route-pageSize="@Model.PageSize"
       asp-route-searchString="@Model.SearchString"
       asp-route-movieGenre="@Model.MovieGenre">
       Release Date
    </a>
</th>
<th>
    <a asp-action="Index"
       asp-route-sortOrder="@(ViewData["PriceSortParm"])"
       asp-route-pageSize="@Model.PageSize"
       asp-route-searchString="@Model.SearchString"
       asp-route-movieGenre="@Model.MovieGenre">
       Price
    </a>
</th>
```

**Why this works**

* Clicking the link sends `?sortOrder=...` plus existing filters/size.
* The controller reads `sortOrder`, applies the ordering and returns the paged results.

**Optional UI polish:** show an up/down caret next to the active sorted column by checking `ViewData["CurrentSort"]`.

---

## Things to keep in mind (pitfalls & tips)

* **Always `OrderBy` before `Skip`/`Take`.** If you forget, pages may contain duplicates or inconsistent rows.
* **Use server-side ordering (on `IQueryable`)** — do not materialize the query first (`ToList`) and then sort for large datasets.
* **Reset page number on sort change**: if the user is on page 5 and toggles sort, it’s usually better to go back to page 1. You can do this by setting `asp-route-pageNumber="1"` on sort links instead of preserving current page.
* **Keep route params stable**: always pass `pageSize`, `searchString`, and `movieGenre` so state is preserved.
* **Performance:** index the columns you’ll sort by on large tables (Title, ReleaseDate, Price), though for LocalDB and learning this is not required.

---

## Quick checklist to implement

1. Add `sortOrder` param and `ViewData` toggles in `Index`.
2. Add `switch` or `if` ordering logic before paging.
3. Update header links in `Index.cshtml` to point to `asp-route-sortOrder` and include other route params.
4. Optionally show indicators for active sort direction.
5. Test combinations: sort + filter + page size + paging.

---

If you want, I will:

* produce a full `Index.cshtml` snippet that includes the table, pager, and header links adjusted for your current ViewModel structure (I have your `Index.cshtml` and can insert the header code).

# Q) I want to learn Authentication & Authorization in ASP.NET Core MVC through this project now. What should be the focus? Detailed steps to implement & learn alongside?

# A) # Why focus on Authentication & Authorization (high level)

* **Authentication** = *who are you?* (log in / identity).
* **Authorization** = *what are you allowed to do?* (roles, policies).
  Together they let you restrict Create/Edit/Delete to trusted users, show/hide UI elements, audit actions, and practice common web-app security patterns. For your MVC Movie app these map directly to real needs: only logged-in users can add movies; only admins can delete, etc.

## Learning goals (what you should understand after this)

1. How ASP.NET Core identifies users (Identity) and issues auth cookies.
2. How to wire up Identity in an existing app (services, DB, migrations).
3. How to protect controllers/actions using `[Authorize]`, roles, and policies.
4. How to scaffold or provide UI for register/login/logout (Identity UI).
5. How to seed a default admin user and role.
6. How to adapt views (show/hide links) using `User.Identity.IsAuthenticated` / `User.IsInRole(...)`.
7. Basic secure configuration: password rules, cookie options, account confirmation (overview).

## Recommended approach for this project (practical, beginner-friendly)

* Use **ASP.NET Core Identity** (built-in) — easiest, secure, full-featured.
* Implement **Role-based authorization** (`Admin` role) to secure Create/Edit/Delete.
* Scaffold the default Identity UI (so you get Register/Login pages).
* Seed an admin account and role during app startup.
* Protect controller actions with `[Authorize]` and optionally policy-based checks.

## Step-by-step implementation (detailed)

## 1. Add Identity packages (if needed)

If you created MVC with Identity earlier, packages may already be present. If not, add these packages via NuGet:

* `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
* `Microsoft.AspNetCore.Identity.UI` (for scaffolding UI)
  You can use Visual Studio NuGet or CLI:

```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Identity.UI
```

## 2. Add an Identity DbContext

You can either:

* reuse your existing EF Core DbContext (not recommended for beginners), or
* add a dedicated `ApplicationDbContext : IdentityDbContext` (simpler to scaffold).

Create `Data/ApplicationDbContext.cs`:

```csharp
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

## 3. Configure services in `Program.cs`

Register Identity services and the new DbContext. Example (insert near other `AddDbContext` calls):

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // true for production email confirmation
    options.Password.RequireNonAlphanumeric = false; // adjust policy as desired
})
    .AddRoles<IdentityRole>() // enable roles
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
```

Make sure `appsettings.json` has `DefaultConnection` or reuse your existing LocalDB connection.

## 4. Add migrations & update DB

Create a migration and update the database so Identity tables are created:

```powershell
Add-Migration IdentityInit
Update-Database
```

(or `dotnet ef migrations add IdentityInit` / `dotnet ef database update` from CLI)

## 5. Scaffold Identity UI (so you get Register / Login pages)

Options:

* Visual Studio: Right-click project → Add → New Scaffolded Item → Identity → Select the pages you want (Register, Login, Logout, Manage), choose your `ApplicationDbContext`.
* CLI (requires `dotnet-aspnet-codegenerator`):
  `dotnet aspnet-codegenerator identity -dc ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout"`

Scaffolding copies Razor Pages under `Areas/Identity/Pages/Account/...` that you can customize.

## 6. Ensure middleware is enabled

In `Program.cs` after `app.UseRouting()` add:

```csharp
app.UseAuthentication();
app.UseAuthorization();
```

`UseAuthentication()` must come before `UseAuthorization()`.

## 7. Seed admin role and user at startup

Add seeding logic after `var app = builder.Build();` and before `app.Run();`:

```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    // create Admin role if missing
    var adminRole = "Admin";
    if (!await roleManager.RoleExistsAsync(adminRole))
    {
        await roleManager.CreateAsync(new IdentityRole(adminRole));
    }

    // create default admin user
    var adminEmail = "admin@example.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
        var result = await userManager.CreateAsync(adminUser, "P@ssw0rd!"); // choose secure password
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, adminRole);
        }
        else
        {
            // log or inspect result.Errors
        }
    }
}
```

> Note: use a secure password and change in production. For local dev this is acceptable.

## 8. Protect controllers/actions

Use attributes to restrict access.

* Restrict entire Movies controller to authenticated users:

```csharp
[Authorize]
public class MoviesController : Controller
{
    ...
}
```

* Or restrict specific actions (Create/Edit/Delete) to role `Admin`:

```csharp
[Authorize(Roles = "Admin")]
public IActionResult Delete(int id) { ... }
```

* Allow anonymous for Index & Details:

```csharp
[AllowAnonymous]
public async Task<IActionResult> Index(...) { ... }
```

## 9. Protect view UI (show/hide links)

In `_Layout.cshtml` or `Index.cshtml`, conditionally render links:

```razor
@if (User.Identity.IsAuthenticated)
{
    <a asp-area="Identity" asp-page="/Account/Manage/Index">Hello, @User.Identity.Name</a>
    <form method="post" asp-area="Identity" asp-page="/Account/Logout">
        <button type="submit" class="nav-link btn btn-link">Logout</button>
    </form>
}
else
{
    <a asp-area="Identity" asp-page="/Account/Register">Register</a>
    <a asp-area="Identity" asp-page="/Account/Login">Login</a>
}

// Show Create/Edit/Delete only to admins:
@if (User.IsInRole("Admin"))
{
    <a asp-action="Create">Create New</a>
}
```

## 10. Use policy-based authorization (optional intermediate step)

Define policies in `Program.cs`:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
});
```

Use:

```csharp
[Authorize(Policy = "RequireAdmin")]
public IActionResult Delete(int id) { ... }
```

## 11. Test scenarios

* Register a normal user and verify they can/can’t access protected pages.
* Use seeded admin account to login; verify admin-only actions succeed.
* Ensure unauthorized requests redirect to login and show proper behavior.
* Test UI: login/logout, role-based visibility of links, attempt direct URL access to restricted actions.

## Security & best practices (short list)

* Require email confirmation for production (`RequireConfirmedAccount = true`).
* Use strong password policy.
* Protect admin credential (do not seed with real credentials in production). Use environment variables / secrets.
* Use HTTPS.
* Consider enabling account lockout for failed logins.
* Keep Identity tables separate from domain tables for clarity.

## Variations & next learning steps

* **Cookie-only auth (no Identity)** — simpler but you must implement user management; useful to learn fundamentals.
* **External login** — Google/GitHub sign-in (learn OAuth/OIDC).
* **Claims-based auth** — more flexible than roles (e.g., tenant-based permissions).
* **Policy-based checks** that combine claims, roles, or resource ownership (e.g., only the creator can edit their movie).
* **Two-factor auth** with Identity UI.

## Practical checklist to follow now (one-by-one)

1. Add `ApplicationDbContext` and Identity packages (if not present).
2. Update `Program.cs` to add Identity services and middleware.
3. Add Identity migration & run `Update-Database`.
4. Scaffold Identity UI (Register/Login).
5. Seed Admin role/user in startup scope.
6. Apply `[Authorize]` / `[AllowAnonymous]` / `[Authorize(Roles="Admin")]` in your `MoviesController`.
7. Update `_Layout.cshtml` to show login/register or logout and admin links.
8. Test all flows (register, login, admin actions, unauthorized access).
9. Tighten policies and password rules as you learn.

## Ready to proceed

I can now produce the exact code changes for your project (Program.cs snippets, `ApplicationDbContext`, migration commands, seed code, and sample controller attribute changes), plus the precise Razor changes for `_Layout.cshtml` and the scaffolding commands for Visual Studio/CLI — tell me if you want that and I will generate them.
