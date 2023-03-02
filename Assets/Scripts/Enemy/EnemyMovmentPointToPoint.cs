using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentPointToPoint : MonoBehaviour
{
    [SerializeField] private float speedScalar = 2f;
    [SerializeField] private Transform[] teravelPoints;

    private float teravelProcent = 0f;
    private int currentPointIndex, nextPointIndex;

    private void Awake()
    {
        if (!teravelPoints[0]) return;
        transform.position = teravelPoints[0].position;
        currentPointIndex = 0;
        nextPointIndex = currentPointIndex + 1;
    }

    private void Update()
    {
        ProccesMove();
    }

    private void ProccesMove()
    {
        teravelProcent += speedScalar * Time.deltaTime;
        teravelProcent = Mathf.Clamp(teravelProcent, 0f, 1f);
        transform.position = Vector3.Lerp(teravelPoints[currentPointIndex].position, teravelPoints[nextPointIndex].position, teravelProcent);
        if(teravelProcent >= 1f - Mathf.Epsilon)
        {
            GetNextPoint();
        }
    }

    private void GetNextPoint()
    {

        if(nextPointIndex == teravelPoints.Length - 1)
        {
            currentPointIndex = teravelPoints.Length - 1;
            nextPointIndex = 0;
            teravelProcent = 0f;
        }
        else
        {          
            nextPointIndex += 1;
            currentPointIndex = nextPointIndex - 1;
            teravelProcent = 0f;
        }

    }
}
