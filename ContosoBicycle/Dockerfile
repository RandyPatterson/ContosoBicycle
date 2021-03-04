#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
COPY ${source:-obj/Docker/publish/entrypoint/Startup.ps1} c:/
# Updates web.config on startup with environment variables starting with APPSETTING_ and CONNSTR_
COPY ${source:-obj/Docker/publish/entrypoint/WebconfigOverride.ps1} c:/
ENTRYPOINT ["powershell.exe", "c:\\Startup.ps1"]
