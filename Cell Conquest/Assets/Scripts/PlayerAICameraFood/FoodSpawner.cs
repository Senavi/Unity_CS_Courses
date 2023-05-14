using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public int initialFoodCount = 20;

    void Start()
    {
        for (int i = 0; i < initialFoodCount; i++)
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        // Find the ground object
        GameObject ground = GameObject.FindWithTag("Ground");

        // Get the size of the ground object
        Vector3 groundSize = ground.GetComponent<Renderer>().bounds.size;

        // Generate a random position within the ground's dimensions
        float x = Random.Range(-groundSize.x / 2, groundSize.x / 2);
        float y = 1f; // Adjust this value as per your need
        float z = Random.Range(-groundSize.z / 2, groundSize.z / 2);

        // Spawn a new food object at the random position
        Instantiate(foodPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}
