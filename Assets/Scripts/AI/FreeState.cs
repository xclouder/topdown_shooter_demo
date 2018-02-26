using UnityEngine;
using System.Collections;

public class FreeState : BaseState {

	public FreeState(EnemyContext c) : base(c) { }

	public override void Enter ()
	{
		base.Enter ();

		MoveToARandomPosition();
	}

	public override void Execute ()
	{
		base.Execute ();

		if (IsPlayerInSight())
		{
			m_context.fsm.Fire(EnemyEvent.FoundPlayer);
		}
		else
		{
			if (m_context.navAgent.remainingDistance < 0.5f)
			{
				MoveToARandomPosition();
			}
		}

	}

	void MoveToARandomPosition()
	{
		var moveToPos = GameUtils.GetRandomPositionInArena();
		m_context.navAgent.SetDestination(moveToPos);
	}

}
