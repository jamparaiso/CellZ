using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    JoyStickController joyStickController;
    Vector3 noTerrainPosition;
    float optimizerCooldown;


    [SerializeField] GameObject player;
    [SerializeField] float checkerRadius;
    
    public List<GameObject> terrainChunks;
    public LayerMask terrainMask;
    public GameObject currentChunk;

    [Header("Optimization")]
    public List<GameObject> spawnedMaps;
    [SerializeField] float maxDistance = 70f;
    [SerializeField] float optimizerDuration = 1f;



    private void Start()
    {
        joyStickController = FindObjectOfType<JoyStickController>();
    }

    private void Update()
    {
        ChunkChecker();
        MapOptimizer();
    }

    private void ChunkChecker()
    {
        //check if there is a spawned map on the location
        if (!currentChunk)
        {
            return;
        }

        float xPos = joyStickController.xPos;
        float yPos = joyStickController.yPos;

        if (xPos > 0 && yPos > 0) //right up ++
        {
            OverlapCheck("Up");
            OverlapCheck("Right");
            OverlapCheck("RightUp");

        }
        else if (xPos > 0 && yPos < 0) //right down +-
        {
            OverlapCheck("Down");
            OverlapCheck("Right");
            OverlapCheck("RightDown"); 
        }
        else if (xPos < 0 && yPos > 0) //left up -+
        {
            OverlapCheck("Up");
            OverlapCheck("Left");
            OverlapCheck("LeftUp");
        }
        else if (xPos < 0 && yPos < 0) //left down --
        {
            OverlapCheck("Down");
            OverlapCheck("Left");
            OverlapCheck("LeftDown");
        }

    }//chunckchecker

    private void OverlapCheck(string toFind)
    {
        Vector3 _currentChunk = currentChunk.transform.Find(toFind).position;

        if(!Physics2D.OverlapCircle(_currentChunk, checkerRadius, terrainMask))
        {
            noTerrainPosition = _currentChunk;

            SpawnMapChunk();
        }

    }//overlapcheck

    private void SpawnMapChunk()
    {
        int ran = Random.Range(0, terrainChunks.Count);

        GameObject mapChunk;

        mapChunk = Instantiate(terrainChunks[ran], noTerrainPosition, Quaternion.identity);
        spawnedMaps.Add(mapChunk);

    }//spawnmapchunk

    private void MapOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerDuration;
        }
        else
        {
            return;
        }

        foreach (GameObject map in spawnedMaps)
        {
            float distance = Vector3.Distance(player.transform.position, map.transform.position);
            if(distance > maxDistance)
            {
                map.SetActive(false);
            }
            else
            {
                map.SetActive(true);
            }
        }
    }

}//class
