namespace Game_Events
{
    public interface IGameEvent
    {
        public void Raise();
        public void Raise(int value);
        public void Raise(float value);
        public void RegisterListener(IGameEventListener listener);
        public void UnregisterListener(IGameEventListener listener);
    }
}