using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerScriptableObject playerData;
    [SerializeField] bool forTesting;

    public float currentMoveSpeed { get; private set; }
    private float currentHealth;
    private float currentDamage;

    [Header("Experience/Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    [SerializeField] float invincibilityDurationSecond = 1.5f;
    private bool isInvincible = false;

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
    }//Start

    public void IncreaseExperience(int exp)
    {
        experience += exp;

        CheckLevelUp();
    }//IncreaseExperince

    private void CheckLevelUp()
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
    }//CheckLevelUp

    public void TakeDamage(float damage)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            KillPlayer();
            //let the game knows the player is dead
            return;
        }

        StartCoroutine(iFrame());
    }//TakeDamage

    private IEnumerator iFrame()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDurationSecond);

        isInvincible = false;

    }

    private void KillPlayer()
    {
        //implement game over here
        Debug.Log("Played Dead");
    }//KillPlayer

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (forTesting)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.SetActive(false);
            }
        }
    }//OnCollisionEnter2D

    private void OnCollisionStay2D(Collision2D collision)
    {

    }//OnCollisionStay2D

    private void OnCollisionExit2D(Collision2D collision)
    {

    }//OnCollisionExit2D

}//PlayerStats
