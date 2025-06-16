# PruebaJunio
Prueba tecnica

Inventory Management System – Guía de Instalación y Despliegue
Este proyecto es un sistema de gestión de inventario desarrollado en .NET 8, dividido en una API RESTful y una aplicación web ASP.NET Core MVC como frontend. Se utiliza JWT para autenticación y una base de datos MySQL.

Requisitos Previos
.NET 8 SDK
MySQL Server (o MariaDB compatible)
Visual Studio Code o Visual Studio
Git
Navegador web moderno (Chrome, Edge, Firefox)

Configuración del Entorno
1. Clonar el repositorio
bash
Copy
Edit
git clone https://github.com/tuusuario/inventory-system.git
cd inventory-system/InventorySolution

3. Configurar la base de datos
Crear una base de datos en MySQL llamada: prubea
Credenciales predeterminadas (modificables en el código):

sql
Copy
Edit
Usuario: root
Contraseña: 1234567

3. Aplicar migraciones 

cd InventoryAPI
dotnet ef database update.

Cómo ejecutar el proyecto
1. Ejecutar el backend
Desde la carpeta InventoryAPI:
dotnet run
Por defecto estará disponible en:
http://localhost:5116

2. Ejecutar el frontend
En otra terminal, ir a la carpeta InventoryFrontend:
cd ../InventoryFrontend
dotnet run
Por defecto se abrirá en: http://localhost:5246

Credenciales de acceso
Se utiliza un único usuario global para autenticación (modo simplificado):

Usuario: admin

Contraseña: 1234

Funcionalidades principales
Login con JWT

Visualización de productos agrupados por estado

Backend desacoplado y seguro

Frontend en ASP.NET MVC con sesiones

Arquitectura escalable para manufactura

Estructura del Proyecto
InventorySolution/
├── InventoryAPI/         # API RESTful (.NET 8 Web API)
│   └── Controllers/
│   └── Services/
│   └── Models/
├── InventoryFrontend/    # ASP.NET Core MVC (Frontend)
│   └── Controllers/
│   └── Views/
│   └── Models/

📄 Licencia
Este proyecto se entrega como parte de una prueba técnica. Su uso o redistribución está limitado al alcance de dicha evaluación.




 







