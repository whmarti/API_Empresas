#!/bin/bash
echo "Esperando que SQL Server esté listo..."
sleep 15
echo "Creando base de datos con EF Core..."
dotnet ef database update
