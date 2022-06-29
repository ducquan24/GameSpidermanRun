using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    public Transform ground;
    private int goalPoint = 0;
    public float speedForce;
    // Start is called before the first frame update
    void Start()
    {
        speedForce = 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        ground.position = Vector2.MoveTowards(ground.position, points[goalPoint].position, speedForce * Time.deltaTime);
        if(Vector2.Distance(ground.position, points[goalPoint].position) < 0.1f){
            if(goalPoint == points.Count - 1){
                goalPoint = 0;
            }else{
                goalPoint++;
            }
        }
    }
}
