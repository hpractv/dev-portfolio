# C# Scope

Scope applies the level at which an object, method or reference is declared and can be used or acted upon.  Meaning a object that is declared a specific block level can only be accessed at tha block level or one that that is nested within it.

With respect to c# scope can be thought of at 3 different levels. Local, Namespace, and Global.  There are other modifiers like public, private, internal, and protected when considering the declaration of classes, but the basic gist is that the degree to which an object or reference can be acted up is with in a block container and not outside.

### Local

This example shows how a variable is declared in an outer scope withing in a function and is accessible within the rest of the function:

```c
public void outerScope(int availableTop){
    bool positive = false;

    if(availableTop >= 0){
        //positive can be accessed by a more nested scope
        positive = true;
        
        if(positive){
            Display("Positive!");
        }
    }

    //Because of Scope "Negative!" will be printed as well    
    if(!positive){
        Display("Negative!");
    }
}

```

### Namespace

Name space declaration allows for shortened referencing to classes  static objects withing the same name space.  This allows for an easier access to other declared items within a name space without having to include a `using` statement or a full explicit namespace reference.

```c
namespace App.One {
    public class OneClass {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TwoClass {
        private OneClass _anotherNameSpaceClass { get; set; }

        public TwoClass(OneClass oneClassName)
            => _anotherNameSpaceClass = oneClassName;

        public string AnotherClassName 
            => _anotherNameSpaceClass.Name;
    }
}

namespace App.Two {
    public class DifferentClass {
        private App.One.OneClass _differentNameSpaceClass { get; set; }

        public DifferentClass(App.One.OneClass differentNameSpaceClass)
            => _differentNameSpaceClass = differentNameSpaceClass;

        public string differentNameSpaceClassName()
            => _differentNameSpaceClass.Name;
    }
}
```

If several classes and objects from another namespace are referenced, then adding a `using` statement at will make those classes easier to use.  Classes in `App.One` can easily be created and referenced with out a full namespace prefix.

```c
using App.One;

namespace App.ElseWhere{
    public class OtherPlacenamespace
     {
        private OneClass _differentNameSpaceClass { get; set; }

        public DifferentClass(OneClass differentNameSpaceClass)
            => _differentNameSpaceClass = differentNameSpaceClass;

        public string differentNameSpaceClassName()
            => _differentNameSpaceClass.Name;
    }
}

}

```

### Global

Global scoped classes and interfaces can be created by not being declared in a `namespace`.  However, that means it can be used/included anywhere in the application.  While this could work well for some low level functions or classes, it could make it hard to differentiate classes from each other, because there is not a good namespace container to delineate their differences.

For example a class call `Graph`, could mean something different in a `Drawing` namespace versus that of a `MachineLearning` library. The appropriate partitioning could give a lot of semantic meaning, so building truly global classes and functions should be used sparingly.

