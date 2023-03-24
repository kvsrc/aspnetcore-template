using Template.Api.Boot.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Register();

WebApplication app = builder.Build();

app.Configure();

app.Run();
