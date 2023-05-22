namespace Game_Events
{
    public interface IGameEvent
    {
        public void Raise();
        public void RegisterListener(IGameEventListener listener);
        public void UnregisterListener(IGameEventListener listener);
    }
}