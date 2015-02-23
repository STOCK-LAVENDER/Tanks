namespace UltimateTankClash.Interfaces
{
    using Models.CollectibleItems;

    public interface ICollectible
    {
        CollectibleItemState ItemState { get; }

        int DamageEffect { get; }

        int Defenseffect { get; }

        int HealthEffect { get; }

        double SpeedEffect { get; }
    }
}
