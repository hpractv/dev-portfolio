# Interfaces
Interfaces are used to create a contract that a class needs to implement.  many interfaces specified and they can inherit from parent interfaces.

**Inhertiance Example 1**
```c
public interface IAnimal
{
    public string name { get; set; }    
}

public interface IMammal : IAnimal
{
    public int legCount { get; set;}
    public int armCount { get; set; }
    public bool fur { get; set; }
}

public interface IPrimate : IMammal
{
    public bool tail { get; set; }    
}

public class Monkey : IPrimate
{
    public Monkey()
    {
        this.tail = true;
        this.legCount = 2;
        this.armCount = 2;
        this.fur = true;
        this.name = "Monkey";
    }

    public bool tail { get; set; }    

    public int legCount { get; set;}
    public int armCount { get; set; }
    public bool fur { get; set; }

    public string name { get; set; }    
}
```

In example 1 the inheritance for monkey flows through the `IPrimate` interface.  And any sort of casting or type conversion can made through that line.  Meaning `Monkey` can be cast to an `IPrimate` or `IAnimal` interface depending on what interface a method or consuming class is expecting.  A class `Zoo` could use the `IAnimal` interface for counting the number of animals they have and listing out the names of their animals.   A class of `Exhibit` could break out the animals that are of `IPrimate` and organize them by characteristics like whether or not they have prehensile tails.

**Inhertiance Example 1**
```c
public interface IFish : IAnimal
{
    public bool sport { get; set; }
    public bool freshwater { get; set; }
}


public class SeaBass : IFish 
{
    public SeaBass()
    {
        this.tail = true;
        this.freshwater = false;
        this.name = "SeaBass";
    }

    public bool tail { get; set; }
    public bool freshwater { get; set; }

    public string name { get; set; }
}

```

In example 2 `IFish` still inherit from the `IAnimal` interface, but thne diverges to add contract characteristics more relevant to a fish.  This way an `Aquarium` could use the `IFish` interface to determine whether or not a fish goes in the seawater tank or not.