using RskladWebElements.Middlewares;
using RskladWebElements.Models;

List<KtruItem> ktru = new List<KtruItem>();

ktru.Add(new KtruItem { Id = "1", Name = "name 1", Description = "desc 1"});
ktru.Add(new KtruItem { Id = "2", Name = "name 2", Description = "desc 2"});
ktru.Add(new KtruItem { Id = "3", Name = "name 3", Description = "desc 3"});


var builder = WebApplication.CreateBuilder();

var app = builder.Build();

//ktru?token=3e839161-bfb5-49a2-97ad-48e2411f767a
app.UseMiddleware<AuthenticationMiddleware>(); 

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;

    if (path == "/api/ktru" && request.Method == "GET")
    {
        await getKTRU(response);
    }
    else if (path == "/ktru")
    {
        response.ContentType = "text/html; charset=utf-8;";
        await response.SendFileAsync("Html/ktru.html");
    }
});

app.Run();

async Task getKTRU(HttpResponse response)
{
    await response.WriteAsJsonAsync(ktru);
}