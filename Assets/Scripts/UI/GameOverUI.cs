using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : BaseUI {

	public Text scoreLabel;

	public override void OnCreateUI ()
	{
		base.OnCreateUI ();

	}

	public override void Open ()
	{
		base.Open ();

		var scoreSys = SystemMgr.Instance.GetSystem<ScoreSystem>();
		scoreLabel.text = scoreSys.Score.ToString();
	}

	public override void Close ()
	{
		base.Close ();
	}

	public override void OnDestroyUI ()
	{
		base.OnDestroyUI ();
	}

	public void OnClickReplay()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

}
