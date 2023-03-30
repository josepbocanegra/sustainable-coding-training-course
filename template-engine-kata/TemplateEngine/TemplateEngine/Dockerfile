FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TemplateEngine/TemplateEngine.csproj", "TemplateEngine/"]
RUN dotnet restore "TemplateEngine/TemplateEngine.csproj"
COPY . .
WORKDIR "/src/TemplateEngine"
RUN dotnet build "TemplateEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TemplateEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemplateEngine.dll"]
