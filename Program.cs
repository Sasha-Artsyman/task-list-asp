// начальные данные
List<AllTasks> tasks = new List<AllTasks>
{
    new() { Id = Guid.NewGuid().ToString(), Title = "Complete your to-do", Autor = "Admin", DateOfCreation = "01.01.2022 11:00:00", Description = "Complete your to-do list for today", Done = false}
};

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/tasks", () => tasks);

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
