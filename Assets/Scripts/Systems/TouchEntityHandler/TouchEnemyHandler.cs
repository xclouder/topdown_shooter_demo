using UnityEngine;
using System.Collections;

public class TouchEnemyHandler : ITouchEntityHandler {
	#region ITouchEntityHandler implementation

	public void Handle (BaseTouchable entity)
	{
		var e = entity as Enemy;

		var evt = new ScoreAddEvt();
		evt.Score = e.Score;
		EventSys.Instance.Publish(evt);

		Object.Destroy(entity.gameObject);
	}

	#endregion




}
