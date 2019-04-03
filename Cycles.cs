using System;
using System.Collections.Generic;

namespace Cycles
{
    /// <summary>
    /// A abstract class to implement a cycle.
    /// A cycle is a finite state machine with a data input and output of the same type to every state event.
    /// </summary>
    /// <typeparam name="TState">The type of the state. Example: Enum, string or int.</typeparam>
    /// <typeparam name="TData">The type of the data.</typeparam>
    public abstract class Cycle<TState, TData>
    {
        /// <summary>
        /// The state events list to store all events in the cycle.
        /// </summary>
        private List<StateEvent> events;

        /// <summary>
        /// The current state.
        /// It's a protected property to avoid the temptation to use in other classes.
        /// </summary>
        protected TState CurrentState { get; private set; }

        /// <summary>
        /// The state event object.
        /// </summary>
        private struct StateEvent
        {
            public TState state;
            public Action<TData> callback;
        }

        /// <summary>
        /// Cycle class constructor.
        /// A cycle is a finite state machine with a data input and output of the same type to every state event.
        /// </summary>
        public Cycle()
        {
            events = new List<StateEvent>();
        }

        /// <summary>
        /// Add a event to the cycle list.
        /// </summary>
        /// <param name="state">The state to add.</param>
        /// <param name="callback">The event callback to execute on set this state.</param>
        protected void AddState(TState state, Action<TData> callback)
        {
            foreach (var e in events)
            {
                if (e.state.Equals(state))
                {
                    throw new Exception($"The state {state} already exist.");
                }
            }

            events.Add(new StateEvent {state = state, callback = callback});
        }

        /// <summary>
        /// Set a state to run it event.
        /// </summary>
        /// <param name="state">The state to set.</param>
        /// <param name="data">The data input.</param>
        protected void SetState(TState state, TData data)
        {
            foreach (var e in events)
            {
                if (e.state.Equals(state))
                {
                    CurrentState = e.state;
                    e.callback?.Invoke(data);
                    return;
                }
            }
        }
    }
}