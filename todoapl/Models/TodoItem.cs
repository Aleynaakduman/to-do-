namespace TodoApi.Models;

public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? DueDate { get; set; }
    public string? Priority { get; set; }
    public string? CategoryId { get; set; }
    public string? ReminderTime { get; set; }
    public bool IsNotificationActive { get; set; }
    public string? StatusId { get; set; }
}