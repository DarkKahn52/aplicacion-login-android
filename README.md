# Calculadora UNIMEX — .NET MAUI + API

La solución conserva el aspecto azul/neón, el login, el registro y el servicio que devuelve una imagen aleatoria de un coche. La calculadora del proyecto MVC fue omitida conforme a la solicitud.

## Arquitectura

- `CalculadoraUnimex.App`: app .NET MAUI para Android y Windows.
- `CalculadoraUnimex.Api`: API ASP.NET Core que se conecta a SQL Server usando la cadena integrada de Windows.
- `Database`: script de tabla y procedimientos almacenados.

Android no puede conectarse directamente a `MSI\SQLEXPRESS` con `Integrated Security=True`; por eso la API debe ejecutarse en la PC donde está SQL Server.

## Preparación

1. Abre SQL Server Management Studio y ejecuta `Database/CrearBaseYStoredProcedures.sql` sobre `CalculadoraLoginDB`.
2. Comprueba la cadena en `CalculadoraUnimex.Api/appsettings.json`.
3. Abre una terminal en `CalculadoraUnimex.Api` y ejecuta:
   ```powershell
   dotnet restore
   dotnet run
   ```
   Debe escuchar en `http://0.0.0.0:5098`.
4. Abre otra terminal en `CalculadoraUnimex.App` y ejecuta:
   ```powershell
   dotnet workload restore
   dotnet build -f net10.0-android
   ```
5. Inicia el emulador desde VS Code con la extensión .NET MAUI o compila desde Visual Studio.

## Dispositivo Android físico

En `Services/ApiService.cs`, cambia `10.0.2.2` por la IPv4 local de tu PC, por ejemplo `192.168.1.25`. El teléfono y la PC deben estar en la misma red Wi-Fi. Permite el puerto TCP 5098 en Firewall de Windows.

## Instalaciones recomendadas

- .NET 10 SDK.
- Visual Studio Code actualizado.
- Android SDK, Android Emulator y JDK, instalados mediante Visual Studio Installer o Android Studio.
- Workload: `dotnet workload install maui-android`.
- Extensiones de VS Code: **.NET MAUI**, **C# Dev Kit** y **C#** de Microsoft.
- SQL Server Express y SQL Server Management Studio.

## Observación de seguridad

Se mantuvo el campo `Password` para compatibilidad con la base existente. Para producción debe almacenarse un hash seguro, nunca la contraseña en texto plano.
