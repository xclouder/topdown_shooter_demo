using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Camera m_cam;
	public LayerMask floorLayerMask;
	public float moveSpeed = 10f;

	private Rigidbody m_rigidBody;
	public string HorizontalAxis = "Horizontal";
	public string VerticalAxis = "Vertical";

	private Transform m_tr;

	// Use this for initialization
	void Start () {
		m_cam = Camera.main;
		m_tr = transform;
		m_rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		Aim();
		Move();
	}

	void Aim()
	{
		Ray ray = m_cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 1000, floorLayerMask))
		{
			Vector3 dir = hit.point - m_tr.position; 
			dir.y = 0f;
			m_tr.rotation = Quaternion.LookRotation(dir);
		}
		else
		{
			Debug.Log("raycast empty");
		}
	}

	void Move()
	{
		var moveDelta = GetMoveDelta();
		//Debug.Log("moveDelta:" + moveDelta);
		var movement = m_tr.TransformDirection(moveDelta);

		m_rigidBody.MovePosition(m_tr.position + movement);
	}

	private Vector3 GetMoveDelta()
	{
		return new Vector3(Input.GetAxis(HorizontalAxis), 0f, Input.GetAxis(VerticalAxis)) * moveSpeed * Time.fixedDeltaTime;
	}
}
