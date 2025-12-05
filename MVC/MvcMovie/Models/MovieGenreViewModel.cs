using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Models;

public class MovieGenreViewModel
{
    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }
    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }
    public string? SortOrder { get; set; }


    // Paging properties
    public int PageNumber { get; set; }    // current page (1-based)
    public int PageSize { get; set; }      // items per page
    public SelectList? SizeSelection { get; set; }      // dropdown for PageSize

    public int TotalCount { get; set; }    // total matching items
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

}