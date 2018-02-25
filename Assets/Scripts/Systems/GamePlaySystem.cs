using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlaySystem : MonoBehaviour, ISystem {

	public BaseUI gameUI;
	public BaseUI gameOverUI;

	#region ISystem implementation

	public void Init ()
	{
		m_touchHandlerDict = new Dictionary<System.Type, ITouchEntityHandler>();
		m_touchHandlerDict.Add(typeof(Crystal), new TouchCrystalHandler());
		m_touchHandlerDict.Add(typeof(TimeBonus), new TouchTimeBonusHandler());
		m_touchHandlerDict.Add(typeof(Gun), new TouchGunHandler());
		m_touchHandlerDict.Add(typeof(Enemy), new TouchEnemyHandler());

		EventSys.Instance.AddListener<GameFinishEvt>(OnGameFinish);
		EventSys.Instance.AddListener<TouchEntityEvt>(OnTouchEntity);

		gameOverUI.Close();
		gameUI.Open();
	}

	public void Reset ()
	{
		
	}

	public void LogicUpdate ()
	{
		
	}

	public void Release ()
	{
		EventSys.Instance.RemoveListener<GameFinishEvt>(OnGameFinish);
		EventSys.Instance.RemoveListener<TouchEntityEvt>(OnTouchEntity);
	}

	#endregion

	void OnGameFinish(GameFinishEvt evt)
	{
		Debug.Log("GameFinished");
		SystemMgr.Instance.PauseUpdate();

		gameUI.Close();
		gameOverUI.Open();
	}

	private Dictionary<System.Type, ITouchEntityHandler> m_touchHandlerDict;
	void OnTouchEntity(TouchEntityEvt evt)
	{
		var entity = evt.Entity;
		ITouchEntityHandler handler = null;

		if (m_touchHandlerDict.TryGetValue(entity.GetType(), out handler))
		{
			handler.Handle(entity);
		}
		else
		{
			Debug.Log("no handler for type:" + entity.GetType());
		}
	}

}
