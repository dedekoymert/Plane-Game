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

	private IEnumerator coroutine;

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

		coroutine = time();
		StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
		if (currentState != null)
			currentState.UpdateLogic();
		
		if (ApplicationModel.score == 15) {
			ApplicationModel.status = 1;
			ApplicationModel.score = 0;
			UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
		}
    }

	void LateUpdate()
	{
		if (currentState != null)
			currentState.UpdatePhysics();
	}

	IEnumerator time() {
    	while (true)
     	{
			if(currentState == lowFlyState) {
         		ApplicationModel.score += 1;
			}
         	yield return new WaitForSeconds(1);
     	}
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
