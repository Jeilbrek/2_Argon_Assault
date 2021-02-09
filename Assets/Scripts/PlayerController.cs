using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Speed")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 3f;

    [Header("Pitch Control")]
    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 1.88f;
    [SerializeField] float controlYawFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Boundaries")]
    [SerializeField] float xRange = 18f;
    [SerializeField] float yRangeUpper = 7.5f;
    [SerializeField] float yRangeBottom = 9.5f;

    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void OnPlayerDeath()    // called by string reference
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitch =  transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor + xThrow * -controlYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // Setting up Cross Platform Input
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRangeBottom, yRangeUpper);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}