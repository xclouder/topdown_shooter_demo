using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : BaseUI {

	public Text scoreLabel;
	public Text timeLabel;

	public override void OnCreateUI ()
	{
		base.OnCreateUI ();
	}

	public override void Open ()
	{
		base.Open ();

		var timeSys = SystemMgr.Instance.GetSystem<TimeSystem>();
		timeSys.onUpdateLeftTime += OnUpdateLeftTime;
		RefreshTime(timeSys.LeftTime);

		RefreshScore();

	}

	void OnUpdateLeftTime(float leftTime)
	{
		RefreshTime(leftTime);
	}

	public override void Close ()
	{
		base.Close ();

		var timeSys = SystemMgr.Instance.GetSystem<TimeSystem>();
		timeSys.onUpdateLeftTime -= OnUpdateLeftTime;
	}

	public override void OnDestroyUI ()
	{
		base.OnDestroyUI ();
	}

	void RefreshTime(float leftTime)
	{
		var timeStr = FormatLeftTime(leftTime);

		timeLabel.text = timeStr;
	}

	void RefreshScore()
	{
		var scoreSystem = SystemMgr.Instance.GetSystem<ScoreSystem>();

		scoreLabel.text = "score:" + scoreSystem.Score.ToString();
	}

	string FormatLeftTime(float leftTime)
	{
		int sec = Mathf.RoundToInt(leftTime);

		int min = sec / 60;
		sec = sec % 60;
		return string.Format("{0}:{1:D2}", min, sec);
	}

}
