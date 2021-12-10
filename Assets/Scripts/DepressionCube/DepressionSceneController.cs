using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionSceneController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 5.0f;
    private float startTime;
    private float flightDistance;

    private void Start()
    {
        startTime = Time.time;
        flightDistance = Vector3.Distance(startPoint.position, endPoint.position);
    }

    IEnumerator ShootTheCube()
    {
        float distanceFlied = (Time.time - startTime) * speed;
        float flightFraction = distanceFlied / flightDistance;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, flightFraction);
        yield return null;
    }
}
