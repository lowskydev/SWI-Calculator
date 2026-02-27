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

// Process each operation
var results = new List<(string Name, double Result)>();
foreach (var entry in doc.RootElement.EnumerateObject())
{
    string objName = entry.Name;
    JsonElement obj = entry.Value;

    // Read operator
    if (!obj.TryGetProperty("operator", out JsonElement operatorElement))
    {
        Console.WriteLine($"Warning: {objName} has no 'operator' field (skip)");
        continue;
    }

    string op = operatorElement.GetString() ?? "";

    // Read value1
    if (!obj.TryGetProperty("value1", out JsonElement value1Element))
    {
        Console.WriteLine($"Warning: {objName} has no 'value1' field (skip)");
        continue;
    }

    double value1 = value1Element.GetDouble();

    // value2 is optional
    double value2 = 0;
    if (obj.TryGetProperty("value2", out JsonElement value2Element))
    {
        value2 = value2Element.GetDouble();
    }

    // Perform the calculation
    double result;
    try
    {
        result = op switch
        {
            "add" => value1 + value2,
            "sub" => value1 - value2,
            "mul" => value1 * value2,
            "sqrt" => Math.Sqrt(value1),
            _ => throw new InvalidOperationException($"Error: Unknown operator: {op}")
        };
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Warning: {ex.Message} in {objName} (skip)");
        continue;
    }

    results.Add((objName, result));
}

