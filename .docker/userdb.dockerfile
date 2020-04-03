FROM mcr.microsoft.com/mssql/server
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Password12345
COPY . .
ENTRYPOINT [ "/bin/bash", "userentrypoint.sh" ]
CMD [ "/opt/mssql/bin/sqlservr" ]

# need to change ENTRYPOINT and CMD