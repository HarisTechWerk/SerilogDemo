# SerilogDemo

A demo project showcasing **structured logging** with [Serilog](https://serilog.net/) in **.NET 8**. This project demonstrates how to:

- Configure Serilog from scratch
- Log to the console and rolling files
- Inject `ILogger<T>` into classes or controllers
- (Optionally) handle exceptions automatically via middleware

## Overview

SerilogDemo is a simple ASP.NET Core (or Console) application designed to teach best practices for **structured logging** in .NET.  
By using **Serilog**, you gain powerful logging capabilities—like improved log formatting, multiple log outputs (sinks), and easier debugging in production scenarios.

## Features

1. **Console Logging** - Displays log messages in the terminal with structured output.
2. **File Logging** - Writes rolling log files to the `Logs` folder (one file per day).
3. **ILogger Injection** - Demonstrates how to inject and use `ILogger<T>` in services or controllers.
4. **Exception Handling** - An optional middleware route (e.g., `/error`) that throws an exception, automatically logged by Serilog.
