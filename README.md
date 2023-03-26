# aspnetcore-template

An open source aspnetcore template.

## Architecture

- `Template.Api`: used to start the application. It contains all modules and configurations used to configure the app.

- `Template.Common`: used to store all common and utils code.

- `Template.Dto`: this store data transfer objects and (aka Dto).

- `Template.Entities`: a low level models used with storing system such as database or file storage.

### Modules

This template uses modules and IModule interface to expose api.
An example is provided in the `WeatherForecastModule` module.

### Serilog

This template uses serilog Console and File to log information.

### Json Serializers

This template automatically converts enum to string and string to enum from Dto.

### Api explorer

This template use Swagger to explore api endpoints.

### Cors loader

This template load automatically CORS options from `appsettings.json` file.
