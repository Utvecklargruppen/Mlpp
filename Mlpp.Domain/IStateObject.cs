namespace Mlpp.Domain
{
    public interface IStateObject<out TState>
    {
        TState GetInternalState();
    }
}
