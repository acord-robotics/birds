using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;

    //private float timeAfterDeaths = 2.5;
    
    private Enemy[] _enemies; // Array of enemies

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies) // Loop through all enemies to see when they're dead
        {
            if (enemy != null) // If enemy is not dead - it still exists (so doesn't present null)
            {
                return; // We still have an enemy alive
            }

            Debug.Log("You killed all enemies");

            WaitForSeconds(2.5);

            _nextLevelIndex++;
            string nextLevelName = "Level" + _nextLevelIndex;
            SceneManager.LoadScene(nextLevelName);
        }
    }
}