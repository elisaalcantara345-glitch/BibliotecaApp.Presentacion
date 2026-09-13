# Sistema de Gestión de Biblioteca 

Aplicación de escritorio desarrollada para la administración y automatización de catálogos bibliográficos, control de inventario en tiempo real, gestión de usuarios y registro de préstamos y devoluciones.


## Características Principales

* **Gestión de Catálogo (CRUD):** Control total de libros, vinculados dinámicamente con autores y categorías.  
* **Módulo de Préstamos y Devoluciones:** Validación en tiempo real de disponibilidad de stock, estados de préstamos y selección directa desde DataGridView.  
* **Gestión de Usuarios y Autores:** Registro detallado de miembros institucionales habilitados para el préstamo.  
* **Interfaz Intuitiva:** Interfaz gráfica responsiva e intuitiva construida sobre Windows Forms.

## Arquitectura del Sistema

El proyecto está diseñado bajo los principios de la **Programación Orientada a Objetos (POO)** utilizando una **Arquitectura en 4 Capas**:

* BibliotecaApp.Presentacion: Formularios e interfaces de usuario (WinForms).  
* BibliotecaApp.Negocio: Reglas de negocio, lógica de la aplicación y validaciones.  
* BibliotecaApp.Datos: Capa de acceso a datos y comunicación con SQL Server mediante ADO.NET.  
* BibliotecaApp.Entidades: Clases DTO que encapsulan los modelos del dominio (Autor, Libro, Usuario, Prestamo).

\[ Capa de Presentación (WinForms) \]  
                │  
                ▼  
\[ Capa de Negocio (Lógica / Validaciones) \] ──► \[ Capa de Entidades (DTOs) \]  
                │  
                ▼  
\[ Capa de Datos (ADO.NET / SQL) \]  
                │  
                ▼  
      \[ Microsoft SQL Server \]

##  Instalación y Configuración

### **Requisitos Previos**

* **Visual Studio 2019 / 2022** con la carga de trabajo de *Desarrollo de escritorio de .NET*.  
* **Microsoft SQL Server** (LocalDB, Express o superior).  
* **SQL Server Management Studio (SSMS)**.

### **Pasos para Ejecutar**

1. **Clonar el repositorio:**  
   git clone https://github.com/tu-usuario/sistema-gestion-biblioteca.git

2. **Configurar la Base de Datos:**  
   * Abre SQL Server Management Studio (SSMS).  
   * Ejecuta el script de creación de la base de datos ubicado en /database/script\_biblioteca.sql.  
3. **Configurar la Cadena de Conexión:**  
   * Abre la solución en Visual Studio.  
   * Modifica la cadena de conexión en el archivo Conexion.cs (dentro del proyecto BibliotecaApp.Datos):  
     string conexion \= "Server=TU\_SERVIDOR; Database=BibliotecaDB; Integrated Security=True;";

4. **Ejecutar la Aplicación:**  
   * Establece BibliotecaApp.Presentacion como el proyecto de inicio.  
   * Compila y ejecuta el proyecto presionando F5.

## **Autor**

* **Elisa Alcantara** \- *Desarrollo e Implementación* \

