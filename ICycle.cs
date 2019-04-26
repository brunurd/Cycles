using System;

namespace Cycles
{
    /// <summary>
    /// Common interface in the cycles.
    /// </summary>
    public interface ICycle
    {
        /// <summary>
        /// Return current info of the cycle.
        /// </summary>
        DebugInfo DebugInfo { get; }

        /// <summary>
        /// Get if the cycle is active.
        /// </summary>
        bool IsActive { get; }
    }

    /// <summary>
    /// Common interface in the cycles with types.
    /// </summary>
    public interface ICycle<TState, TData>
    {
        /// <summary>
        /// Get the state type of the cycle.
        /// </summary>
        /// <returns>The type.</returns>
        Type GetStateType();

        /// <summary>
        /// Get the data type of the cycle.
        /// </summary>
        /// <returns>The type.</returns>
        Type GetDataType();
    }
}
