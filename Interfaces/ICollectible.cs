namespace UltimateTankClash.Interfaces
{
    using Model.CollectibleItems;

    public interface ICollectible
    {
        CollectibleItemState State { get; }

        int DamageEffect { get; }

        int Defenseffect { get; }

        int HealthEffect { get; }

        double SpeedEffect { get; }
    }
}
