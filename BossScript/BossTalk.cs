using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTalk : MonoBehaviour {
    public GameObject Skip;
    public GameObject Next, Nex2, Nex3, Nex4;
    public GameObject Back;
    public GameObject booltoo;
    public GameObject D1, D2, D3, D4;
    public GameObject DaeHwa;

    public Player player;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    //public GameObject NomalPanel;
    // Use this for initialization
    void Start () {        
        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update () {
    //    if (player.stage3map)
      //  {

       // }
	}
    public void Next1()
    {
        D1.SetActive(false);
        D2.SetActive(true);
        Next.SetActive(false);
        Nex2.SetActive(true);
    }
    public void Next2()
    {
        D2.SetActive(false);
        D3.SetActive(true);
        Nex2.SetActive(false);
        Nex3.SetActive(true);
    }
    public void Next3()
    {
        D3.SetActive(false);
        D4.SetActive(true);
        Nex3.SetActive(false);
        Nex4.SetActive(true);
    }
    public void Next4()
    {        
        D4.SetActive(false);
        booltoo.SetActive(false);
        Skip.SetActive(false);
        Nex4.SetActive(false);
        Back.SetActive(false);
        Destroy(DaeHwa);
        Time.timeScale = 1.0f;
    }
    public void Skip1()
    {
        D2.SetActive(false);
        D1.SetActive(false);
        D3.SetActive(false);
        D4.SetActive(false);
        booltoo.SetActive(false);
        Skip.SetActive(false);
        Nex4.SetActive(false);
        Back.SetActive(false);
        Destroy(DaeHwa);
        Time.timeScale = 1.0f;
    }
}
