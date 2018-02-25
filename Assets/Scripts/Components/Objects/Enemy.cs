using UnityEngine;
using System.Collections;

public class Enemy : BaseTouchable {

	public int Score;

	protected override bool CanResponseLayer (GameObject obj)
	{
		bool isTouch = base.CanResponseLayer(obj);

		bool isShot = (LayerMask.NameToLayer("Bullet") == obj.layer);

		return isTouch || isShot;
	}

}
