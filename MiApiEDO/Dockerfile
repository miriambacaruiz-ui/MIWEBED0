FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
# ¡ESTA LÍNEA ES LA CLAVE! Debe copiar el csproj correcto.
COPY ["MiApiEDO.csproj", "./"]
RUN dotnet restore "MiApiEDO.csproj"
COPY . .
RUN dotnet publish "MiApiEDO.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:10000
ENTRYPOINT ["dotnet", "MiApiEDO.dll"]
