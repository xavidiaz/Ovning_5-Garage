# Garage 0.1

A console application that simulates a garage management system — park vehicles, retrieve them, search by properties, and more. Built as part of the Lexicon Fullstack .NET & AI program (Övning 5).

## About

The application lets users manage a garage with a text-based UI. Vehicles of different types (cars, motorcycles, boats, airplanes, buses) can be parked, removed, listed, and searched using various property filters.

## Architecture

```
Ovning_5-Garage/
├── Ovning_5-Garage/          ← main project
│   ├── Program.cs
│   ├── Vehicle.cs, Car.cs, Motorcycle.cs
│   ├── Garage.cs
│   ├── Handler.cs
│   ├── ConsoleUI.cs
│   └── IVehicle.cs
└── Ovning_5-Garage.Tests/    ← test project (xUnit v3)
    └── GarageTest.cs
```

```
UI (ConsoleUI)
  └── Handler
        └── Garage<T>
              └── Vehicle (abstract)
                    ├── Car
                    ├── Motorcycle
                    ├── Airplane
                    ├── Bus
                    └── Boat
```

Interfaces (`IUI`, `IHandler`, `IVehicle`) decouple the layers so the UI never talks directly to the `Garage` class.

## Key Design Decisions

- `Garage<T>` is a generic collection with a type constraint, backed by a **private array** (not `List<T>`)
- Implements `IEnumerable<T>` for `foreach` support
- Capacity is set at instantiation via the constructor
- Registration numbers are unique and searched case-insensitively

## Progress

### Architecture & Classes

- [x] Create `Vehicle` class with shared properties (registration number, color, wheels, etc.)
- [ ] Registration number is unique
- [ ] Create subclass `Airplane` with own property (e.g. Number of Engines)
- [x] Create subclass `Motorcycle` with own property (e.g. Handlebar width)
- [x] Create subclass `Car` with own property (e.g. Number of doors)
- [ ] Create subclass `Bus` with own property (e.g. Number of seats)
- [ ] Create subclass `Boat` with own property (e.g. Length)

### Garage Class

- [x] Implement `Garage<T>` as generic class
- [x] Add generic constraint (`where T : ...`)
- [x] Implement `IEnumerable<T>` (support `foreach`)
- [x] Internal storage as **private array** (⚠️ NOT `List<Vehicle>`)
- [x] Capacity set via constructor argument

### Interfaces

- [ ] Create `IUI`
- [ ] Create `IHandler`
- [x] Create `IVehicle`
- [ ] Create `IGarage`
- [x] `Handler` — abstraction layer between UI and Garage

### Functionality

- [x] List all parked vehicles (via `IEnumerable<T>`)
- [x] List vehicle types and count of each (`VehicleTypes` property)
- [x] Add vehicles to the garage (`ParkVehicle`)
- [x] Remove vehicles from the garage (`UnparkVehicle`)
- [x] Seed garage with vehicles on startup
- [x] Find vehicle by registration number (case-insensitive)
- [x] Search vehicles by one or more `Vehicle` properties (`SearchVehicles` with `Func<T, bool>`)
- [ ] User feedback on success / failure with reason

### Console UI

- [x] Main menu with navigation to all functionality
- [x] Create garage with user-specified size
- [x] Quit application from menu
- [x] Robust input validation — no crashes on bad input (generic `ReadInput<T>`)

### Unit Testing

- [x] Create separate test project (xUnit v3)
- [x] Test public methods of `Garage<T>` (started)
- [x] Follow Arrange → Act → Assert
- [x] Naming: `MethodName_StateUnderTest_ExpectedBehavior`

### Extra (not required)

- [ ] Search by vehicle-specific properties
- [ ] Handle multiple garages (hangar, motorcycle garage, etc.) with UI navigation
- [ ] Parking spots that hold vehicles
- [ ] Save / load garage to / from file
- [ ] Vehicles take different space (car = 1, boat = 2, airplane = 3, motorcycle = 1/3)
- [ ] Only show vehicles that fit when parking
- [ ] Read garage size from configuration

## Known Issues / TODO

- **ConsoleUI** — saknar constructor som tar Handler
- **Program.Main** — skapar garage direkt istället för via Handler/UI
- **Handler null-checks** — flera metoder saknar null-check på `_garage`
- **Handler.SeedGarage** — null-check gör inget
- **SearchVehicles val 1 & 2** — `ReadInput` anropas i filtret, bör läsas innan
- **Console.WriteLine i Garage** — bör flyttas till UI-lagret
- **IVehicle** — saknar `Color` och `NumerOfWheels`, behövs för sökning via generisk `T`
- **Airplane, Bus, Boat** — ej implementerade
- **Registreringsnummer unikhet** — ingen kontroll vid parkering
- **Stavning** — `NumerOfWheels` bör vara `NumberOfWheels`
- **Fler tester behövs** — UnparkVehicle, FindVehicle, IsFull, SearchVehicles

## Getting Started

```bash
# clone
git clone https://github.com/xavidiaz/Ovning_5-Garage.git
cd Ovning_5-Garage

# run
cd Ovning_5-Garage
dotnet run

# test
cd Ovning_5-Garage.Tests
dotnet test
```

## Testing

Unit tests use **xUnit v3** and live in a separate test project. Tests cover the public methods of `Garage<T>`.

Tests follow the **Arrange → Act → Assert** pattern with descriptive names:

```
MethodName_StateUnderTest_ExpectedBehavior
```

## Tech

- C# / .NET 10
- xUnit v3 (testing)
- Console application
- Developed in Neovim + dotnet CLI on Arch Linux (Omarchy)

## License

MIT
