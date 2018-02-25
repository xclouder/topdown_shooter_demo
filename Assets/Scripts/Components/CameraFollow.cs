using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public Vector3 offset = new Vector3(0.5f, 10.0f, -0.5f);

	private Transform tr;

	void Start()
	{
		tr = transform;
	}

	void FixedUpdate()
	{
		FollowTarget();
	}

	void FollowTarget()
	{
		if (target == null)
		{
			Debug.LogError("target is null");
			return;
		}

		tr.position = target.position + offset;

		tr.LookAt(target.position);
	}

}
