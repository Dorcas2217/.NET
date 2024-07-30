var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/tva/{price}/{codee}", (int prix, string code) =>
{
    double tva = 0;

    if(code == "BE")
    {
        tva = prix * 1.21;
        return Results.Ok("Prix TVA Belgique:  " + tva);
    }

    if(code == "FR")
    {
        tva = prix * 1.20;
        return Results.Ok("Prix TVA France:  " + tva);
    }

    return  Results.BadRequest("code de pays non valide; utilisez BE ou FR ");
});

app.Run();

