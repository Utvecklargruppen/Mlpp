namespace Mlpp.Domain
{
    public interface IStateObject<TState>
    {
        TState GetInternalState();
    }
}
