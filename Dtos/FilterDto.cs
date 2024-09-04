using TestTask.Enums;

namespace TestTask.Dtos;

public class FilterDto
{
    public int Limit { get; set; } = 25;
    public int Page { get; set; } = 1;
    public string? SortColumn { get; set; }
    public SortType? SortType { get; set; }
}