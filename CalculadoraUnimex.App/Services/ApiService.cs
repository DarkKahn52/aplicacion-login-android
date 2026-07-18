using System.Net.Http.Json;
using CalculadoraUnimex.App.Models;
namespace CalculadoraUnimex.App.Services;
public sealed class ApiService
{
 private readonly HttpClient _http;
 public ApiService(){var baseUrl=DeviceInfo.Platform==DevicePlatform.Android?"http://192.168.0.97:5098/":"http://localhost:5098/";_http=new HttpClient{BaseAddress=new Uri(baseUrl),Timeout=TimeSpan.FromSeconds(30)};}
 public async Task<ApiResult> LoginAsync(LoginRequest request)=>await SendAsync("api/auth/login",request);
 public async Task<ApiResult> RegisterAsync(RegisterRequest request)=>await SendAsync("api/auth/register",request);
 public async Task<CarResponse> GetRandomCarAsync()=>await _http.GetFromJsonAsync<CarResponse>("api/car/random")??throw new InvalidOperationException("Respuesta vacía del servicio.");
 private async Task<ApiResult> SendAsync<T>(string path,T body){using var response=await _http.PostAsJsonAsync(path,body);var result=await response.Content.ReadFromJsonAsync<ApiResult>();return result??new ApiResult(false,"El servidor devolvió una respuesta no válida.");}
}
