namespace UltimateTankClash.Interfaces
{
    using Model.CollectibleItems;

    public interface ICollect
    {
        void AddItemToInventory(CollectibleItem item);

        void ApplyItemEffects(CollectibleItem item);
    }
}
