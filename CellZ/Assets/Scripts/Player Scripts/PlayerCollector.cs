using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    //script for drops collections

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drops")
        {
            if(collision.gameObject.TryGetComponent(out ICollectibles collectibles))
            {
                collectibles.Collect();
            }
        }
    }//OnTriggerEnter2D

}//class
