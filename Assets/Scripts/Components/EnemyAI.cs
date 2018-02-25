using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private NavMeshAgent m_agent;
	private Transform m_tr;

	// Use this for initialization
	void Start () {
		m_agent = GetComponent<NavMeshAgent>();
		m_tr = transform;

		m_agent.SetDestination(new Vector3(0f, m_tr.position.y, 0f));
	}

}
