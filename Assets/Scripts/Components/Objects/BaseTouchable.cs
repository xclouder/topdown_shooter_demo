using UnityEngine;
using System.Collections;

public class BaseTouchable : MonoBehaviour {

	public LayerMask responseLayer;

	void OnTriggerEnter(Collider collider)
	{
		if (responseLayer.value == (1 << collider.gameObject.layer))
		{
			OnTouchEntity();
		}
	}

	protected virtual void OnTouchEntity()
	{
		var evt = new TouchEntityEvt();
		evt.Entity = this;

		EventSys.Instance.Publish(evt);
	}

}
