# Interfaces
Interfaces are used to force a class to implement a specific set of methods or properties. Many interfaces can be specified on a class, and interfaces can inherit from base interfaces.

Interfaces differ from `abstract` classes in that none of the methods or properties are implemented by parent class definitions and a class may take on the characteristics of many different interfaces.




**Inheritance Example 1**
```c
public interface IAnimal
{
    string name { get; set; }    
}

public interface IMammal : IAnimal
{
    int legCount { get; set;}
    int armCount { get; set; }
    bool fur { get; set; }
}

public interface IPrimate : IMammal
{
    bool tail { get; set; }    
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

**Inheritance Example 2**
```c
public enum huntingImplement { none, rod, bow, gun, trap, spear };

public interface IFish : IAnimal
{
    bool freshwater { get; set; }
}

public interface ISport : IAnimal
{
    IEnumerable<huntingImplement> huntedWith { get; set; }
}

public class SeaBass : IFish, ISport 
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

    public IEnumerable<huntingImplement> huntedWith { get; set; }
}

```

In example 2, `IFish` still inherits from the `IAnimal` interface, but then diverges to add contract characteristics more relevant to a fish.  This way an `Aquarium` could use the `IFish` interface to determine whether or not a fish goes in the seawater tank or not.  `SeaBass` additionally implements the interface `ISport`.  This allows us to specify more contractual extension, but don't necessarily run through inheritance the animal interface.

## Explicit Implementation

Additionally, interface components can be implemented implicitly or explicitly.  To implement implicitly allows the contract method or property to be accessed natively through the class's methods or fields.  When implementing explicitly, the contract method or property can <em>only</em> be accessed on the class when it is casted to the explicitly implemented interface.

**Inheritance Example 3**
```c
public class SeaBass : IFish, ISport 
{
    public SeaBass()
    {
        this.tail = true;
        this.freshwater = false;
        this.name = "SeaBass";
    }

    //Implicit interface implementation
    public bool tail { get; set; }
    public bool freshwater { get; set; }
    public string IAnimal name { get; set; }

    //Explicit interface implementation
    IEnumerable<huntingImplement> ISport.huntedWith { get; set; }
}
```

Based on the class definitions in Example 3, all the properties of `SeaBass` can be accessed without a cast to the original interfaces except for `huntedWith`.  It can only be used if when an instantiated object is cast back to `ISport`:

```c
var sbo = new SeaBass();
sob.freshWater = false;
((ISport)sbo).huntedWith = huntingImplement.Spear;
```


## Follow-up Questions
_What is the Interface Segregation Principle?_

Interface Segregation is the idea that an interface's contract should only contain the minimum method an property definitions that are necessary to accomplish the consuming application's task.  Any extra definitions that don't directly apply to the consumer application workflow should be removed or moved to a more appropriate interface declaration.

_What purpose does explicit implementation fill?_

Explicit implementation allows for a specific set of interface activities to be defined and only utilized through the proper interface reference path.  For instance, an `IPersonalMortgage` interface may have a `CalculateInterest` method that uses specific parameters on basic a amortization formula.  Where an `ICommercialMortgage` interface should have a lower associated interest rate compounded at different intervals in its `CalculateInterest` method.  Both are available in a `Mortgage` class, but have the same polymorphism.

When instantiating and using the `Mortgage` class, the consuming application is forced to use the proper interface in order to call the appropriate `CalculateInterest` method.  This keeps the resulting interfaces lean, but provides very a delineated means of calling the appropriate version of the interest method.

I've included an example below mostly becuase it was actually fun to build the proof-of-concept.

```c
public interface IPersonalMortgage
{
	double compounds { get; }
	double CalculateInterest(double principle, double periods);
}

public interface ICommercialMortgage
{
	double compounds { get; }
	double CalculateInterest(double principle, double periods);
}

public class Mortgage : IPersonalMortgage, ICommercialMortgage
{
	public double PersonalInterestRate { get; }
	public double CommercialInterestRate { get; }

	double IPersonalMortgage.compounds { get; } = 12.0;
	double ICommercialMortgage.compounds { get; } = 4.0;
		

	public Mortgage(double personalInterestRate, double commercialInterestRate)  {
		this.PersonalInterestRate = personalInterestRate;
		this.CommercialInterestRate = commercialInterestRate;		
	}
		
	
	double IPersonalMortgage.CalculateInterest(double principle, double periods)
		=> calculateInterest(
			principle,
			PersonalInterestRate,
			periods,
			((IPersonalMortgage)this).compounds);

	double ICommercialMortgage.CalculateInterest(double principle, double periods)
		=> calculateInterest(
			principle,
			CommercialInterestRate,
			periods,
			((ICommercialMortgage)this).compounds);

	private double calculateInterest(double principle, double interest, double periods, double compounds)
		=> principle * Math.Pow(1 + (interest/compounds), compounds * periods) - principle;
}

void Main()
{

	var instance = new Mortgage(0.052, 0.043);
	var principle = 150_000;
	var years = 15;

	Console.WriteLine(
		$"Total Personal Interest: {((IPersonalMortgage)instance).CalculateInterest(principle, years): $###,###,###,##0.00}"
	);

	Console.WriteLine(
		$"Total Commercial Interest: {((ICommercialMortgage)instance).CalculateInterest(principle, years): $###,###,###,##0.00}"
	);


}

//OUTPUT:
//Total Personal Interest:  $176,669.89
//Total Commercial Interest:  $134,915.62
```