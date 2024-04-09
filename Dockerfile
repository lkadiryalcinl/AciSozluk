# Ýlk aþama: Derleme ortamý
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /source
COPY . .
RUN dotnet restore "./EksiSozluk.WebAPI/EksiSozluk.WebAPI.csproj" --disable-parallel
RUN dotnet publish "./EksiSozluk.WebAPI/EksiSozluk.WebAPI.csproj" -c release -o /app --no-restore

# Ýkinci aþama: Çalýþtýrma ortamý
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app ./
EXPOSE 5000
ENTRYPOINT ["dotnet", "EksiSozluk.WebAPI.dll"]
