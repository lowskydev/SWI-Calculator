using System.Text.Json;

// Find and read input.json
string exeDirectory = AppContext.BaseDirectory;
string inputPath = Path.Combine(exeDirectory, "input.json");
string outputPath = Path.Combine(exeDirectory, "output.txt");

if (!File.Exists(inputPath))
{
    Console.WriteLine($"Error: input.json not found at {inputPath}");
    return;
}

string jsonContent = File.ReadAllText(inputPath);

// Parse JSON
JsonDocument doc;
try
{
    doc = JsonDocument.Parse(jsonContent);
}
catch (JsonException ex)
{
    Console.WriteLine($"Error: could not parse input.json: {ex.Message}");
    return;
}


