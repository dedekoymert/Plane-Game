using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStateMachine : MonoBehaviour
{

	BaseState currentState;
	PlayerController playerController;

	[HideInInspector]
	public LowFlyState lowFlyState;
	[HideInInspector]
	public HighFlyState highFlyState;


	private void Awake()
	{
		playerController = GetComponent<PlayerController>();
		lowFlyState = new LowFlyState(this);
		highFlyState = new HighFlyState(this);
	}


	// Start is called before the first frame update
	void Start()
    {
		if (currentState == null)
			currentState = GetInitialState();
		currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
		if (currentState != null)
			currentState.UpdateLogic();

		Debug.Log(currentState.StateName);
    }

	void LateUpdate()
	{
		if (currentState != null)
			currentState.UpdatePhysics();
	}


	public void ChangeState(BaseState newState)
	{
		currentState.Exit();

		currentState = newState;

		currentState.Enter();
	}

	public BaseState GetInitialState()
	{
		return highFlyState;
	}

	public PlayerController GetPlayerController()
	{
		return playerController;
	}
}
