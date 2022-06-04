using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{	
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

	// private Rigidbody rb;
    float xThrow, yThrow;

	Color initialColor;

	void Start() {
		initialColor = GetComponent<Renderer>().material.color;
	}

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");
    }

	public void Move() 
	{    
		float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);    
		transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}

	public bool IsLow() {
		return transform.localPosition.y < -1.5f;
	}

	public void ApplySpeedUp() {
		float zOffset = Time.deltaTime * controlSpeed;
        float rawZPos = transform.localPosition.z + zOffset;
		if (transform.localPosition.z < 10f) {
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, rawZPos);
		}
	}

	public void ApplySlowdown() {
		float zOffset = Time.deltaTime * controlSpeed * 1.5f;
		float rawZPos = transform.localPosition.z - zOffset;
		if(transform.localPosition.z > 0) {
			transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, rawZPos);
		}
	}

	public void ChangeRedPlane() {
		GetComponent<Renderer>().material.color = Color.red;
	}

	public void ChangeOriginalPlane() {
		GetComponent<Renderer>().material.color = initialColor;
	}

	public void OnCollisionEnter(Collision other) {
		Debug.Log("Collision with " + other.gameObject.name);
		ApplicationModel.status = 2;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
	}
	
}
