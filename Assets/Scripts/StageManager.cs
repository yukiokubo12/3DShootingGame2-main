using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] float appearNextTime;
    [SerializeField] int maxNumOfPlanes;
    [SerializeField] int maxNumOfTanks;
    public GameObject player;
    public GameObject planePrefab;
    public GameObject tankPrefab;
    private float delta;
    private int numberOfPlanes;
    private int numberOfTanks;

    public GameObject fields;
    public GameObject field1;
    public GameObject field2;
    public GameObject field3;
    public GameObject field4;
    private float offsetZ;

    void Start()
    {
        this.delta = 0;
        numberOfPlanes = 0;
        numberOfTanks = 0;
        this.player = GameObject.Find("Player");
        this.fields = GameObject.Find("Fields");
        this.field1 = GameObject.Find("Field1");
        this.field2 = GameObject.Find("Field2");
        this.field3 = GameObject.Find("Field3");
        this.field4 = GameObject.Find("Field4");
        // this.fields.SetActive(false);
    }

    void Update()
    {
        if(numberOfPlanes >= maxNumOfPlanes)
        {
            return;
        }
        if(numberOfTanks >= maxNumOfTanks)
        {
            return;
        }
        delta += Time.deltaTime;
        //敵の生成間隔
        if(delta > appearNextTime)
        {
            delta = 0f;
            AppearPlane();
            Invoke("AppearTank", 10);
        }
        //フィールドの動的生成
        // this.offsetZ = 100; 
        // if(player.transform.position.z + offsetZ >= field1.transform.position.z)
        // {
        //     this.field1.SetActive(true);
        //     Debug.Log("フィールド1生成");
        // }
        // if(player.transform.position.z + offsetZ <= field2.transform.position.z)
        // {
        //     this.field2.SetActive(true);
        //     Debug.Log("フィールド2生成");
        // }
        // if(player.transform.position.z + offsetZ <= field3.transform.position.z)
        // {
        //     this.field3.SetActive(true);
        //     Debug.Log("フィールド3生成");
        // }
        // if(player.transform.position.z + offsetZ <= field4.transform.position.z)
        // {
        //     this.field4.SetActive(true);
        //     Debug.Log("フィールド4生成");
        // }
    }

    //敵の生成（飛行機）
    void AppearPlane()
    {
        //プレイヤー爆発のとき
        if(player == null) return;

        //飛行機の数指定
        for(int i = 0; i <= 1; i++)
        {
            int offsetX = Random.Range(0, 13);
            int offsetY = Random.Range(0, 13);
            int offsetZ = Random.Range(250, 350);
            GameObject plane = Instantiate(planePrefab);
            // Debug.Log("敵出現");
            numberOfPlanes++;
            delta = 0f;
            plane.transform.position = new Vector3(offsetX, offsetY, this.player.transform.position.z + offsetZ);
        }
    }
    //敵の生成（タンク）
    void AppearTank()
    {
        //プレイヤー爆発のとき
        if(player == null) return;

        //タンクの数指定
        for(int a = 0; a <= 1; a++)
        {
            int offsetX = Random.Range(0, 15);
            int offsetY = -15;
            int offsetZ = Random.Range(250, 350);
            GameObject tank = Instantiate(tankPrefab);
            Debug.Log("タンク出現");
            numberOfTanks++;
            tank.transform.position = new Vector3(offsetX, offsetY, this.player.transform.position.z + offsetZ);
        }
    }
}
