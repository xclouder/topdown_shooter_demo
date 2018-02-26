using UnityEngine;
using System.Collections;


public enum EnemyState
{
	Free,
	Escape
}

public enum EnemyEvent
{
	FoundPlayer,
	FeelSafe
}

public class EnemyAI : MonoBehaviour {

	public float sightDistance = 5f;

	private StateMachine<EnemyState, EnemyEvent> m_fsm;

	// Use this for initialization
	void Start () {
		
		SetupFSM();
	}

	void SetupFSM()
	{
		m_fsm = new StateMachine<EnemyState, EnemyEvent>();

		EnemyContext ctx = new EnemyContext();
		ctx.navAgent = GetComponent<NavMeshAgent>();
		ctx.trans = transform;
		ctx.fsm = m_fsm;
		ctx.sightDistance = sightDistance;

		//var enemySys = SystemMgr.Instance.GetSystem<EnemySystem>();
		ctx.player = GameObject.FindWithTag("Player");

		m_fsm.In(EnemyState.Free)
			.On(EnemyEvent.FoundPlayer)
			.GoTo(EnemyState.Escape)
			.Attach(new FreeState(ctx));

		m_fsm.In(EnemyState.Escape)
			.On(EnemyEvent.FeelSafe)
			.GoTo(EnemyState.Free)
			.Attach(new EscapeState(ctx));

		m_fsm.Initialize(EnemyState.Free);

		m_fsm.Start();

	}

	void Update()
	{
		m_fsm.Execute();
	}

}
