using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBumps : MonoBehaviour
{
    
[SerializeField] Text ScoreField;
[SerializeField] private int maxHealth = 100;
[SerializeField] private HealthBar healthBar;

private int hits;
private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
    healthBar.SetMaxHealth(maxHealth);
    currentHealth = maxHealth;
    }


public void TakeDamage(int Damage)
{
    currentHealth -= Damage;
    healthBar.SetHealth(currentHealth);
    Debug.Log("Your're health is: " + currentHealth);
}

public void AddHit()
{
    hits++;
}

public void UpdateScoreText()
{
    ScoreField.text = hits.ToString();
}
}
