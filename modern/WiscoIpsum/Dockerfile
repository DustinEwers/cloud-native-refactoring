FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WiscoIpsum/WiscoIpsum.csproj", "WiscoIpsum/"]
RUN dotnet restore "WiscoIpsum/WiscoIpsum.csproj"
COPY . .
WORKDIR "/src/WiscoIpsum"
RUN dotnet build "WiscoIpsum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WiscoIpsum.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "WiscoIpsum.dll"]