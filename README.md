# OPSAVER

**Información y transparencia para una atención médica más segura.**

## ¿Qué es OPSAVER?

OPSAVER nace de la preocupación por los riesgos que enfrentan los pacientes al elegir un profesional de salud sin contar con información suficiente para evaluar su preparación, experiencia y reputación.

En República Dominicana, la desinformación y la dificultad para comprobar las credenciales de algunos profesionales pueden dejar a las personas en una situación vulnerable al momento de tomar decisiones relacionadas con su salud.

OPSAVER busca contribuir a cambiar esa realidad mediante una plataforma que reúna información profesional, centros médicos y experiencias de pacientes, facilitando decisiones más informadas.

## Propósito

Contribuir a la protección del paciente mediante la transparencia, el acceso a información y la participación de todos los involucrados en la atención médica.

## Visión

Convertirse en una plataforma de referencia para consultar información sobre profesionales y centros de salud, conocer experiencias de otros pacientes y disponer de herramientas que ayuden a identificar posibles irregularidades.

## Participantes

- **Pacientes:** consultan información y comparten sus experiencias.
- **Médicos:** presentan y mantienen actualizada su información profesional.
- **Clínicas:** ofrecen información sobre sus centros y los profesionales vinculados.
- **OPSAVER:** administra la plataforma y busca promover la confiabilidad de la información publicada.

## Funcionalidades actuales

- Gestión de médicos.
- Gestión de clínicas.
- Gestión de pacientes.
- Gestión de reseñas.
- Moderación de reseñas.

## Tecnologías

- C# y ASP.NET Core MVC
- .NET 10
- Entity Framework Core
- SQL Server
- Bootstrap
- Git y GitHub

## Instalación y ejecución

### 1. Obtener el proyecto

Clonar el repositorio desde GitHub:

```bash
git clone https://github.com/DarvinMendez/opsaver.git
```

Abrir la solución `opsaver.sln` desde Visual Studio.

### 2. Base de datos

En SQL Server Management Studio (SSMS), ejecutar los scripts de `Database/Scripts` en orden, comenzando por `01_CreateDatabase.sql`.

Verificar que SQL Server tenga habilitado el modo de autenticación de SQL Server y Windows.

Para crear el inicio de sesión de la aplicación, reemplazar `REEMPLAZAR_LOCALMENTE` en `02_CreateLogin.sql` por una contraseña propia. Ejecutar los scripts con permisos de administrador.

### 3. Conexión

Crear `appsettings.Local.json` en la raíz del proyecto y configurar la conexión a SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=OPSAVER;User Id=opsaver_app;Password=TU_CONTRASEÑA;Encrypt=True;TrustServerCertificate=True;"
  }
}
```

Sustituir `TU_CONTRASEÑA` por la contraseña configurada anteriormente.

### 4. Ejecución

Abrir `opsaver.sln` en Visual Studio, seleccionar `opsaver` como proyecto de inicio y pulsar F5.