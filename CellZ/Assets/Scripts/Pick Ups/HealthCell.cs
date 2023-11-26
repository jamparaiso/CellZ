using UnityEngine;

public class HealthCell : MonoBehaviour, ICollectibles
{
    [SerializeField] float healAmount = 0.20f;

    void ICollectibles.Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healAmount);
        this.gameObject.SetActive(false);
    }
}//HealthCell
