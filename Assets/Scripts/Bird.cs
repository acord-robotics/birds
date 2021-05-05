using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition; // Only be accessed inside Bird class
    [SerializeField] private float _launchPower = 250;

    // Resetting scene based on velocity
    private bool birdWasLaunched;
    private float timeSittingAround;

    private void Awake() {
        _initialPosition = transform.position; // Only set on startup

    }

    private void Update() 
    {
        /*GetComponent<LineRenderer>().SetPosition(0, _initialPosition); // Put index 0 (the first item) in the object's line renderer transform.position
        GetComponent<LineRenderer>().SetPosition(1, transform.position); */

        if (birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1) // Reset the scene once bird gameobject stops moving after launch
        {
            timeSittingAround += Time.deltaTime; // Amount of time since last frame - Time.deltaTime
        }

        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10 || timeSittingAround > 3) // Reset to default scene if object moves too high, low, or too far to the right or left
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        //GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white; 
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag() {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
