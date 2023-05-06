using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{

[SerializeField] float moveSpeed = 10f;
[SerializeField] ScoreBumps scoreBumps;
[SerializeField] int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CharacterControll();
        Debug.Log(Time.time);

    }

    void CharacterControll()
    {
        float xValue = Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        float zValue = Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;
        transform.Translate(xValue, 0,zValue);
    }

        void OnCollisionEnter(Collision other)
{
    if(other.collider.CompareTag("Hitted"))
    return;

    scoreBumps.AddHit();
    scoreBumps.TakeDamage(damage);
    scoreBumps.UpdateScoreText();
    

}

}
