using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class HealthSystem {
    private float maxHealth;
    private float currentHealth;
    private bool isDead;
    float timer = 0.0f;
    private GameObject player = GameObject.Find("Queen");
    private BarScript bar;
    

    // Use this for initialization
    public HealthSystem()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getHealth()
    {
        return currentHealth;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    public void setHealth(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public bool deathCheck()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
        return isDead;
    }

    public void healthbarUpdate()
    {
        
        bar = player.GetComponent<Player>().getBarScript();
        bar.Value = currentHealth;
        bar.MaxValue = maxHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void applyDamage(int damage)
    {
        currentHealth = currentHealth - damage;
    }

    public void regeneration()
    {
        if (currentHealth < maxHealth)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 5.0f)
        {
            currentHealth += 2;
            timer = 0f;
        }
    }
}
