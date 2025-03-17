using System;

namespace KemothStudios.EventSystem
{
    public interface IEventBinding<T>
    {
        Action OnEventNoArgs { get; set; }
        Action<T> OnEvent { get; set; }
    }

    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        private Action<T> onEvent = _ => { };
        private Action onEventNoArgs = () => { };
        
        public Action<T> OnEvent {get => onEvent; set => onEvent = value; }
        public Action OnEventNoArgs {get => onEventNoArgs; set => onEventNoArgs = value; }
        
        public EventBinding(Action<T> onEvent) => this.onEvent = onEvent;
        public EventBinding(Action onEventNoArgs) => this.onEventNoArgs = onEventNoArgs;
        
        public void AddEvent(Action<T> @event) => onEvent += @event;
        public void AddEvent(Action @event) => onEventNoArgs += @event;
    }
}
