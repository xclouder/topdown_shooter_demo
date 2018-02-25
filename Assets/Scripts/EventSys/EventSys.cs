using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventSys {

	private static EventSys m_ins;
	public static EventSys Instance
	{
		get 
		{
			if (m_ins == null)
			{
				m_ins = new EventSys();
			}

			return m_ins;
		}
	}

	public delegate void EventDelegate<T> (T e) where T : class;
	private delegate void EventDelegate (object eventMessage);

	private Dictionary<System.Type, EventDelegate> delegates = new Dictionary<System.Type, EventDelegate>();
	private Dictionary<System.Delegate, EventDelegate> delegateLookup = new Dictionary<System.Delegate, EventDelegate>();

	public void AddListener<T> (EventDelegate<T> del) where T : class
	{	
		// Early-out if we've already registered this delegate
		if (delegateLookup.ContainsKey(del))
			return;

		// Create a new non-generic delegate which calls our generic one.
		// This is the delegate we actually invoke.
		EventDelegate internalDelegate = (e) => del((T)e);
		delegateLookup[del] = internalDelegate;

		EventDelegate tempDel;
		if (delegates.TryGetValue(typeof(T), out tempDel))
		{
			delegates[typeof(T)] = tempDel += internalDelegate; 
		}
		else
		{
			delegates[typeof(T)] = internalDelegate;
		}
	}

	public void RemoveListener<T> (EventDelegate<T> del) where T : class
	{
		EventDelegate internalDelegate;
		if (delegateLookup.TryGetValue(del, out internalDelegate))
		{
			EventDelegate tempDel;
			if (delegates.TryGetValue(typeof(T), out tempDel))
			{
				tempDel -= internalDelegate;
				if (tempDel == null)
				{
					delegates.Remove(typeof(T));
				}
				else
				{
					delegates[typeof(T)] = tempDel;
				}
			}

			delegateLookup.Remove(del);
		}
	}

	public void Publish(object e)
	{
		EventDelegate del;
		if (delegates.TryGetValue(e.GetType(), out del))
		{
			del.Invoke(e);
		}
	}

}


