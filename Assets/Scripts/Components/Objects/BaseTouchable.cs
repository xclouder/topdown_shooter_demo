using UnityEngine;
using System.Collections;

public class BaseTouchable : MonoBehaviour {

	public LayerMask responseLayer;

	void OnTriggerEnter(Collider collider)
	{
		if (CanResponseLayer(collider.gameObject))
		{
			OnTouchEntity();
		}
	}

	protected virtual bool CanResponseLayer(GameObject obj)
	{
		if (responseLayer.value == (1 << obj.layer))
		{
			return true;
		}

		return false;
	}

	protected virtual void OnTouchEntity()
	{
		var evt = new TouchEntityEvt();
		evt.Entity = this;

		EventSys.Instance.Publish(evt);
	}

}
