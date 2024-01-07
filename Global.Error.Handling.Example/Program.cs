var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging();
#region New Method
builder.Services.AddExceptionHandler<Global.Error.Handling.Example.New_Method.DivideByZeroExceptionHandler>();
builder.Services.AddExceptionHandler<Global.Error.Handling.Example.New_Method.NullReferenceExceptionHandler>();
builder.Services.AddExceptionHandler<Global.Error.Handling.Example.New_Method.ExceptionHandler>();

builder.Services.AddProblemDetails();
#endregion

var app = builder.Build();

#region Traditional Method
//app.UseMiddleware<Global.Error.Handling.Example.Traditional_Method.ExceptionHandlingMiddleware>();
#endregion
#region New Method
app.UseExceptionHandler();
#endregion

app.MapGet("/", () =>
{
    throw new Exception("Laylaylom galiba sana göre sevmeler...");
});

app.Run();