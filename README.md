# Aplicación de Gestión de Pilotos y Equipos

Esta aplicación está desarrollada en .NET y tiene como objetivo gestionar información sobre pilotos y equipos en una competencia de automovilismo. La aplicación permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre los pilotos y equipos a través de una API RESTful.

## Objetivos

Esta aplicación tiene como objetivo proporcionar una herramienta para la gestión de pilotos y equipos en la Formula 1. A continuación, se detallan los objetivos específicos que se buscan alcanzar con el desarrollo de esta aplicación:

1. **Facilitar la Gestión de Datos**: Proporcionar una interfaz intuitiva y una API potente para gestionar la información de pilotos y equipos de manera sencilla y eficiente.
2. **Operaciones CRUD Completas**: Implementar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) completas para permitir una administración integral de los pilotos y equipos.
3. **Consultas y Filtros Avanzados**: Permitir la realización de consultas avanzadas y la aplicación de filtros específicos para obtener información relevante de pilotos y equipos.
4. **Estadísticas Detalladas**: Proveer estadísticas detalladas y precisas sobre el rendimiento de los pilotos, incluyendo puntos, posiciones, victorias y más.
5. **Integración Sencilla**: Facilitar la integración con otros sistemas y aplicaciones mediante una API RESTful bien documentada y estandarizada.
6. **Escalabilidad y Mantenibilidad**: Desarrollar la aplicación con una arquitectura que permita la fácil escalabilidad y mantenibilidad del sistema.
7. **Seguridad y Control de Acceso**: Implementar mecanismos de seguridad y control de acceso para proteger los datos sensibles de los pilotos y equipos.
8. **Optimización del Rendimiento**: Garantizar un alto rendimiento en la respuesta de la API para manejar grandes volúmenes de datos sin comprometer la velocidad.
9. **Mejora Continua**: Establecer un proceso de mejora continua basado en feedback de usuarios y desarrolladores, asegurando la evolución constante de la aplicación.

## Características

- **Gestión de Pilotos**: Añadir, actualizar, obtener y eliminar información sobre los pilotos.
- **Gestión de Equipos**: Añadir, actualizar, obtener y eliminar información sobre los equipos.
- **Consultas Filtradas**: Obtener pilotos según filtros específicos.
- **Estadísticas de Pilotos**: Consultar estadísticas detalladas de pilotos por nombre.

## Estructura del Proyecto

### Controllers

#### PilotController

- `AddPilot(AddPilotDto pilotDto)`: Añade un nuevo piloto a la base de datos.
- `UpdatePilot(UpdatePilotDto pilot, int pilotId)`: Actualiza la información de un piloto existente.
- `GetAllPilots(FilterPilotDto filter)`: Obtiene una lista de todos los pilotos, con la opción de aplicar filtros.
- `GetPilotById(int pilotId)`: Obtiene la información de un piloto por su ID.
- `DeletePilot(int pilotId)`: Elimina un piloto por su ID.
- `GetPilotStats(string pilotName)`: Obtiene las estadísticas de un piloto por su nombre.

#### TeamController

- `AddTeam([FromForm] AddTeamDto teamDto)`: Añade un nuevo equipo a la base de datos.
- `UpdateTeam(int teamId, AddTeamDto teamDto)`: Actualiza la información de un equipo existente.
- `GetTeam(int teamId)`: Obtiene la información de un equipo por su ID.
- `DeleteTeam(int teamId)`: Elimina un equipo por su ID.

### Services

- **iPilotService**: Interface que define los métodos para la lógica de negocios relacionada con los pilotos.
- **iTeamService**: Interface que define los métodos para la lógica de negocios relacionada con los equipos.

## Tecnologías Utilizadas

- **.NET Core**: Framework principal para el desarrollo de la aplicación.
- **Entity Framework Core**: ORM para manejar la base de datos.
- **AutoMapper**: Librería para mapear entre objetos de dominio y DTOs.
- **ASP.NET Core MVC**: Para construir la API RESTful.

