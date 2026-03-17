using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using SHKProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<VillageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Stronghold Kingdoms Proxy API - Ready");

// Авторизация и подключение к игре
app.MapPost("/api/connect", async (ConnectRequest request, VillageService villageService) =>
{
    try
    {
        Console.WriteLine($"Подключение к игре: {request.Email}");
        
        var success = await GameClient.Instance.LoginAsync(request.Email, request.Password);
        
        if (success)
        {
            // Получаем все координаты деревень
            var coordinates = GameClient.Instance.GetAllVillageCoordinates();
            
            // Сохраняем их в VillageService
            foreach (var coord in coordinates.Values)
            {
                villageService.CacheVillage(coord.VillageId, coord.X, coord.Y, coord.Name);
            }
            
            return Results.Ok(new { 
                success = true, 
                message = "Подключено к игре", 
                villageCount = coordinates.Count 
            });
        }
        
        return Results.BadRequest(new { success = false, message = "Ошибка подключения" });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        return Results.BadRequest(new { success = false, message = ex.Message });
    }
});

// Авторизация (старый endpoint, оставлен для совместимости)
app.MapPost("/api/login", (LoginRequest request, VillageService villageService) =>
{
    Console.WriteLine($"Login attempt: {request.Username}");
    
    bool success = villageService.ConnectToGame(request.ServerUrl, request.Username, request.Password);
    
    return Results.Ok(new
    {
        success = success,
        message = success ? "Connected" : "Connection not implemented. Need RemoteServices integration."
    });
});

// Получить координаты деревни
app.MapGet("/api/village/{villageId}", (int villageId, VillageService villageService) =>
{
    var village = villageService.GetVillage(villageId);
    
    if (village == null)
    {
        return Results.NotFound(new { error = $"Village {villageId} not found" });
    }
    
    return Results.Ok(village);
});

// Добавить деревню в кэш (временно, для тестирования)
app.MapPost("/api/village", (Village village, VillageService villageService) =>
{
    villageService.CacheVillage(village.Id, village.X, village.Y, village.Name);
    return Results.Ok(new { message = "Village cached", village });
});

// Рассчитать время атак
app.MapPost("/api/calculate-attacks", (AttackRequest request, VillageService villageService) =>
{
    var results = new List<object>();
    
    var targetVillage = villageService.GetVillage(request.TargetVillageId);
    if (targetVillage == null)
    {
        return Results.BadRequest(new { error = $"Target village {request.TargetVillageId} not found" });
    }
    
    foreach (var attackingId in request.AttackingVillageIds)
    {
        var attackingVillage = villageService.GetVillage(attackingId);
        if (attackingVillage == null)
        {
            results.Add(new { village_id = attackingId, error = "Not found" });
            continue;
        }
        
        // Рассчитать расстояние
        double dx = targetVillage.X - attackingVillage.X;
        double dy = targetVillage.Y - attackingVillage.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        
        // Рассчитать время (капитаны = 15 клеток/час)
        double hours = distance / 15.0;
        int h = (int)hours;
        int m = (int)((hours - h) * 60);
        int s = (int)(((hours - h) * 60 - m) * 60);
        
        results.Add(new
        {
            village_id = attackingId,
            distance = Math.Round(distance, 2),
            travel_time = $"{h}h:{m}m:{s}s"
        });
    }
    
    return Results.Ok(new
    {
        target_village_id = request.TargetVillageId,
        attacks = results
    });
});

Console.WriteLine("Starting SHK Proxy on http://localhost:5000");
Console.WriteLine("Swagger UI: http://localhost:5000/swagger");
app.Run("http://localhost:5000");

record LoginRequest(string Username, string Password, string ServerUrl);
record AttackRequest(int TargetVillageId, List<int> AttackingVillageIds);
record ConnectRequest(string Email, string Password);
