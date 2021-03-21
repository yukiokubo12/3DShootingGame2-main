using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletPos;
    public float speed = 20000f;
    AudioSource audioSource;
    public AudioClip playerBulletSound;

    private float interval = 0.2f;
    private float time = 0f;

    public int maxMp;
    public double currentMp;
    public Slider playerMPSlider;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // MP
        this.playerMPSlider.value = 1;
        this.maxMp = 50;
        this.currentMp = this.maxMp;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) && time <= 0f)
        {
            GameObject bullets = Instantiate(bullet) as GameObject;
            int attack = 10;
            this.currentMp -= attack;
            playerMPSlider.value = (float)currentMp / maxMp;
            time = interval;
            bullets.transform.position = bulletPos.transform.position;
            // Debug.Log("弾発射");
            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            audioSource.PlayOneShot(playerBulletSound);
            Destroy(bullets, 1.5f);

        }
        // this.seconds += Time.deltaTime;
        if(this.currentMp <= maxMp)
        {
            Invoke("RecoverMp", 1);
            playerMPSlider.value = (float)currentMp / maxMp;
        }
        if(this.currentMp >= maxMp)
        {
            this.currentMp = maxMp;
            this.playerMPSlider.value = 1;
        }
        if(this.currentMp <= 0)
        {
            this.currentMp = 0;
            this.playerMPSlider.value = 0;
            MPCoroutine();
            Invoke("RecoverMp", 1);
        }
        if(time > 0f)
        {
            time -= Time.deltaTime;
        }
    }
    void RecoverMp()
    {
        this.currentMp += 0.01;
        playerMPSlider.value = (float)currentMp / maxMp;
    }
    IEnumerator MPCoroutine()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(10.0f);
        this.gameObject.SetActive(true);
    }
}
