using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    private GameObject player;
    private float difference;

    void Start()
    {
        this.player = GameObject.Find("Player");
        this.difference = player.transform.position.z - this.transform.position.z;
    }

    void Update()
    {
        if(player != null)
        {
        this.transform.position = new Vector3(0, this.transform.position.y, this.player.transform.position.z - difference);
        }
    }
}
