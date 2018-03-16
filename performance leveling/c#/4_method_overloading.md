# C# Method Overloading

Method overloading is a means of reusing a method name or class constructor name with different arguments.  This allows for different program or logic execution based on how well 

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
                ? "student
                : name;

        => "Welcome {greeting} to the {this.Name}!";
     }
}

```