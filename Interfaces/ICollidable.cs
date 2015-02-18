namespace UltimateTankClash.Interfaces
{
    using Models;

    interface ICollidable
    {
        void RespondToCollision(GameObject hitObject);
    }
}
