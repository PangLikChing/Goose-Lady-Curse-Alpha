using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public interface Event
    {
    };

    private Dictionary<string, System.Action<Event>> events = new Dictionary<string,
 System.Action<Event>>();

    public void AddEvent(string _eventName, System.Action<Event> _event = null)
    {
        System.Action<Event> existingEvent;
        if (events.TryGetValue(_eventName, out existingEvent))
        {
            existingEvent += _event;
        }
        else
        {
            events.Add(_eventName, _event);
        }
    }

    public void RaiseEvent(string _eventName, Event parameter)
    {
        System.Action<Event> existingEvent;
        if (events.TryGetValue(_eventName, out existingEvent))
        {
            existingEvent.Invoke(parameter);
        }
    }

    public void RemoveEvent(string _eventName, System.Action<Event> _event = null)
    {
        System.Action<Event> existingEvent;
        if (events.TryGetValue(_eventName, out existingEvent))
        {
            existingEvent -= _event;
        }
    }
}
