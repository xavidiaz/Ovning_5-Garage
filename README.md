# Garage 0.1

A console application that simulates a garage management system — park vehicles, retrieve them, search by properties, and more. Built as part of the Lexicon Fullstack .NET & AI program (Övning 5).

## About

The application lets users manage a garage with a text-based UI. Vehicles of different types (cars, motorcycles, boats, airplanes, buses) can be parked, removed, listed, and searched using various property filters.

## Architecture

```
UI (ConsoleUI)
  └── GarageHandler
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

## Features

- List all parked vehicles
- List vehicle types with count
- Add / remove vehicles
- Seed garage with vehicles on startup
- Find vehicle by registration number (case-insensitive)
- Search by one or more `Vehicle` properties (color, wheels, type, etc.)
- User feedback on all actions (success / failure with reason)
- Robust input validation — no crashes on bad input

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
- [ ] Implement `IEnumerable<T>` (support `foreach`)
- [x] Internal storage as **private array** (⚠️ NOT `List<Vehicle>`)
- [x] Capacity set via constructor argument

### Interfaces

- [ ] Create `IUI`
- [ ] Create `IHandler`
- [x] Create `IVehicle`
- [x] Create `IGarage`
- [x] `GarageHandler` — abstraction layer between UI and Garage (stub)

### Functionality

- [x] List all parked vehicles
- [x] List vehicle types and count of each
- [x] Add vehicles to the garage
- [x] Remove vehicles from the garage
- [x] Seed garage with vehicles on startup
- [x] Find vehicle by registration number
- [ ] Search vehicles by one or more `Vehicle` properties
- [ ] User feedback on success / failure with reason

### Console UI

- [ ] Main menu with navigation to all functionality
- [ ] Create garage with user-specified size
- [ ] Quit application from menu
- [ ] Robust input validation — no crashes on bad input

### Unit Testing

- [ ] Create separate test project
- [ ] Test public methods of `Garage<T>`
- [ ] Follow Arrange → Act → Assert
- [ ] Naming: `MethodName_StateUnderTest_ExpectedBehavior`

### Extra (not required)

- [ ] Search by vehicle-specific properties
- [ ] Handle multiple garages (hangar, motorcycle garage, etc.) with UI navigation
- [ ] Parking spots that hold vehicles
- [ ] Save / load garage to / from file
- [ ] Vehicles take different space (car = 1, boat = 2, airplane = 3, motorcycle = 1/3)
- [ ] Only show vehicles that fit when parking
- [ ] Read garage size from configuration

## Known Issues / TODO

- **Null-hantering saknas** — GarageHandler-metoder kontrollerar inte om `Garage` är null innan anrop, kan krascha om `CreateGarage` inte anropats
- **Console.WriteLine i Garage** — bör flyttas till UI-lagret; Garage ska returnera data, inte skriva till konsolen
- **Access modifiers** — flera klasser och properties saknar `public` där det behövs
- **IGarage-interfacet** är inte implementerat av Garage-klassen ännu
- **IEnumerable<T>** inte implementerat på Garage ännu
- **Stavning** — `Motorcicle` bör vara `Motorcycle`
- **Registreringsnummer** — specen kräver string (case-insensitive), nuvarande implementation använder uint

## Getting Started

```bash
# clone
git clone https://github.com/xavidiaz/Ovning_5-Garage.git
cd Ovning_5-Garage

# run
dotnet run

# test
dotnet test
```

## Testing

Unit tests live in a separate test project and cover the public methods of `Garage<T>`.

Tests follow the **Arrange → Act → Assert** pattern with descriptive names:

```
MethodName_StateUnderTest_ExpectedBehavior
```

## Tech

- C# / .NET
- xUnit (testing)
- Console application
- Developed in Neovim + dotnet CLI on Arch Linux (Omarchy)

## License

MIT
