using Net8Demo.Api;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

var sampleTodos = TodoGenerator.GenerateTodos().ToArray();

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound()).WithName("TodoDetail");

todosApi
    .MapPost("/", (Todo model) =>
    {
        TodoStore.AddTodo(model);
        return Results.CreatedAtRoute("TodoDetail", new { id = model.Id }, model);
    });

app.Run();

