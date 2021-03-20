using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPos;
    public float speed = 20000f;
    AudioSource audioSource;
    public AudioClip playerBulletSound;

    private float interval = 0.2f;
    private float time = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) && time <= 0f)
        {
            GameObject bullets = Instantiate(bullet) as GameObject;
            time = interval;
            bullets.transform.position = bulletPos.transform.position;
            // Debug.Log("弾発射");
            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            audioSource.PlayOneShot(playerBulletSound);
            Destroy(bullets, 1.5f);
        }
        if(time > 0f)
        {
            time -= Time.deltaTime;
        }
    }
}
