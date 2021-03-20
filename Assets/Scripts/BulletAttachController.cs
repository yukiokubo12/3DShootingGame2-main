using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttachController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "PlaneTag" || other.gameObject.tag == "TankPrefab")
            {
                Destroy(this.gameObject);
            }
        }
}
