using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start the spawner
    public bool hasStarted = false;
    public GameObject startText;

    // Obstacle
    public GameObject obstacle;  
    // Can the next obstacle spawn?
    private bool canSpawn;
    // Delay between spawns
    [SerializeField]
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            // Press SPACE to start the game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasStarted = true;
                startText.SetActive(false);
            }
        }
        // Spawn the first obstacle and keep spawning it
        if(canSpawn && hasStarted)
            StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        // Only spawn when the previous obstacle has finished (delay set in the inspector)
        canSpawn = false;

        // Choose a random position on the Y axis
        float posY = Random.Range(-2, 2);
        Vector2 pos = new Vector2(gameObject.transform.position.x, posY);
        // Spawn Obstacle on the spawner position at the random Y position
        Instantiate(obstacle, pos, Quaternion.identity);

        // Wait the set amount of time
        yield return new WaitForSeconds(spawnTime);

        canSpawn = true;
    }
}
