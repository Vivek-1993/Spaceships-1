﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spaceship : MonoBehaviour
{
    public GameObject healthBar;
    public float maxHealth;
    public float damageUFOLaser;
    public float healthPack;
    float currentHealth;
    float healthBarSize;
    float centerHealthBar;
    float healthGained;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "UFOLaser")
        {
            if (currentHealth > 0)
            {
                currentHealth -= damageUFOLaser;
                centerHealthBar = damageUFOLaser / (maxHealth * 2); // health bar needs to move this much to the right to stay in same position
                healthBarSize = currentHealth / maxHealth;
                //scaling health bar for lost life
                healthBar.transform.localScale = new Vector3(healthBarSize, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
                //keeping health bar in same position
                healthBar.transform.localPosition = new Vector3(healthBar.transform.localPosition.x - centerHealthBar, healthBar.transform.localPosition.y, healthBar.transform.localPosition.z);
                //Destroy laser upon collision
                Destroy(col.gameObject);
            }
            else
            {
                Debug.Log("Game Over");
            }
        }
        else if (col.gameObject.tag == "HealthPack")
        {
            if ((currentHealth + healthPack) > maxHealth)
            {
                healthGained = maxHealth - currentHealth;
            }
            else
            {
                healthGained = healthPack;
            }
            currentHealth += healthGained;
            centerHealthBar = healthGained / (maxHealth * 2);
            healthBarSize = currentHealth / maxHealth;
            //scaling health bar for gained life
            healthBar.transform.localScale = new Vector3(healthBarSize, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            //keeping health bar in same position
            healthBar.transform.localPosition = new Vector3(healthBar.transform.localPosition.x + centerHealthBar, healthBar.transform.localPosition.y, healthBar.transform.localPosition.z);
            //Destroy health pack upon collision
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Star")
        {
            SceneManager.LoadScene("LevelComplete", LoadSceneMode.Single);
        }
        Debug.Log("Current Health " + currentHealth);
    }

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
