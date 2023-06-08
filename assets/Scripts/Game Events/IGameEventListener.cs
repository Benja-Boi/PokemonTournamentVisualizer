namespace Game_Events
{
    public interface IGameEventListener
    {
        void OnEventRaised(IGameEvent gameEvent);
        
        void OnEventRaised(IGameEvent gameEvent, int value);
                
        void OnEventRaised(IGameEvent gameEvent, float value);
    }
}