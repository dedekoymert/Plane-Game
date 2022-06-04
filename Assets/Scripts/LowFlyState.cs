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
		// if (!playerController.IsGrounded())
		// {
		// 	// playerStateMachine.ChangeState(playerStateMachine.lo);
		// }
	}

	public override void UpdatePhysics()
	{
		base.UpdatePhysics();
		// playerController.Move();
		
		if (Input.GetKey(KeyCode.Space))
		{
			// playerStateMachine.ChangeState(playerStateMachine.jumpingState);
			// playerController.Jump();
		}
	}

}
