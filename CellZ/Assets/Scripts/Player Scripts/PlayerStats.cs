using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerScriptableObject playerData;

    public float currentMoveSpeed { get; private set; }
    private float currentHealth;
    private float currentDamage;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [System.Serializable]
    public class LevelRange 
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    public List<LevelRange> levelRanges;

    

    // Start is called before the first frame update
    private void Start()
    {
        currentMoveSpeed = playerData.MoveSpeed;
        currentHealth = playerData.MaxHealth;
        currentDamage = playerData.Damage;

        experienceCap = levelRanges[0].experienceCapIncrease; // initialise the first level cap
    }

    public void IncreaseExperince(int exp)
    {
        experience += exp;

        CheckLevelUp();
    }

    public void CheckLevelUp()
    {
        if (experience >= experienceCap)
        {
            level++;

            //deduct the experiencecap and assign the difference back to exp
            //any excess exp will be counted for the next level
            experience -= experienceCap;

            int expCap = 0;
            foreach (LevelRange range in levelRanges)
            {
                //select the experience cap increase base on the level of the player
                //e.g. 1-2 exp cap 100 / 3-4 exp cap 200 
                if(level >= range.startLevel && level <= range.endLevel)
                {
                    expCap = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += expCap;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            collision.gameObject.SetActive(false);
        }
    }
}
