using UnityEngine;

public class FoodController : MonoBehaviour
{
    void OnColliderEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Respawn the food at a random location
            Respawn();
        }
    }

    void Respawn()
    {
        // Find the ground object
        GameObject ground = GameObject.FindWithTag("Ground");

        // Get the size of the ground object
        Vector3 groundSize = ground.GetComponent<Renderer>().bounds.size;

        // Generate a random position within the ground's dimensions
        // Assuming the ground's center is at (0, 0, 0), we generate a position from -halfSize to +halfSize
        float x = Random.Range(-groundSize.x / 2, groundSize.x / 2);
        float y = 1f; // Adjust this value as per your need
        float z = Random.Range(-groundSize.z / 2, groundSize.z / 2);

        // Set the food's position to the new random position
        transform.position = new Vector3(x, y, z);
    }
}
