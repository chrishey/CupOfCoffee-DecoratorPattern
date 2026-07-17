# CupOfCoffee-DecoratorPattern

A C# educational project demonstrating the **Decorator design pattern** through a practical example of making coffee or tea. The program accepts command-line arguments to specify a beverage and optional extras, then chains together decorator objects that each print out a step in the preparation process.

## How the Code Works

### The Decorator Pattern

The Decorator pattern allows you to add behavior to objects dynamically by wrapping them in decorator objects. Each decorator:
1. Implements the `IStep` interface with a `Do()` method
2. Wraps the next step in the chain
3. Performs its own action, then calls the wrapped step's `Do()` method

This creates a chain where calling the outermost `Do()` cascades through all decorated steps.

### Core Architecture

#### IStep Interface
The contract all steps must follow:
```c#
public interface IStep
{
    void Do();
}
```

#### BrewUp Base Class
Holds an `IStep` and invokes it:
```c#
public class BrewUp
{
    private readonly IStep _step;
    
    public void CuppaFather()
    {
        _step.Do();  // Executes the entire chain
    }
}
```

#### Fixed Steps (in Steps directory)
Each implements `IStep` and wraps the next step:
- `FillKettle` → prints "Fill the Kettle"
- `BoilKettle` → prints "Boil the Kettle"
- `AddCoffeeToCup` → prints "Add Coffee to Cup"
- `AddTeaBag` → prints "Add Tea Bag"

Example:
```c#
public class FillKettle : IStep
{
    private readonly IStep _step;
    
    public FillKettle(IStep step) { _step = step; }
    
    public void Do()
    {
        Console.WriteLine("Fill the Kettle");
        if (_step != null) _step.Do();
    }
}
```

#### Coffee Class
Builds a fixed decorator chain for coffee:
```c#
public class Coffee : BrewUp
{
    public Coffee() : base(new FillKettle(
        new BoilKettle(
            new AddCoffeeToCup(null))))
    {
    }
}
```

#### Tea Class
Builds a fixed decorator chain for tea, then adds optional extras:
```c#
public class Tea : BrewUp
{
    private readonly Extra[] _extras;
    
    public Tea(Extra[] extras) : base(new FillKettle(
        new BoilKettle(
            new AddTeaBag(null))))
    {
        _extras = extras;
    }
    
    public new void CuppaFather()
    {
        base.CuppaFather();  // Run fixed chain first
        
        foreach (var extra in _extras)
        {
            var step = extra as IStep;
            if (step != null) step.Do();  // Run each extra
        }
    }
}
```

#### Extra Classes (in Steps/Extras directory)
Optional additions that inherit from `Extra` and implement `IStep`:
- `Sugar` → extends `Extra` to store quantity, implements `IStep` to be chainable
- `Sweetener` → same pattern
- `Milk` → same pattern

Example:
```c#
public class Sugar : Extra, IStep
{
    private readonly IStep _step;
    
    public Sugar(IStep step, int quantity) : base(quantity)
    {
        _step = step;
    }
    
    public void Do()
    {
        Console.WriteLine($"Add {Quantity} spoons of sugar");
        if (_step != null) _step.Do();
    }
}
```

#### Dynamic Discovery
`Program.cs` uses **reflection** to automatically discover and instantiate extras:
1. Scans all types that inherit from `Extra`
2. Matches command-line argument names to class names (case-insensitive)
3. Uses `Activator.CreateInstance()` to create instances with the quantity

This means **adding a new extra is as simple as creating a new class** — no changes to `Program.cs` needed!

## Usage Examples

### Making Coffee

```bash
# Just coffee
Make.Coffee.exe coffee

# Coffee with milk
Make.Coffee.exe coffee milk:1

# Coffee with milk and sugar
Make.Coffee.exe coffee milk:1 sugar:2
```

Output:
```
Fill the Kettle
Boil the Kettle
Add Coffee to Cup
Add 1 units of milk
Add 2 spoons of sugar
```

### Making Tea

```bash
# Just tea
Make.Coffee.exe tea

# Tea with milk
Make.Coffee.exe tea milk:1

# Tea with multiple extras
Make.Coffee.exe tea milk:2 sugar:1 sweetener:2
```

Output:
```
Fill the Kettle
Boil the Kettle
Add Tea Bag
Add 2 units of milk
Add 1 spoons of sugar
Add 2 sweetener
```

### No Arguments

```bash
Make.Coffee.exe
```

Output:
```
Sorry, we couldn't find your beverage
```

## File Organization

```
src/Make.Coffee/
  BrewUp.cs              Base class holding an IStep
  Coffee.cs              Coffee beverage (fixed chain)
  Tea.cs                 Tea beverage (fixed chain + extras)
  Extra.cs               Base class for optional extras
  Program.cs             Entry point; CLI parsing & reflection
  
  Steps/
    IStep.cs             Interface for the decorator chain
    FillKettle.cs        Decorator step
    BoilKettle.cs        Decorator step
    AddCoffeeToCup.cs    Decorator step
    AddTeaBag.cs         Decorator step
    
    Extras/
      Sugar.cs           Optional extra
      Sweetener.cs       Optional extra
      Milk.cs            Optional extra
```

## Key Design Benefits

1. **Separation of Concerns** — Fixed steps (coffee/tea) are distinct from optional extras
2. **Extensibility** — Add new extras by just creating a new class inheriting from `Extra` and implementing `IStep`
3. **Clarity** — The decorator chain visually represents the order of operations
4. **Flexibility** — Extras can be combined in any way at runtime without code changes
5. **Reflection-Based Discovery** — No hardcoding of extra types in the main program

## Adding a New Extra

To add a new extra (e.g., Honey):

1. Create `src/Make.Coffee/Steps/Extras/Honey.cs`:
```c#
using System;

namespace Make.Coffee.Steps.Extras
{
    public class Honey : Extra, IStep
    {
        private readonly IStep _step;

        public Honey(IStep step, int quantity) : base(quantity)
        {
            _step = step;
        }

        public void Do()
        {
            Console.WriteLine($"Add {Quantity} spoons of honey");
            if (_step != null) _step.Do();
        }
    }
}
```

2. Use it immediately:
```bash
Make.Coffee.exe tea honey:1 milk:2
```

No other changes needed — the reflection automatically discovers it!
