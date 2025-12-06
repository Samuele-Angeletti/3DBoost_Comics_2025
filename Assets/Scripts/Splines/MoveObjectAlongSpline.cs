using System;
using UnityEngine;
using UnityEngine.Splines;

public class MoveObjectAlongSpline : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;
    [SerializeField] float maxSpeed = 1;
    [SerializeField] float accelerationSpeed = 1f;
    [SerializeField] AnimationCurve accelerationCurve;

    float distancePercentage = 0;
    float splineLength = 0;
    float currentSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        splineLength = splineContainer.CalculateLength();
    }

    // Update is called once per frame
    void Update()
    {
        distancePercentage += GetSpeed() * Time.deltaTime;

        // se vado oltre la "linea di partenza"
        if (distancePercentage > 1)
        {
            // torno a 0
            distancePercentage = 0;
        }

        Vector3 position = splineContainer.EvaluatePosition(distancePercentage);

        transform.position = position;

        Vector3 nextPosition = splineContainer.EvaluatePosition(distancePercentage + 0.05f);
        Vector3 directionRotation = nextPosition - position;
        transform.rotation = Quaternion.LookRotation(directionRotation, transform.up);
    }

    private float GetSpeed()
    {
        float t = currentSpeed / maxSpeed;

        float curveFactor = accelerationCurve.Evaluate(t + 0.01f);

        currentSpeed += accelerationSpeed * curveFactor * Time.deltaTime;

        if (currentSpeed > maxSpeed)
            currentSpeed = maxSpeed;

        return currentSpeed;
    }
}
