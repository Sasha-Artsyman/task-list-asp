// начальные данные
List<AllTasks> tasks = new List<AllTasks>
{
    new() { Id = Guid.NewGuid().ToString(), Title = "Complete your to-do", Autor = "Admin", DateOfCreation = "01.01.2022 11:00:00", Description = "Complete my to-do list for today", Done = true},
    new() { Id = Guid.NewGuid().ToString(), Title = "End project", Autor = "Admin", DateOfCreation = "01.01.2022 11:21:01", Description = "End project at 18:00", Done = false},
    new() { Id = Guid.NewGuid().ToString(), Title = "Meeting", Autor = "Admin", DateOfCreation = "01.01.2022 12:55:00", Description = "Meetingmeeting at 18:30", Done = false}
};

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/tasks", () => tasks);

app.MapGet("/api/tasks/{id}", (string id) =>
{
    AllTasks? task = tasks.FirstOrDefault(t => t.Id == id);
    if (task == null) return Results.NotFound(new { message = "Task not found!" });

    return Results.Json(task);
});

app.Run();

public class AllTasks
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Autor { get; set; } = "";
    public string DateOfCreation { get; set; } = DateTime.Now.ToString();
    public string Description { get; set; } = "";
    public bool Done { get; set; } = false;
}
