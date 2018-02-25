using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour, ISystem {

	private int m_score = 0;
	public int Score
	{
		get 
		{
			return m_score;
		}
	}

	#region ISystem implementation

	public void Init ()
	{
		m_score = 0;

		EventSys.Instance.AddListener<ScoreAddEvt>(OnAddScoreEvt);
	}

	public void Reset ()
	{
		
	}

	public void LogicUpdate ()
	{
		
	}

	public void Release ()
	{
		EventSys.Instance.RemoveListener<ScoreAddEvt>(OnAddScoreEvt);
	}

	#endregion

	public delegate void OnScoreChanged(int newScore);
	public event OnScoreChanged onScoreChanged;

	void OnAddScoreEvt(ScoreAddEvt evt)
	{
		m_score += evt.Score;

		NotifyScoreChanged();
	}

	void NotifyScoreChanged()
	{
		if (onScoreChanged != null)
		{
			onScoreChanged(m_score);
		}
	}

}
