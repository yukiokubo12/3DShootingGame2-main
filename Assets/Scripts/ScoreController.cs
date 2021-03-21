using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        // this.scoreText = GameObject.Find("ScoreText");
        score = 0;
        SetScore();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlaneTag" || other.gameObject.tag == "TankTag")
        {
           score += 1;
        }
        SetScore();
    }

    public void SetScore()
    {
        this.scoreText.text = string.Format("{0} Hits", score);
    }
}
