using UnityEngine;
using System.Collections;

public class DelayDestroy : MonoBehaviour {

	public float delayTime = 3f;

	private float birthTime;
	// Use this for initialization
	void Start () {
		birthTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - birthTime > delayTime)
		{
			Object.Destroy(gameObject);
		}
	}
}
