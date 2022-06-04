using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowFlyState : BaseState
{

	public LowFlyState(PlayerStateMachine psm) : base("Low", psm) { }
	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void UpdateLogic()
	{
		base.UpdateLogic();
		if (!playerController.IsLow())
		{
			playerStateMachine.ChangeState(playerStateMachine.highFlyState);
		}
	}

	public override void UpdatePhysics()
	{
		base.UpdatePhysics();
		playerController.Move();
		playerController.ApplySpeedUp();
	}

}
