# Properties vs Fields

In C# properties are defined interfaces to value objects associated with a class.  These value objects are often called fields and can also have their own access modifiers that control how they're exposed to external objects and processes.

The best practice for properties and fields is to have a `public` or `internal` property wrap an `private` field such that control or validation can be done internal to the class and maintain value integrity.

```c
public class Loan {
    private double _interestRate;
    public InterestRate {
        get => _interestRate;
        set =>
         if(value >= 0.0) _interestRate = value;
         else throw new Exception("Interest rate must be greater than or equal to zero");
    }
}

```

In the prior example, we can see that `InterestRate` can be set on the class external