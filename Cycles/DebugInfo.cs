using System;

namespace Cycles
{
    /// <summary>
    /// A data type to contains debug info of the cycle.
    /// </summary>
    [Serializable]
    public struct DebugInfo
    {
        public string cycleName;
        public string cycleShortName;
        public string dateTime;
        public string state;
        public object data;
    }
}
