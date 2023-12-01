using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TextMeshProUGUI lifeText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI expCapText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance == null)
        {
            Instance = null;
        }
    }

    private void Update()
    {
        UpdatePlayerStats();
    }

    private void UpdatePlayerStats()
    {
        lifeText.text = "Life: " + playerStats.currentHealth.ToString();
        levelText.text = "Level: " + playerStats.level.ToString();
        expText.text = "Exp: " + playerStats.experience.ToString();
        expCapText.text = "Exp Cap: " + playerStats.experienceCap.ToString();
    }


}//GameManager
