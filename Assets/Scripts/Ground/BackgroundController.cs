using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Transform cam;
    private Vector2 lastCamPosition;
    [SerializeField]private float parallaxEffect;
    private float sizeOfBg;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        lastCamPosition = cam.position;
        sizeOfBg = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posEffect = cam.position * parallaxEffect;
        Vector2 nextPos = cam.position * (1-parallaxEffect);
        transform.position = new Vector2(lastCamPosition.x + posEffect.x, lastCamPosition.y + posEffect.y);
        if(nextPos.x > lastCamPosition.x + sizeOfBg){
            lastCamPosition.x += sizeOfBg;
        }
    }
}
