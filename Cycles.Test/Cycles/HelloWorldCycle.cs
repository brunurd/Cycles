using System;

namespace Cycles.Test.Cycles
{
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
    public class HelloWorldCycle : Cycle<State, Data>
    {
        // Add your states events in the constructor.
        public HelloWorldCycle()
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
}