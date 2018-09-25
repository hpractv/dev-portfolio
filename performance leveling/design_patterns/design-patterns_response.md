# <a id="top">Patterns</a>

Research the following design patterns and be comfortable speaking about things like:
- When to use the pattern? When not to?
- How to migrate code to and from this pattern?
- What are the tradeoffs of using the pattern (strengths and weaknesses)?
- Where have you seen this pattern used/abused in our systems?
- What are the maintenance concerns with utilizing this pattern, both during
  development and when reading the code?

- [X] <a href="#singleton">Singleton</a>
- [ ] Abstract Factory
- [X] <a href="#factory">Factory Method</a>
- [ ] Facade
- [ ] Adapter
- [X] <a href="#proxy">Proxy</a>
- [ ] Visitor
- [ ] Iterator
- [ ] Observer
- [ ] Command
- [ ] Strategy
- [ ] Prototype
- [ ] Decorator
- [ ] Chain of Responsibility
- [ ] Circuit Breaker



## Creation
- [X] <a id="singleton" href="#top">Singleton</a> - single static version of a object is always return on instantiation request

```c#
void Main()
{
	var single = singleton.getSingleton();
	
	single.message.Dump();
	single.built.Dump();
	
	var single2 = singleton.getSingleton();

	single2.message.Dump();
	single2.built.Dump();

}

public class singleton {
	private static singleton _singleton = new singleton();

	static singleton() { _built = DateTime.Now; }
	private singleton() {}
	
	public static singleton getSingleton() => _singleton;
	
	static DateTime _built {get; }
	public DateTime built => _built;
	public string message => "Hello World!";
}

```


- [X] <a id="factory" href="#top">Factory</a> - allows classes with a shared inhertiance or interface to be instantiated from a builder class

```c#
void Main()
{
	var todaysWeatherType = WeatherFactory.GetWeather(50);
	$"It will be {todaysWeatherType.TemperatureRange} you should wear {todaysWeatherType.Dress}."
	.Dump();

	//It will be comfortable you should wear shorts.
}

public enum TemperatureRangeEnum { reallyCold, cold, comfortable, hot, theSun, varies }
public enum DressEnum { parka, pants, shorts, tankTop, nomexFireSuit, umbrella }

public interface IWeather
{
	TemperatureRangeEnum TemperatureRange { get; }
	DressEnum Dress { get; }
}

public class UnknownWeather : IWeather
{
	public TemperatureRangeEnum TemperatureRange => TemperatureRangeEnum.varies;
	public DressEnum Dress => DressEnum.umbrella;
}

public class ArcticWeather : IWeather
{
	public TemperatureRangeEnum TemperatureRange => TemperatureRangeEnum.reallyCold;
	public DressEnum Dress => DressEnum.parka;
}

public class MinnesotaWeather : IWeather
{
	public TemperatureRangeEnum TemperatureRange => TemperatureRangeEnum.cold;
	public DressEnum Dress => DressEnum.pants;
}

public class SanDiegoWeather : IWeather
{
	public TemperatureRangeEnum TemperatureRange => TemperatureRangeEnum.comfortable;
	public DressEnum Dress => DressEnum.shorts;
}

public class ArizonaWeather : IWeather
{
	public TemperatureRangeEnum TemperatureRange => TemperatureRangeEnum.hot;
	public DressEnum Dress => DressEnum.tankTop;
}

public class BrazilWeather : IWeather
{
	public TemperatureRangeEnum TemperatureRange => TemperatureRangeEnum.theSun;
	public DressEnum Dress => DressEnum.nomexFireSuit;
}

public class WeatherFactory
{
	private WeatherFactory() { }
	public static IWeather GetWeather(int? temperature)
	{
		switch (temperature)
		{
			case int temp when temp <= -32:
				return new ArcticWeather();
			case int temp when temp <= 32:
				return new MinnesotaWeather();
			case int temp when temp <= 72:
				return new SanDiegoWeather();
			case int temp when temp <= 102:
				return new ArizonaWeather();
			case int temp when temp > 102:
				return new BrazilWeather();
			default:
				return new UnknownWeather();
		}
	}
}
```


- [ ] Prototype - clones of prototype objects gets a cloned copy and hands it out at request. and also based on kind of clone is needed

## Structure
- [ ] Facade - wrapper that marshals a return object based on potentially more complicated logic or classes behind the facade
- [ ] Adapter - translate between systems, the logic behind may be compatible, but their apis may not equivalent

- [X] <a id="proxy" href="#top">Proxy</a> - acts as pass along entity, takes from one system adds value either in the transport or enriches the interface
  1. Control or delay instantiation
  1. Distributed interface for a remote instance
  1. Permissions gateway
  1. Additional processing over what the base object may implement

```c#
void Main()
{
	var _proxy = new Proxy(1, "One");
	_proxy.Created.Dump();

}

public interface IProxy
{
	int Id { get; set; }
	string Name { get; set; }
	DateTime Created { get; }
}

public class Original : IProxy
{
	public Original(int id, string name){
		Id = id;
		Name = name;
		Created = DateTime.Now;
	}
	public int Id { get; set; }
	public string Name { get; set; }
	public DateTime Created { get; }
}

public class Proxy : IProxy
{
	private Original _original;

	public Proxy(int id, string name){
		_original = new Original(id, name);
	}
	public int Id { get; set; }
	public string Name { get; set; }
	public DateTime Created => _original.Created;
}
```

- [ ] Decorator - adds functionality or properties either dynamically or statically, adheres to _srp_, usefully for adding/removing operational capability at run time, a particular object is "decorated"

## Behavior
- [ ] Visitor - follows the open/close tenet, class level extension of interfaces with modification of classes, new operations create new _interfaces_ 
- [ ] Iterator - an iterator is used to traverse a container, a surface level means of looking at an objects properties sequentially
- [ ] Observer - an object maintains a list of dependents, and notifies them via a specific method for changes, like event handling in .Net (click could kick of multiple event handlers)
- [ ] Command - an object contains all the methods that it needs to perform its operations at instantiation, but may be called to process or act a later time.
- [ ] Strategy - defines a family of algorithms that can be selected at run time. And are interchangeable with on another
- [ ] Chain of Responsibility - processors define what commands they can handle - as an object is passed along, the processor does what it can and then passes the object to the next processor object, can also emit some of the commands outward (tree of responsibility)
- [ ] Circuit Breaker - detects failure