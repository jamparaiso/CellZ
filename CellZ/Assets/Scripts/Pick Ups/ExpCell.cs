using UnityEngine;

public class ExpCell : MonoBehaviour, ICollectibles
{
    [SerializeField] int experience;

    void ICollectibles.Collect()
    {
        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.IncreaseExperience(experience);
        this.gameObject.SetActive(false);
    }

}//class
