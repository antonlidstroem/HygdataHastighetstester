HYG Data Speed Tester (EF Core Performance)
A C# console application designed to benchmark and compare different Entity Framework Core query patterns. The project uses the HYG Database (v3)—a comprehensive dataset of stars—to measure how query ordering (OrderBy, Select, and ToList) affects execution time and memory efficiency.

Purpose
The goal of this project is to demonstrate the difference between Server-side evaluation (SQL) and Client-side evaluation (In-memory) when fetching data. It tests 5 different approaches to retrieving and sorting star data to find the most "performant" LINQ pattern.

Features
 * Database Integration: Uses EF Core with SQL Server (LocalDB).
 * Performance Benchmarking: Utilizes System.Diagnostics.Stopwatch for millisecond-precision timing.
 * Automated Results: Compares results and automatically declares a "Winner" based on execution speed.

The Performance Tests (Attempts)
The application executes five distinct logic paths to fetch and sort data:

| Attempt | Strategy | Logic |
|---|---|---|
| 1 | Hybrid / In-memory | Fetches the entire table to memory, then performs a second fetch for sorted projection. |
| 2 | SQL Sort + Memory Select | Asks the DB to sort all columns, then projects columns in memory. |
| 3 | SQL Select + Memory Sort | Asks the DB for specific columns, then sorts them in memory. |
| 4 | Full SQL Optimization | Asks the DB to Sort and Project (Select) before sending data over the network. |
| 5 | SQL Selection Priority | Similar to Attempt 4, but swaps the LINQ method order (Select then OrderBy). |

Prerequisites
 * .NET 6.0 SDK (or newer)
 * SQL Server Express / LocalDB
 * Entity Framework Core
   
Database Setup
The application is currently configured to look for a specific .mdf file:
C:\Users\anton\Hygdata.mdf
> [!WARNING]
> Connection String: Before running the app, update the connection string in HygdataContext.cs within the OnConfiguring method to match your local path or SQL Server instance.
> 
How to Run
 * Clone the repository.
 * Ensure the Hygdata.mdf file is attached to your LocalDB instance or update the connection string.
 * Open a terminal in the project folder.
 * Run the application:
   dotnet run

Results
The program will output the time taken for each attempt in milliseconds and display a winner:
FÖRSÖK 4:
    Steg 1: Tabellen hämtas sorterad efter Lum och sedan väljs kolumnerna.
    Resultat: 142 ms

VINNARE: FÖRSÖK 4 med tiden 142 ms

Project Structure
 * HygdataContext.cs: The EF Core Database Context and Model configurations.
 * HygdataV3.cs: The model representing the star data (ID, Magnitude, Distance, etc.).
 * User.cs / UserStar.cs: Support for user-specific favorite star tracking.
 * Program.cs: The main entry point containing the benchmark logic.
