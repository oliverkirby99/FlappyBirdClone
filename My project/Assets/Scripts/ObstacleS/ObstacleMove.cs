using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    // Get the rigidbody and get the speed value
    private Rigidbody2D rb2d;
    [SerializeField]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Set rigidbody
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move left at the set speed
        rb2d.velocity = new Vector2(-moveSpeed, 0);
    }
}
