using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    // todo work-out why sometimes slow on first play of scene

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 8f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 8f;
    [Tooltip("In m")] [SerializeField] float xLimit = 5f;
    [Tooltip("In m")] [SerializeField] float yLimit = 3f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 10f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    void Start () {
        
    }

    void Update () {
        if (isControlEnabled) {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void OnPlayerDeath() { // called by string reference
        isControlEnabled = false;
    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -Mathf.Abs(xLimit), xLimit);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float clampedYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -Mathf.Abs(yLimit), yLimit);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation() {
        float pitchDueToPositon = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPositon + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring() {
        if (CrossPlatformInputManager.GetButton("Fire")) {
            SetGunsActive(true);
        } else {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive) {
        foreach (GameObject gun in guns) {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
