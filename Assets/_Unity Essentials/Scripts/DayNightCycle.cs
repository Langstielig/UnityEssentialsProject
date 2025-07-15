using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private float dayDuration = 60.0f; // Duration of a day in seconds

    private float rotationSpeed;

    void Start()
    {
        // Calculate the rotation speed based on the day duration
        rotationSpeed = 360.0f / dayDuration;
    }

    void Update()
    {
        // Rotate the light around the Y-axis to simulate the day passing
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
