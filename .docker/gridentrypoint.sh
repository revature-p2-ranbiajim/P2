#!/bin/bash
set -v
set -e
if [ "$1" = '/opt/mssql/bin/sqlservr' ]; then
  # If this is the container's first run, initialize the application database
  if [ ! -f /tmp/app-initialized ]; then
    # Initialize the application database
    function initialize_app_database() {
      # Wait
      sleep 20s
      #run the setup script
      /opt/mssql-tools/bin/sqlcmd -S "sql_1" -U sa -P Password12345 -d master -i setupGrid.sql
      # Note that the container has been initialized
      #touch /tmp/app-initialized
    }
    initialize_app_database &
  fi
fi
exec "$@"