namespace CalculadoraUnimex.App.Models;
public sealed record LoginRequest(string Correo,string Password);
public sealed record RegisterRequest(string Nombre,string Correo,string Password,string ConfirmarPassword);
public sealed record ApiResult(bool Success,string Message);
public sealed record CarResponse(string Imagen);
