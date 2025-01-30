#!/bin/bash

echo "Waiting for Oracle to be ready..."

until dotnet ef database update --connection "User Id=system;Password=oracle;Data Source=oracle-db:1521/XEPDB1"
do
  echo "Database not ready yet. Retrying in 10 seconds..."
  sleep 10
done

echo "Database migration applied successfully."
exec dotnet Match.Api.dll
