namespace UltimateTankClash.Interfaces
{
    using Models;

    public interface ICollidable
    {
        void RespondToCollision(GameObject hitObject);
    }
}
