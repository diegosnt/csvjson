# Convertidor de CSV a JSON

`csvjson` es una sencilla herramienta de línea de comandos desarrollada en C# para convertir archivos desde el formato CSV (Valores Separados por Comas) al formato JSON.

Utiliza la biblioteca `CsvHelper` para un análisis robusto de CSV y `System.Text.Json` para una serialización eficiente a JSON.

## Requisitos

- .NET 8 SDK o una versión posterior.

## Cómo se utiliza

Sigue estos pasos para ejecutar el programa.

### 1. Preparar el entorno

Abre tu terminal, navega al directorio del proyecto y restaura las dependencias (esto descargará `CsvHelper`).

```bash
cd /ruta/del/proyecto/csvjson
dotnet restore
```

### 2. Ejecutar la conversión

Utiliza el comando `dotnet run` seguido de dos argumentos:
1.  La ruta al archivo de entrada `.csv`.
2.  La ruta donde se guardará el archivo de salida `.json`.

La sintaxis es la siguiente:

```bash
dotnet run -- <archivo_entrada.csv> <archivo_salida.json>
```

## Ejemplo práctico

Supongamos que tienes un archivo llamado `data.csv` con el siguiente contenido:

```csv
Name,Age,City
Alice,30,New York
Bob,25,Paris
Charlie,35,London
```

Para convertirlo, ejecuta este comando:

```bash
dotnet run -- data.csv output.json
```

El programa generará un archivo `output.json` con el contenido perfectamente formateado:

```json
[
  {
    "Name": "Alice",
    "Age": "30",
    "City": "New York"
  },
  {
    "Name": "Bob",
    "Age": "25",
    "City": "Paris"
  },
  {
    "Name": "Charlie",
    "Age": "35",
    "City": "London"
  }
]
```

## Manejo de errores

- Si no se proporcionan los dos argumentos (entrada y salida), el programa mostrará un mensaje de ayuda.
- Si el archivo de entrada no se encuentra, se notificará un error y el programa se detendrá.
