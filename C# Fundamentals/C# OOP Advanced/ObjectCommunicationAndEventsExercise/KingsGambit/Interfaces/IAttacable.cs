namespace KingsGambit.Interfaces
{
    public interface IAttacable
    {
        void KingIsUnderAttack();
        string Name { get; set; }
    }
}