using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
	public string StateName;
	protected PlayerStateMachine playerStateMachine;
	protected PlayerController playerController;

    public BaseState(string name, PlayerStateMachine psm)
	{
		StateName = name;
		playerStateMachine = psm;
		playerController = psm.GetPlayerController();
	}

	public virtual void Enter() {}
	public virtual void UpdateLogic() { }
	public virtual void UpdatePhysics() { }
	public virtual void Exit() { }
}
