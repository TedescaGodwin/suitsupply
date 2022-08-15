#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Suit.Supply.Web/Suit.Supply.Web.csproj", "src/Suit.Supply.Web/"]
COPY ["src/Suit.Supply.Infrastructure/Suit.Supply.Infrastructure.csproj", "src/Suit.Supply.Infrastructure/"]
COPY ["src/Suit.Supply.SharedKernel/Suit.Supply.SharedKernel.csproj", "src/Suit.Supply.SharedKernel/"]
COPY ["src/Suit.Supply.Core/Suit.Supply.Core.csproj", "src/Suit.Supply.Core/"]
RUN dotnet restore "src/Suit.Supply.Web/Suit.Supply.Web.csproj"
COPY . .
WORKDIR "/src/src/Suit.Supply.Web"
RUN dotnet build "Suit.Supply.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Suit.Supply.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Suit.Supply.Web.dll"]