using System.Collections.Generic;

namespace KemothStudios.EventSystem
{
    public static class EventBus<T> where T : IEvent
    {
        private static HashSet<IEventBinding<T>> _bindings = new HashSet<IEventBinding<T>>();
        private static HashSet<IEventBinding<T>> _signleUseBindings = new HashSet<IEventBinding<T>>();

        public static void RegisterBinding(IEventBinding<T> binding)
        {
            _bindings.Add(binding);
        }
        
        public static void RegisterBindingOnce(IEventBinding<T> binding) => _signleUseBindings.Add(binding);

        public static void UnregisterBinding(IEventBinding<T> binding)
        {
            _bindings.Remove(binding);
        }

        public static void RaiseEvent(T @event)
        {
            foreach (IEventBinding<T> binding in _bindings)
            {
                binding.OnEvent(@event);
                binding.OnEventNoArgs();
            }

            foreach (IEventBinding<T> binding in _signleUseBindings)
            {
                binding.OnEvent(@event);
                binding.OnEventNoArgs();
            }
            _signleUseBindings.Clear();
        }
    }
}
