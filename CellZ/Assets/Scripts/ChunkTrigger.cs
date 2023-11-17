using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mapController;
    [SerializeField] GameObject targetMap;
    
    private void Start()
    {
        mapController = FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //check and assign which map chunk the player is
        if (collision.CompareTag("Player"))
        {
            mapController.currentChunk = targetMap;
        }
    }//ontriggerstay

    private void OnTriggerExit2D(Collider2D collision)
    {
        //clear the current chunk when the player exits
        if (collision.CompareTag("Player"))
        {
            if(mapController.currentChunk == targetMap)
            {
                mapController.currentChunk = null;
            }
        }
    }

}//class
