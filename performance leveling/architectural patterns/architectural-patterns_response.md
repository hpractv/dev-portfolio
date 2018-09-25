# Architectural Patterns and Practices



Research the following architectural patterns and be comfortable speaking about things like:
- When to use the pattern? When not to?
- How to migrate legacy systems to and from this pattern?
- What are the tradeoffs of using the pattern (strengths and weaknesses)?
- Where have you seen this pattern used/abused in our systems?
- What are the maintenance concerns with utilizing this pattern, both during development and during operation in production?

Notes:

[Exercises in .NET with Andras Nemes](https://dotnetcodr.com/architecture-and-patterns/)


<hr/>

- [ ] MVC - Model, View, Controller

_References_

[Wikipedia: Model–view–controller](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)

![Diagram of interactions within the MVC pattern.](https://upload.wikimedia.org/wikipedia/commons/a/a0/MVC-Process.svg)

<hr />

- [ ] MVVM - Model, View, View Model

The view model is responsible for exposing (converting) the data objects from the model in such a way that objects are easily managed and presented

[Wikipedia: Model–view–viewmodel](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel)

![](https://upload.wikimedia.org/wikipedia/commons/8/87/MVVMPattern.png)

<hr/>

- [ ] SOLID

    - S - single purpose
    - O - open for extension closed for modification
    - L - Liskov Principal: any derived class can stand in for a base class
    - I - Interface abstraction: multiple interfaces with directed purposes over a monolithic one
    - D - Dedpendency inversion - _"High-level modules should not depend on low-level modules. Both should depend on abstractions."_

_References_

[SOLID (object-oriented design)](https://en.wikipedia.org/wiki/SOLID_(object-oriented_design))

[Exercises in .NET with Andras Nemes](https://dotnetcodr.com/architecture-and-patterns/)

<hr/>

- [ ] Web Services / REST

Service Oriented Architecture agnostic of the consuming client

<hr/>

- [ ] Single Page Apps - Mimics desktop application and uses a single page or the minimal amount of pages to execute tasks and workflow


<hr/>

- [ ] CQRS - Command and Query Responsibility Segregation

Every action is a command or a query.  Commands issue updates to data or state.  Queries request read-only data operations.

Different thant CRUD, CQRS code can't automatically be generated using scaffold mechanisms.

_References_

[Command and Query Responsibility Segregation (CQRS) pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

<hr/>

- [ ] Microservices



<hr/>

- [ ] Reversibility

<hr/>

- [ ] Pub/Sub

Publish and subscription model.  The service publishes different messages in category channels.  The consumers subscribe to channels that they find important and only pick up messages published in the specific channels.  The service only concerns it self with publishing events, and subscribers only concerns itself with messages published in particular channels.

Sibling of the [Message Queue](https://en.wikipedia.org/wiki/Message_queue)

_References_

[Publish–subscribe pattern](https://en.wikipedia.org/wiki/Publish%E2%80%93subscribe_pattern)


<hr/>

- [ ] Event Sourcing

<hr/>

- [ ] Reactive Programming

<hr/>

- [ ] Asynchronous messaging

<hr/>

- [ ] Sagas



<hr />

_References_

Wikipedia: [Architectural pattern](https://en.wikipedia.org/wiki/Architectural_pattern)

<hr/>

