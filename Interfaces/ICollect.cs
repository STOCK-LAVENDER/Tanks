namespace UltimateTankClash.Interfaces
{
    using Models.CollectibleItems;

    public interface ICollect
    {
        void AddItemToInventory(CollectibleItem item);

        void ApplyItemEffects(CollectibleItem item);
    }
}
