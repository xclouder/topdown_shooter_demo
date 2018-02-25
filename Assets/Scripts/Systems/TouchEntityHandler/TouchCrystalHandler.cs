using UnityEngine;
using System.Collections;

public class TouchCrystalHandler : ITouchEntityHandler {

	#region ITouchEntityHandler implementation

	public void Handle (BaseTouchable entity)
	{
		var c = entity as Crystal;

		var evt = new ScoreAddEvt();
		evt.Score = c.score;
		EventSys.Instance.Publish(evt);

		Object.Destroy(c.gameObject);
	}

	#endregion




}
