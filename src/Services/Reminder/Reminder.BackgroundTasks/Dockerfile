#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 57771
EXPOSE 44345

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Reminder.BackgroundTasks/Reminder.BackgroundTasks.csproj", "Reminder.BackgroundTasks/"]
RUN dotnet restore "Reminder.BackgroundTasks/Reminder.BackgroundTasks.csproj"
COPY . .
WORKDIR "/src/Reminder.BackgroundTasks"
RUN dotnet build "Reminder.BackgroundTasks.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Reminder.BackgroundTasks.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Reminder.BackgroundTasks.dll"]