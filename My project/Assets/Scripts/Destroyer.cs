using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Destroy timer is different per GameObject this script is attached to
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy THIS GameObject in the set amount of time (seconds)
        Destroy(gameObject, timer);
    }
}
