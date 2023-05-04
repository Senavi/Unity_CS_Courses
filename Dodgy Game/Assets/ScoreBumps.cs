using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBumps : MonoBehaviour
{
[SerializeField] public Text ScoreField;


public int maxHealth = 100;
public int currentHealth;
public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
    healthBar.SetMaxHealth(maxHealth);
    currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }


int hits;
public void OnCollisionEnter(Collision other)
{
    hits++;
    ScoreField.text = hits.ToString();
    TakeDamage(5);
    Debug.Log("Your're health is: " + currentHealth);

}

public void TakeDamage(int Damage)
{
    currentHealth -= Damage;
    healthBar.SetHealth(currentHealth);
}



}
