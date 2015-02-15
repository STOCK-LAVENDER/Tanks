namespace UltimateTankClash.Interfaces
{
    interface ICollect
    {
        void AddItemToInventory(ICollectible item);

        void ApplyItemEffects();
    }
}
