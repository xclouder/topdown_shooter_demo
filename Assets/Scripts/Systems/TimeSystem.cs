using UnityEngine;
using System.Collections;

public class TimeSystem : MonoBehaviour, ISystem {

	private float m_leftTime;
	public float roundTime = 120f; //2 sec

	public float LeftTime
	{
		get 
		{
			return m_leftTime;
		}
	}


	#region ISystem implementation

	public void Init ()
	{
		m_leftTime = roundTime;
	}

	public void Reset ()
	{
		
	}

	public delegate void OnUpdateLeftTime(float leftTime);
	public event OnUpdateLeftTime onUpdateLeftTime;

	void NotifyUpdateLeftTime()
	{
		if (onUpdateLeftTime != null)
		{
			onUpdateLeftTime(m_leftTime);
		}
	}

	public void LogicUpdate ()
	{
		m_leftTime -= Time.deltaTime;

		NotifyUpdateLeftTime();

		if (m_leftTime <= 0)
		{
			m_leftTime = 0;
			EventSys.Instance.Publish(new GameFinishEvt());
		}

	}

	public void Release ()
	{
		
	}
	#endregion




}
