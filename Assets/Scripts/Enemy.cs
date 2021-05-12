using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision) { // Pass on collision info (packet) when the monster object collides with other objects(with colliders)
        Bird Bird = collision.collider.GetComponent<Bird>();
        if (Bird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity); // Instantiate the cloud where the enemy is
            Destroy(gameObject); // If collided with bird game object
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            return; // Exit out of method
        }

        if (collision.contacts[0].normal.y < - 0.5)  // Reference the first collision contact
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // If get hit from the top by an object, kill the enemy
        }
    }
}
