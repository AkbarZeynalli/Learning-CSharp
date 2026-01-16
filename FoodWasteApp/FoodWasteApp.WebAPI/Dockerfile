FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["FoodWasteApp.WebAPI/FoodWasteApp.WebAPI.csproj", "FoodWasteApp.WebAPI/"]
COPY ["FoodWasteApp.BLL/FoodWasteApp.BLL.csproj", "FoodWasteApp.BLL/"]
COPY ["FoodWasteApp.DAL/FoodWasteApp.DAL.csproj", "FoodWasteApp.DAL/"]

RUN dotnet restore "FoodWasteApp.WebAPI/FoodWasteApp.WebAPI.csproj"

COPY . .

WORKDIR "/src/FoodWasteApp.WebAPI"
RUN dotnet build "FoodWasteApp.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodWasteApp.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodWasteApp.WebAPI.dll"]