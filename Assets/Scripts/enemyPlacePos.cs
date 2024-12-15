using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPlacePos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(250, Random.value * 40);
    }
}
