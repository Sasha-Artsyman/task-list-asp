// начальные данные
List<AllTasks> tasks = new List<AllTasks>
{
    new() { Id = Guid.NewGuid().ToString(), Title = "Complete your to-do", Autor = "Admin", Date = "01.01.2022", Description = "Complete my to-do list for today", Done = true},
    new() { Id = Guid.NewGuid().ToString(), Title = "End project", Autor = "Admin", Date = "01.01.2022", Description = "End project at 18:00", Done = false},
    new() { Id = Guid.NewGuid().ToString(), Title = "Meeting", Autor = "Admin", Date = "01.01.2022", Description = "Meetingmeeting at 18:30", Done = false},
    new() { Id = Guid.NewGuid().ToString(), Title = "Send files", Autor = "Admin", Date = "02.01.2022", Description = "Send files to the customer and attach instructions and a description of the business process to it", Done = false}
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

app.MapDelete("/api/tasks/{id}", (string id) =>
{
    AllTasks? task = tasks.FirstOrDefault(t => t.Id == id);

    if (task == null) return Results.NotFound(new { message = "Task not found!" });

    tasks.Remove(task);
    return Results.Json(task);
});

app.MapPost("/api/tasks", (AllTasks task) => {

    task.Id = Guid.NewGuid().ToString();
    tasks.Add(task);
    return task;
});

app.MapPut("/api/tasks", (AllTasks taskData) => {

    var task = tasks.FirstOrDefault(t => t.Id == taskData.Id);
    if (task == null) return Results.NotFound(new { message = "Task not found!" });

    task.Title = taskData.Title;
    task.Autor = taskData.Autor;
    task.Date = taskData.Date;
    task.Description = taskData.Description;
    task.Done = taskData.Done;
    return Results.Json(task);
});

app.Run();

public class AllTasks
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Autor { get; set; } = "";
    public string Date { get; set; } = "";
    public string Description { get; set; } = "";
    public bool Done { get; set; } = false;
}
