using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    //yys listeri mej petq linen aydn obyektery vorornq peteq e spawn anel
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private List<GameObject> collectiblePrefabs;

    //scenayi mej ays gemobyektenri mey khavaqven bolor stexcvac obueknery 
    [SerializeField] private Transform obstacleHolder;
    [SerializeField] private Transform collectibleHolder;

    //ayn keteric vortexic petq e skskel genreraclen 
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    //y ov sahamapakumnery 
    [SerializeField] private Transform maxYPoint;
    [SerializeField] private Transform minYPoint;

    //sranov kareli e kargavorlel setexcvleu xtutyuny 
    [SerializeField] private int spawnInterval;


    public void Start()
    {
        //ayd tex vercnum enq sksnakan eve verjanakan x positina amboxj tiv darcnelov
        int endX = Mathf.FloorToInt(endPoint.position.x);
        int startX = Mathf.FloorToInt(startPoint.position.x);
        
        
        for (int i = startX; i < endX; i += spawnInterval)
        {
            //y hamar patahakan tive e stacvum ayd range-um
            float randomY = Random.Range(minYPoint.position.y, maxYPoint.position.y);
            Vector3 spawnPosition = new Vector3(i, randomY, 0);
            
            //stexcum e obyekty 
            SpawnObstacle(spawnPosition);
            
            //ays hatvacy petq e ete petq e inch vor havanakanutyamb steccel petkakan obyekten ev xochndotnerl 
            /*if (Random.value > 0.5f)
            {
                SpawnObstacle(spawnPosition);
            }
            else
            {
                SpawnCollectible(spawnPosition);
            }*/
        }
    }

    private void SpawnObstacle(Vector3 position)
    {
        if (obstaclePrefabs.Count == 0) return;

        int randomIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject obstacle = Instantiate(obstaclePrefabs[randomIndex], position, Quaternion.identity, obstacleHolder);
    }

    private void SpawnCollectible(Vector3 position)
    {
        if (collectiblePrefabs.Count == 0) return;

        int randomIndex = Random.Range(0, collectiblePrefabs.Count);
        GameObject collectible = Instantiate(collectiblePrefabs[randomIndex], position, Quaternion.identity,
            collectibleHolder);
    }
}