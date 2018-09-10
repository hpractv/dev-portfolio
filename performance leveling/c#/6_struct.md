# Struct

Structs are an alternative to class definition/instantiation.  The declaration and usage are essentially identical to class, but the memory allocation is contained in stack memory. Stack memory is essentially more quickly allocated and freed.  Stack memory management is optimized for objects with smaller memory footprints.  

### Would you mind describing _value type_ vs. _reference type_?

A _value type_ is a field variable that contains a value rather than an address or pointer to another location.  This is allows for quick read/write operations because the values can be processed without extra traversal to other memory locations.

A _reference type_, on the other hand, is a property variable that holds a an address reference to another memory location that contains the actual variable value.  This style of memory management is useful for processing large graphs of objects.  Less overhead is involved only manipulating address instead of locations filled with larger value types.

### How does a `struct` work with inheritance?

A `struct` cannot be derived from another `class` or `struct`.  It is able implement an interface, though.  Once defined, it is considered a `sealed` class and can't have it's properties exteded through inheritance.

### What restrictions are there on the constructor(s) of a `struct`?

A struct may multiple parameterized constructors, but may no contain a default constructor with no parameters.

### How should equality be handled in a `struct`?

Equality evaluation between structs should be done through overloaded `==` and `!=` operators that evaluate the fields/properties that make up the struct (see example below).

```csharp
public struct BaseStruct
{
    public int Id;

    public BaseStruct(int id) => Id = id;

    public static bool operator ==(BaseStruct a, BaseStruct b)
        => a.Id == b.Id;

    public static bool operator !=(BaseStruct a, BaseStruct b)
        => a.Id != b.Id;
}

void Main()
{
    BaseStruct bsTest;
    bsTest.Id = -1;

    BaseStruct bsTest2;
    bsTest2.Id = -2;

    Console.WriteLine($"Struct 1 and Struct 2 are {(bsTest == bsTest2) ? " " : "not "}the same.");

    //Exptected Output:
    //Struct 1 and Struct 2 are not the same.
}
```