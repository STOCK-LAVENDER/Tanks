namespace UltimateTankClash.Interfaces
{
    using Models.Characters.Tanks;

    public interface IAttack
    {
        int PhysicalAttack { get; }

        void Shoot(Direction direction);
    }
}
