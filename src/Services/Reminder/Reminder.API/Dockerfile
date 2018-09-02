#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 56831
EXPOSE 44391

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Reminder.API/Reminder.API.csproj", "Reminder.API/"]
RUN dotnet restore "Reminder.API/Reminder.API.csproj"
COPY . .
WORKDIR "/src/Reminder.API"
RUN dotnet build "Reminder.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Reminder.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Reminder.API.dll"]