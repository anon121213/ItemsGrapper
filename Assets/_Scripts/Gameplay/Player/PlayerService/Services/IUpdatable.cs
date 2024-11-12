namespace _Scripts.Gameplay.Player.PlayerService.Services
{
    public interface IUpdatable
    {
        public void Update();
    }

    public interface IFixedUpdatable
    {
        public void FixedUpdate();
    }
}