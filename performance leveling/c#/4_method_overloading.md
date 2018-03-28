# C# Method Overloading

Method overloading is a means of reusing a method name while accepting different argument types or number of arguments.  This allows for different execution logic which is based on the parameters passed in to th method.  This can also be extended to a class constructor.

```c
public class GreatClass{
    public string Name { get; set; }
    
    public GreatClass() : this(2018)
    { }

    public GreatClass(int year) : this(year, null)
    { }

    public GreatClass(int year, string school)
    {
        var schoolName = string.IsNullOrWhiteSpace(school)
            ? $"{school} High "
            : "";
        => this.Name = $"{schoolName}Class of {year}";
    }

    public string welcome() => this.welcome(null);

    public string welcome(string name)
     {
         var greeting = string.IsNullOrWhiteSpace(name)
                ? "student"
                : name;

        return "Welcome {greeting} to the {this.Name}!";
     }
}

```