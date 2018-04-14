namespace KingsGambit.Interfaces
{
    public interface IKillable
    {
        string TheKingIsUnderAttack();
        bool IsAlive { get;  set; }
        string Name { get; set; }
        void Kill(string name);
    }
}