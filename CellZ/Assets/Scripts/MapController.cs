using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    JoyStickController playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<JoyStickController>();
    }

    private void Update()
    {
        ChunkChecker();
    }

    private void ChunkChecker()
    {
        if (playerMovement.transform.position.x > 0 && playerMovement.transform.position.y == 0)
        {
            Debug.Log("player moved");
        }

    }

}//class
