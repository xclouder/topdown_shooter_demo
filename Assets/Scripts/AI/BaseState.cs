using UnityEngine;
using System.Collections;

public class EnemyContext
{
	public float sightDistance;
	public NavMeshAgent navAgent;
	public Transform trans;
	public StateMachine<EnemyState, EnemyEvent> fsm;
	public GameObject player;
}

public class BaseState : IState {

	protected EnemyContext m_context;

	public BaseState(EnemyContext c)
	{
		m_context = c;
	}

	#region IState implementation

	public virtual void Enter ()
	{
		
	}

	public virtual void Execute ()
	{
		
	}

	public virtual void Exit ()
	{
		
	}

	#endregion

	protected bool IsPlayerInSight(float multiflyForDistance = 1f)
	{
		return GetDistanceFromPlayer() < (m_context.sightDistance * multiflyForDistance);
	}

	protected float GetDistanceFromPlayer()
	{
		var delta = m_context.trans.position - m_context.player.transform.position;
		delta.y = 0;

		return delta.magnitude;
	}


}
