namespace UltimateTankClash.Interfaces
{
    public interface ICollect
    {
        void AddItemToInventory(ICollectible item);

        void ApplyItemEffects(ICollectible item);
    }
}
