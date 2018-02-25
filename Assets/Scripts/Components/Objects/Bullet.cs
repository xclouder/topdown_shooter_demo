using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;

	private Transform tr;
	//private Rigidbody rb;
	void Start()
	{
		tr = transform;
	//	rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		//rb.MovePosition(tr.forward * speed * Time.deltaTime);
		tr.Translate(tr.forward * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider collider)
	{
		Destroy(gameObject);
	}

}
