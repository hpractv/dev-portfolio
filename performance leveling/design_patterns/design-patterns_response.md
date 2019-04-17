# Patterns<!-- omit in toc -->

Research the following design patterns and be comfortable speaking about things like:

  1. ***When to use the pattern? When not to?***
  1. ***How to migrate code to and from this pattern?***
  1. ***What are the tradeoffs of using the pattern (strengths and weaknesses)?***
  1. ***Where have you seen this pattern used/abused in our systems?***
  1. ***What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Index<!-- omit in toc -->

- [Singleton](#singleton)
- [Abstract Factory](#abstract-factory)
- [Factory Method](#factory-method)
- [Facade](#facade)
- [Adapter](#adapter)
- [Proxy](#proxy)
- [Visitor](#visitor)
- [Iterator](#iterator)
- [Observer](#observer)
- [Command](#command)
- [Strategy](#strategy)
- [Prototype](#prototype)
- [Decorator](#decorator)
- [Chain of Responsibility](#chain-of-responsibility)
- [Circuit Breaker](#circuit-breaker)

---

## Singleton

[TOP](#-patterns)

> A single static version of a object is always returned on instantiation request and is persisted through the lifetime of the application.

[![Singleton](https://www.dofactory.com/images/diagrams/net/singleton.gif)](https://www.dofactory.com/net/singleton-design-pattern)

```c
void Main()
{
var single = singleton.getSingleton();
single.message.Dump();

var single2 = singleton.getSingleton();
single2.message.Dump();

/* Expected Output
Hello World! 9/27/2018 11:22:08 AM
Hello World! 9/27/2018 11:22:08 AM
*/
}

public class singleton
{
    private static singleton _singleton = new singleton();

    static singleton() { _built = DateTime.Now; }
    private singleton() { }

    public static singleton getSingleton() => _singleton;

    static DateTime _built { get; }
    public DateTime built => _built;
    public string message => $"Hello World! {_built}";
}
```

***1. When to use the pattern? When not to?***
  
Useful for when a single instantiation is needed across the operational lifetime of the program.  Something like a logger or email submission object.  It is not beneficial when there are number of instantiations needed or centralized access to the objects methods/properties isn't necessary.

***2. How to migrate code to and from this pattern?***

First find where the constructor is being accessed and look at each use case.  If they can operate independently or have no need of a centralized version, then a regular class instantiation can be substituted for the construction method call.

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

**Strengths:** One of the benefits is that it allows for centralized access to a single object.  This is good because calls to the object can be standardized and incorporated quickly. It also limits the object graph for the application and gets rid of some of the ambiguity of creating the object for each usage.

**Weaknesses:** It can, however, create race conditions, potential locks over shared resources, and state consistency issues. If properties of the object can be changed during or between calls to the singleton, inconsistent processing output will likely occur.

***4. Where have you seen this pattern used/abused in our systems?***

Authentication, Logging, E-Mail Queue

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

- They are tightly coupled to their consumer as there is only one concrete instantiation available.
- Dependencies can be hidden in one very complex class.
- All the code that consumes that class will also get any and all of the api. Even if some of the functionality isn't part of the needs of the particular consumption point.

## Abstract Factory

[TOP](#-patterns)

> A set of factories that implement production interfaces based on a logical or operational categorization.  The objects are not explicitly created based on their concrete class and have parity to objects from other sibling factories.

[![Abstract Factory](https://www.dofactory.com/images/diagrams/net/abstract.gif)](https://www.dofactory.com/net/abstract-factory-design-pattern)

```c
//args = new string[] { "aquarium", "Acme Aquarium" }
void Main(string[] args)
{
  //Find out who we're supplying animals to
  IHatchery<IAnimal, IFood> sourcedFrom;
  IRefuge deliverTo;

  if (args[0].ToLower() == "aquarium")
  {
      sourcedFrom = new FishFarm();
      deliverTo = new Aquarium(args[1]);
  }
  else
  {
      sourcedFrom = new Rookery();
      deliverTo = new Aviary(args[1]);
  }

  deliverTo.ReceiveAnimals(sourcedFrom.GetAnimals());
  deliverTo.ReceiveFood(sourcedFrom.GetFood());

  //Figure out what we got
  $"{args[0].ToUpper()}: {args[1]}".Dump();
  $"Received {deliverTo.Animals.Count()} {deliverTo.Animals.First().GetType().Name}(s)".Dump();
  $"Received {deliverTo.Food.Count()} pounds of {deliverTo.Food.First().GetType().Name}".Dump();

  //Expected Output
  //AQUARIUM: Acme Aquarium
  //Received 100 Fish(s)
  //Received 10000 pounds of BrineShrimp
}

public interface IAnimal { }
public interface IFood { }

public class BrineShrimp : IAnimal, IFood { }
public class Fish : IAnimal, IFood { }
public class Bird : IAnimal, IFood { }

public interface IRefuge<A, F>
{
...

void ReceiveAnimals(IEnumerable<A> animals);
void ReceiveFood(IEnumerable<F> food);
}

public abstract class Refuge : IRefuge<IAnimal, IFood>
{
...

}
public class Aquarium : Refuge
{
  ...
}
public class Aviary : Refuge
{
  ...
}

public interface IHatchery <out A, out F>
{
  A BuildAnimal();
  IEnumerable<A> GetAnimals();

  F BuildFood();
  IEnumerable<F> GetFood();
}

public class FishFarm : IHatchery<Fish, BrineShrimp>
{
public Fish BuildAnimal() => new Fish();
public IEnumerable<Fish> GetAnimals()
  => Enumerable.Range(0, 100).Select(r => BuildAnimal());

public BrineShrimp BuildFood() => new BrineShrimp();
public IEnumerable<BrineShrimp> GetFood()
  => Enumerable.Range(0, 10_000).Select(r => BuildFood());
}

public class Rookery : IHatchery<Bird, Fish>
{
  ...
}
```

***1. When to use the pattern? When not to?***

Useful for when a logical grouping of objects can be packaged together by the factory, but have equivalence to objects built by another factory. This pattern is useful if the production objects have 2 or more degrees of separation in operational value or a logical container can be inferred.  

For example, an interface `IHatchery` could define `GetAnimal` and `GetFood`. A hatchery could be for fish or birds, so both `FishFarm` and `Rookery` could implement `IHatchery`.  If there is no logical or operational separation other than birds or fish, then the design pattern could simply be a factory that returns either type of animal.  But with the implementation of different possible foods that must be paired with their respective animals, then it make sense to begin separating the outputs by different polymorphic concerns.

***2. How to migrate code to and from this pattern?***

First we need to decide what the logical or operation group is between the possible factory objects are.  Are there really more than one categorizations that dictate what object gets built? If so, which is the first categorization that divides factory objects into the smallest number of sets?  This category will be the model used to create the factory objects.

Depending on the complexity of the remaining categories, you could continue to nest factories, but this could lead to "factories of factories".  It's probably best to treat the rest of the objects as children out to the factory and use the other categorizations as creation parameters instead of a means of further segregation.

Depending on the number of possible factories that are producing, a good way to move away from this pattern is to utilize interface segregation and control statements to the places where these objects are being produced by the factory. If there are only a small number of factories, then  `if` or `switch/case` statements could take the place of the factory construction methods.  If there are a large number of factories, then a transition to another aggregation pattern or consolidation of objects through inheritance could be employed.

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

**Strengths:** This pattern lends itself to quick additions of new objects for instantiation.  It also allows for quick consumption for these new objects through a very standardized interface.

**Weaknesses:** One of its potential flaws is that these instantiations must remain fairly generic and have parity in other like factories.  Also, specialized calls that only appear in one of the factories adds confusion to the overall pattern usage.

***4. Where have you seen this pattern used/abused in our systems?***

HRA File Relocator, ***<Don't know of other places this is used>***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

The initial model conceptualization of the way the factories are broken out needs to be carefully considered.  If the wrong operational/logical category is selected, then reorganizing the factory after it's been deployed is very difficult.  If multiple categories are nested, "factories of factories", functional object parity is harder to maintain and the nested relationship of the factories decrease legibility and debuggability.

## Factory Method

> A method of an object that creates other objects that are closely related to each other. The production objects have a shared interface or base class.  The consumer is mostly concerned that the object received adheres to that specific ancestor rather than it's concrete instantiation.

[TOP](#-patterns)

```c
void Main()
{
    var eventStyle = Style.Popular;
    var agent = new BookingAgent();
    var musicalEntertainment = agent.BookBand(eventStyle);

    $"--{musicalEntertainment.GetType().Name}--".Dump();
    musicalEntertainment
        .Artists
        .Select(a => a.GetType().Name)
        .Dump();

    /* Expected Output
    --RockBand--
    Singer
    LeadGuitar
    Bassist
    Drummer
    */
}

public enum Style { Popular, Classical }

public interface IMusician
{
    Style Style { get; }
}
public class Drummer : IMusician
{
    public Style Style => Style.Popular;
}
...

public abstract class Band
{
    public Style Style { get; protected set; }
    public IEnumerable<IMusician> Artists { get; protected set; }
}

public class Symphony : Band
{
    public Symphony()
    {
        this.Style = Style.Classical;
        this.Artists = new List<IMusician>(new IMusician[]{
            new Singer(),
            ...
        });
    }
}
...

public class BookingAgent
{
    public Band BookBand(Style style)
    {
        switch (style)
        {
            case Style.Classical:
                return new Symphony();
            case Style.Popular:
                return new RockBand();
            default:
                throw new ApplicationException("Unknown booking style");
        }
    }
}
```

***1. When to use the pattern? When not to?***

It's useful when you need an object created based one or more factors, but aren't necessarily looking to instantiate a specific concrete class. This allows a loose coupling that can be addressed by processes later on that need to know more discrete things about the built class or classes.

If the factory method objects don't have the ability to stand in for each other in later processing, or if they immediately need to be utilized as a particular concrete type, then the development complexity and overhead likely isn't worth it.

***2. How to migrate code to and from this pattern?***

Moving this pattern requires identifying where all the related objects are being created deciding if an abstracted version can stand in for the bulk of the subsequent processing.  Does the new object have any particular characteristic that is necessary and is only available by a relative few of the concrete classes.

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

**Strengths:** Consumers don't need to be concerned with concrete instantiations and can handle a larger variety of potential outpu

**Weaknesses:**

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Facade

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Adapter

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Proxy

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Visitor

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Iterator

> Description

[TOP](#-patterns)

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Observer

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Command

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Strategy

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Prototype

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Decorator

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Chain of Responsibility

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***

## Circuit Breaker

> Description

[TOP](#-patterns)

***1. When to use the pattern? When not to?***

***2. How to migrate code to and from this pattern?***

***3. What are the tradeoffs of using the pattern (strengths and weaknesses)?***

***4. Where have you seen this pattern used/abused in our systems?***

***5. What are the maintenance concerns with utilizing this pattern, both during development and when reading the code?***
