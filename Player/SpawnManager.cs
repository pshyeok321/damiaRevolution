using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public Player player;
    public bool enableSpawn = false;
    public GameObject Enemy; //Prefab을 받을 public 변수 입니다.
    public GameObject Enemy2; //Prefab을 받을 public 변수 입니다.
    public GameObject Enemy3; //Prefab을 받을 public 변수 입니다.
    public GameObject Enemy4; //Prefab을 받을 public 변수 입니다.
    //public GameObject Navi;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(1f, 7f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.

        if (enableSpawn)
        {
            //Instantiate(Enemy
            GameObject temp = Instantiate(Enemy, new Vector3(randomX, -0.47f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.);
            temp.GetComponent<Monster1>().player = this.player;
           
        }
    }
    void SpawnEnemy2()
    {
        float randomX2 = Random.Range(15f, 21f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject temp = Instantiate(Enemy2, new Vector3(randomX2, -0.2f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<Monster2>().player = this.player;

        }
    }
    void SpawnEnemy3()
    {
        float randomX3 = Random.Range(8f, 14f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject temp = Instantiate(Enemy3, new Vector3(randomX3, -0.3f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<Monster3>().player = this.player;

        }
    }
    void SpawnEnemy4()
    {
        float randomX4 = Random.Range(22f, 30f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.
        if (enableSpawn)
        {
            GameObject temp = Instantiate(Enemy4, new Vector3(randomX4, -0.25f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<Monster4>().player = this.player;

        }
    }
  //  void SpawnNavi()
 //   {
  //      float randomX5 = Random.Range(13.8f, 13.9f);
 //       if(enableSpawn)
 //       {
      //      Instantiate(Navi, new Vector3(randomX5, 0.02f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
  //      }
 //   }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 3); //6초후 부터, SpawnEnemy함수를 6초마다 반복해서 실행 시킵니다.
        InvokeRepeating("SpawnEnemy2", 13, 5); //9초후 부터, SpawnEnemy함수를 8초마다 반복해서 실행 시킵니다.
        InvokeRepeating("SpawnEnemy3", 6, 4); //10초후 부터, SpawnEnemy함수를 7초마다 반복해서 실행 시킵니다.
        InvokeRepeating("SpawnEnemy4", 18, 5); //15초후 부터, SpawnEnemy함수를 10초마다 반복해서 실행 시킵니다.
   //     InvokeRepeating("SpawnNavi", 1, 10); //15초후 부터, SpawnEnemy함수를 10초마다 반복해서 실행 시킵니다.
    }
    void Update()
    {

    }

}