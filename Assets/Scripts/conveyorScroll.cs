using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorScroll : MonoBehaviour
{
    public float scrollSpd;
    void Update()
    {
        GetComponent<SpriteRenderer>().material.mainTextureOffset = new Vector2(-1 * scrollSpd * Time.time, 0);
    }
}
