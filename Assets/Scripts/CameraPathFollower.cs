using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPathFollower : CarCameraComponent
{
    [SerializeField] private Transform path;
    [SerializeField] private Transform lookTarget;
    [SerializeField] private float movmentSpeed;

    private Vector3[] points;
    private int pointsIndex;

    private void Start()
    {
        points = new Vector3[path.childCount];

        for(int i = 0; i < points.Length; i++)
        {
            points[i] = path.GetChild(i).position;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[pointsIndex], movmentSpeed * Time.deltaTime);

        if(transform.position == points[pointsIndex])
        {
            if(pointsIndex == points.Length - 1)
            {
                pointsIndex = 0;
            }
            else
            {
                pointsIndex++;
            }
        }
        transform.LookAt(lookTarget);
    }

    public void StartMoveToNearestPoint()
    {
        float minDistance = float.MaxValue;

        for(int i = 0; i < points.Length;i++)
        {
            float distance = Vector3.Distance(transform.position, points[i]);
            
            if(distance < minDistance)
            {
                minDistance = distance;
                pointsIndex = i;
            }

        }
    }

    public void SetLookTarget(Transform target)
    {
        lookTarget = target;
    }

}
