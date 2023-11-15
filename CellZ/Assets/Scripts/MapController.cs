using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] float pixelSize = 16f;
    [SerializeField] GameObject player;
    [SerializeField] float checkerRadius;
    
    public List<GameObject> terrainChunks;
    public LayerMask terrainMask;
    public GameObject currentChunk;

    JoyStickController joyStickController;
    Vector3 noTerrainPosition;

    private void Start()
    {
        joyStickController = FindObjectOfType<JoyStickController>();
    }

    private void Update()
    {
        ChunkChecker();
    }

    private void ChunkChecker()
    {
        if (!currentChunk)
        {
          return;
        }

        float xPos = joyStickController.xPos;
        float yPos = joyStickController.yPos;

        if (xPos > 0 && yPos == 0) //right 10
        {
            OverlapCheck(pixelSize,0); 
            SpawnMapChunk();

        }
        else if (xPos < 0 && yPos == 0) //left -10
        {
            OverlapCheck(-pixelSize,0);
            SpawnMapChunk();
        }
        else if (xPos == 0 && yPos > 0) //up 01
        {
            OverlapCheck(0,pixelSize);
            SpawnMapChunk();
        }
        else if (xPos == 0 && yPos < 0) //down 0-1
        {
            OverlapCheck(0,-pixelSize);
            SpawnMapChunk();
        }
        else if (xPos > 0 && yPos > 0) //right up ++
        {
            OverlapCheck(pixelSize,pixelSize);
            SpawnMapChunk();
        }
        else if (xPos > 0 && yPos < 0) //right down +-
        {
            OverlapCheck(pixelSize, -pixelSize); 
            SpawnMapChunk();
        }
        else if (xPos < 0 && yPos > 0) //left up -+
        {
            OverlapCheck(-pixelSize,pixelSize);
            SpawnMapChunk();
        }
        else if (xPos < 0 && yPos < 0) //left down --
        {
            OverlapCheck(-pixelSize,-pixelSize);
            SpawnMapChunk();
        }

    }//chunckchecker

    private void OverlapCheck(float xPos, float yPos)
    {
        Vector3 playerPos = player.transform.position;

        if(!Physics2D.OverlapCircle(playerPos + new Vector3(xPos, yPos, 0), checkerRadius, terrainMask))
        {
            noTerrainPosition = playerPos + new Vector3(xPos,yPos,0);
        }

    }//overlapcheck

    private void SpawnMapChunk()
    {
        int ran = Random.Range(0, terrainChunks.Count);

        Instantiate(terrainChunks[ran], noTerrainPosition, Quaternion.identity);

    }//spawnmapchunk

}//class
