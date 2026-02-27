Calculator - SWI Task
Author: Wiktor Szydłowski

Description:
  Reads input.json from the same directory as the .exe.
  Performs mathematical operations and writes results 
  sorted ascending to output.txt.

Usage:
  Windows:  swi.exe
  Linux:    ./swi

Input format (input.json):
  {
    "obj1": { "operator": "mul", "value1": 5, "value2": 8 },
    "obj2": { "operator": "sqrt", "value1": 12345654321 }
  }

Output format (output.txt):
  obj2: 40
  obj1: 11111

Supported operators:
  add  - addition (value1 + value2)
  sub  - subtraction (value1 - value2)
  mul  - multiplication (value1 * value2)
  sqrt - square root (value1 only, value2 not required)

Built with .NET 6, self-contained (no runtime installation required).
Source code available in the source/ subfolder.

Building from source:
  Requirements: .NET 6 SDK

  Windows:
    dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true

  Linux:
    dotnet publish -c Release -r linux-x64 --self-contained -p:PublishSingleFile=true

  Output will be in bin/Release/net6.0/{platform}/publish/
