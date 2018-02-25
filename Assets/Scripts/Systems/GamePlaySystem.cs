using UnityEngine;
using System.Collections;

public class GamePlaySystem : MonoBehaviour, ISystem {

	public BaseUI gameUI;
	public BaseUI gameOverUI;

	#region ISystem implementation

	public void Init ()
	{
		EventSys.Instance.AddListener<GameFinishEvt>(OnGameFinish);

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
	}

	#endregion

	void OnGameFinish(GameFinishEvt evt)
	{
		Debug.Log("GameFinished");
		SystemMgr.Instance.PauseUpdate();

		gameUI.Close();
		gameOverUI.Open();
	}

}
