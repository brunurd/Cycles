# Cycles
A strict FSM (Finite-State Machine) architecture implementation.

License: [MIT](LICENSE)

---

## Core Concept

A FSM where you add states each one with a callback, and this callback has a data type as parameter.  


And when you set the state execute the callback sending the data.  


Here a illustrative code snippet:

```C#
AddState(/* pass state here... */, (data) => { 
    // Do something with the data here...
});

SetState(/* pass state here... */, /* pass data here... */);
```

---

## Why?

OOP (Object Oriented Paradigm) can be painful if you lose the control of the data mutation and of the order which things happen.  


My intention with Cycles is turn things easy during the development and in the support of my applications by turning the code more legible and debuggable.  

A library for this is not really necessary, but it's help to set a implementation pattern.  

---

## Rules

- Don't create fields or properties in a Cycle.
- Every Cycle must have a state type.
- Every state of the Cycle must have a callback.
- Every Cycle with a data type has a data object as input in the state events.
- A data type must be related to just one Cycle.

---

## Usage example
It's a `Hello World` example without any practical purpose, just to be a simple implementation:

```C#
// A state list. It can be any type: enum, string, number, object etc.
public enum State
{
    PreLoading,
    Executing,
    Ending
}

// A data to exchange from a state to other.
public struct Data
{
    public string name;
}

// The cycle class using the state and data declared before.
// The data type is optional, the cycle can be dataless.
public class MyCycle : Cycle<State, Data>
{
    // Add your states events in the constructor.
    public MyCycle()
    {
        AddState(State.PreLoading, Preload);
        AddState(State.Executing, Execute);
        AddState(State.Ending, End);
    }

    // Is a best practice set the first state in a method.
    public void Start(string name)
    {
        SetState(State.PreLoading, new Data { name = name });
    }

    #region Events

    private void Preload(Data data)
    {
        // Do something before load here.

        SetState(State.Executing, data);
    }

    private void Execute(Data data)
    {
        Console.WriteLine($"Hello {data.name}!");
        SetState(State.Ending, data);
    }

    private void End(Data data)
    {
        Kill();
    }

    #endregion
}
```
