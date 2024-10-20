using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOrbit : MonoBehaviour
{
    public float orbitSpeed = 1f;
    public float orbitRadius = 5f;
    private float angle = 2f;
    public Transform centerObject; // The object to orbit around
    public float heightOffset = 0f; // Vertical offset from the center object

    private Vector3 initialRelativePosition;


    // Start is called before the first frame update
    void Start()
    {
        if (centerObject == null)
        {
            Debug.LogError("Center object is not assigned. Please assign a GameObject to orbit around in the inspector.");
            enabled = false; // Disable the script if no center object is assigned
            return;
        }

        // Store the initial relative position
        initialRelativePosition = transform.position - centerObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        // angle += orbitSpeed * Time.deltaTime;

        // Vector3 orbit = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * orbitRadius;

        // transform.position = orbit;

        if (centerObject != null)
        {
            // Increment the angle
            angle += orbitSpeed * Time.deltaTime;

            // Calculate the new position
            Vector3 orbit = new Vector3(
                Mathf.Cos(angle) * orbitRadius,
                heightOffset,
                Mathf.Sin(angle) * orbitRadius
            );

            // Set the new position relative to the center object
            transform.position = centerObject.position + orbit;

            // Optional: Make the object face the direction of movement
            if (orbitSpeed != 0)
            {
                transform.LookAt(transform.position + transform.position - centerObject.position);
            }
        }
    }
}
