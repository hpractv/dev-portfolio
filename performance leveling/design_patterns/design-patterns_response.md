# Patterns

Research the following design patterns and be comfortable speaking about things like:
- When to use the pattern? When not to?
- How to migrate code to and from this pattern?
- What are the tradeoffs of using the pattern (strengths and weaknesses)?
- Where have you seen this pattern used/abused in our systems?
- What are the maintenance concerns with utilizing this pattern, both during
  development and when reading the code?

- [ ] Singleton: Ensure a class has only one instance, and provide a global point of access to it.

- [ ] Abstract Factory
- [ ] Factory Method
- [ ] Facade
- [ ] Adapter
- [ ] Proxy
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
- [ ] Singleton - single version of a object
- [ ] Factory - allows sub classes to be instantiated from a template class (related to abstract class)
- [ ] Prototype - clones of prototype objects gets a cloned copy and hands it out at request. and also based on kind of clone is needed

## Structure
- [ ] Facade - wrapper that marshals a return object based on potentially more complicated logic or classes behind the facade
- [ ] Adapter - translate between systems, the logic behind may be compatible, but their apis may not equivalent
- [ ] Proxy - acts as pass along entity, takes from one system adds value either in the transport or enriches the interface
- [ ] Decorator - adds functionality or properties either dynamically or statically, adhears to _srp_, usefully for adding/removing operational capability at run time, a particular object is "decorated"

## Behavior
- [ ] Visitor - follows the open/close tenet, class level extension of interfaces with modification of classes, new operations create new _interfaces_ 
- [ ] Iterator - an iterator is used to traverse a container, a surface level means of looking at an objects properties sequentially
- [ ] Observer - an object maintains a list of dependents, and notifies them via a specific method for changes, like event handling in .Net (click could kick of multiple event handlers)
- [ ] Command - an object contains all the methods that it needs to perform its operations at instantiation, but may be called to process or act a later time.
- [ ] Strategy - defines a family of algorithms that can be selected at run time. And are interchangeable with on another
- [ ] Chain of Responsibility - processors define what commands they can handle - as an object is passed along, the processor does what it can and then passes the object to the next processor object, can also emit some of the commands outward (tree of responsibility)
- [ ] Circuit Breaker - detects failure