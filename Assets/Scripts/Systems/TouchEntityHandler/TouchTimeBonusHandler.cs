using UnityEngine;
using System.Collections;

public class TouchTimeBonusHandler : ITouchEntityHandler {
	#region ITouchEntityHandler implementation

	public void Handle (BaseTouchable entity)
	{
		var bonus = entity as TimeBonus;

		var timeSys = SystemMgr.Instance.GetSystem<TimeSystem>();
		timeSys.AddLeftTime(bonus.time);

		Object.Destroy(entity.gameObject);
	}

	#endregion




}
