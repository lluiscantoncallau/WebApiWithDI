FROM mcr.microsoft.com/mssql/server:2017-latest
ENV SA_PASSWORD=Altran2019!
ENV ACCEPT_EULA=Y
COPY entrypoint.sh entrypoint.sh
COPY SqlCmdStartup.sh SqlCmdStartup.sh
RUN apt-get update && apt-get install -y \
    netcat
RUN chmod +x ./SqlCmdStartup.sh
CMD /bin/bash ./entrypoint.sh