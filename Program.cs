
using System.Globalization;
using System.Text.Json;
using CsvHelper;

if (args.Length != 2)
{
    Console.WriteLine("Uso: dotnet run -- <archivo_entrada.csv> <archivo_salida.json>");
    return 1;
}

string inputFile = args[0];
string outputFile = args[1];

if (!File.Exists(inputFile))
{
    Console.WriteLine($"Error: El archivo de entrada no fue encontrado en '{inputFile}'");
    return 1;
}

try
{
    using var reader = new StreamReader(inputFile);
    using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

    var records = csv.GetRecords<dynamic>().ToList();

    var options = new JsonSerializerOptions { WriteIndented = true };
    string json = JsonSerializer.Serialize(records, options);

    await File.WriteAllTextAsync(outputFile, json);

    Console.WriteLine($"¡Éxito! El archivo '{inputFile}' ha sido convertido a '{outputFile}'.");
    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"Ocurrió un error durante la conversión: {ex.Message}");
    return 1;
}
