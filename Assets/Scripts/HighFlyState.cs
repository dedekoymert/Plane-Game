using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFlyState : BaseState
{

	public HighFlyState(PlayerStateMachine psm) : base("High", psm) { }

	public override void Enter()
	{
		base.Enter();
		playerController.ChangeOriginalPlane();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void UpdateLogic()
	{
		base.UpdateLogic();
		if (playerController.IsLow())
		{
			playerStateMachine.ChangeState(playerStateMachine.lowFlyState);
		}
	}

	public override void UpdatePhysics()
	{
		base.UpdatePhysics();
		playerController.Move();
		playerController.ApplySlowdown();
	}
}
