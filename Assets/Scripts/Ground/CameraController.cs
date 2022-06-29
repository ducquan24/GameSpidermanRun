using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [Range(0.0f, 5.0f)]public float offsetX;
    [Range(0.0f, 5.0f)]public float offsetY;
    [Range(0.0f, 5.0f)]public float smoothFactor;
    // Start is called before the first frame update
    void Start()
    {
        offsetX = 2f;
        offsetY = 1f; 
        smoothFactor = 4f;
    }

    private void FixedUpdate() {
        Vector3 targetPosition = new Vector3(transform.position.x + offsetX, target.position.y + offsetY, transform.position.z);
        Vector3 smoothMove = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        Vector3 cameraMove = new Vector3(smoothMove.x, 0f, smoothMove.z);
        transform.position = cameraMove;
    }
}
