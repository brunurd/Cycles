namespace Cycles.Test.Cycles
{
    public enum NoDataState
    {
        One,
        Two,
        Three
    }
    
    public class NoDataCycle : Cycle<NoDataState>
    {
        public NoDataState State
        {
            get => CurrentState;
            set => SetState(value);
        }

        public NoDataCycle()
        {
            AddState(NoDataState.One, null);
            AddState(NoDataState.Two, null);
            AddState(NoDataState.Three, null);
        }
    }
}