using UnityEngine;

public class InvincibilityCell : MonoBehaviour, ICollectibles
{
    [SerializeField] float invincibilityDuration = 2f;

    void ICollectibles.Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.MakeInvincible(invincibilityDuration);
        this.gameObject.SetActive(false);
    }
}
