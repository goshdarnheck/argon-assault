using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 8f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 8f;
    [Tooltip("In m")] [SerializeField] float xLimit = 5f;
    [Tooltip("In m")] [SerializeField] float yLimit = 3f;

    void Start () {
		
	}
	
	void Update () {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -Mathf.Abs(xLimit), xLimit);

        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float clampedYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -Mathf.Abs(yLimit), yLimit);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
	}
}
