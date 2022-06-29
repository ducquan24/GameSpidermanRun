using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float  COUNT = 65f;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;
    void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        SpawnLevelPart();
        
    }
    private void SpawnLevelPart(){
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        StartCoroutine(DestroyGround(40f, lastLevelPartTransform.gameObject));
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 position){
        Transform levelPartTransform = Instantiate(levelPart, position, Quaternion.identity);
        return levelPartTransform;
    }
    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, lastEndPosition) < COUNT){
            SpawnLevelPart();
        }
    }

    IEnumerator DestroyGround(float timeDestroy, GameObject objectDestroy){
        yield return new WaitForSeconds(timeDestroy);
        Destroy(objectDestroy);
    }
}
