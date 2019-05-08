# C# Static vs Non-Static

Static classes and functions allow for calls to properties and methods of a class without instantiation.  For example:

```csharp
public static class AStaticCalledClass {
    public static string Name { get; set ;}
}

public class BNonStaticCallingClass {
    public BNonStaticCallingClass(){
        //set the name of the class
        AStaticCalledClass.Name = "Name gets set here";
    }

    public string RetrieveName() => AStaticCalledClass.Name;
}

public static void Main(string[] args){
    var newBCaller = new BNonStaticCallingClass();

    Console.WriteLine($"Passed/Set Name: { newBCaller.RetrieveName() }");
}

```

**Output:**

`Passed/Set Name: Name gets set here`


`AStaticCalledClass` can be called from any other class in the namespace or where the namespace is imported. Its properties and values are immediately available and can be altered by any other object that can reference it.
<br /><br />

Static properties and methods may also be declared as part of a non-static class. This allows for contractual access to a class without having instantiate a copy of it.

```csharp
public class RegularClass{
    public string Name { get; set; }
    
    public RegularClass(string name)
        => this.Name = name;

    public static DateTime StaticNow()
        => DateTime.Now;
}

public static void Main(string[] args){
    var rClass = new RegularClass("Regular Name");

    Console.WriteLine($"Class Name: { rClass.Name }");
    Console.WriteLine($"Now: { RegularClass.StaticNow().ToString("yyyy-MM-dd") }");
}
```

**Output:**

`Class Name: Regular Name`

`Now: 2019-05-08`
