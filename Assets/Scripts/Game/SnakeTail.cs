using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;

    public List<Transform> snakeCircles = new List<Transform>();
    public List<Vector3> positions = new List<Vector3>();
    public List<Transform> snakeCirclesReverse = new List<Transform>();

    private void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    private void Update()
    {

        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            // ??????????? ?? ??????? ????????? ??????, ? ??????
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            //snakeCircles[i].position = Vector3.MoveTowards(positions[i+1], positions[i], distance/ CircleDiameter);
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {

        Destroy(snakeCircles[0].gameObject);
        snakeCircles.RemoveAt(0);
        positions.RemoveAt(1);



    }

}
