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
