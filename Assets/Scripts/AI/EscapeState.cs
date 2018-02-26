using UnityEngine;
using System.Collections;

public class EscapeState : BaseState {

	public EscapeState(EnemyContext c) : base(c) { }

	private float m_previousDistance;
	public override void Enter ()
	{
		base.Enter ();

		MoveAwayFromPlayer();
	}

	public override void Execute ()
	{
		base.Execute ();

		if (!IsPlayerInSight(1.5f))
		{
			m_context.fsm.Fire(EnemyEvent.FeelSafe);
		}
		else
		{
			if (m_context.navAgent.remainingDistance < 0.5f || GetDistanceFromPlayer() < m_previousDistance)
			{
				MoveAwayFromPlayer();
			}
		}
	}

	void MoveAwayFromPlayer()
	{
		var dir = m_context.trans.position - m_context.player.transform.position;
		dir.y = 0;

		m_previousDistance = dir.magnitude;
		dir.Normalize();

		var targetPos = m_context.trans.position + dir * m_context.sightDistance * 2f;

		targetPos = GameUtils.RestrictPositionToArena(targetPos);

		m_context.navAgent.SetDestination(targetPos);
	}

}