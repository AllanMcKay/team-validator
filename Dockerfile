FROM microsoft/aspnetcore:2.0
#WORKDIR /app
COPY /app .
ENTRYPOINT ["dotnet", "Service.dll"]

# tell docker what port to expose
EXPOSE 80

HEALTHCHECK CMD curl -f http://localhost/ || exit 1
