using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit)
            transform.position = new Vector2(transform.position.x, hit.point.y);
    }
}
