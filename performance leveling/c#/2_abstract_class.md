# C# Abstract Class

Abstract classes are specific classes that can be defined and inherited from, but <span style="text-decoration: underline;">not</span> instantiated. They are particularly effective at enforcing that an inherited class adheres to an interface contract.  The contract methods can be partially implemented and the inherited class receives any base methods or properties that should be distributed all child classes.

The contract adherence can be handled through interfaces, but if there a lot of shared base class methods or properties, then it saves a lot of individual class level development of the same or very similar code.

