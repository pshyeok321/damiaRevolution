using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowStone : MonoBehaviour {
    FMOD.Studio.EventInstance GetCristal;

    public Player player;
    Animator anim;
    float delayTimer = 0f;
    public float dropTime = 0.9f;
    void Awake()
    {
        GetCristal = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/GetCristal");
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당

    }

    // Update is called once per frame
    void Update () {
        delayTimer += Time.deltaTime;

        anim.SetBool("isDrop", true);
        if (delayTimer > dropTime)
        {
            anim.SetBool("isDrop", false);
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetCristal.start();

            player.lowStone += 1;
            Destroy(gameObject);
            //BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            //colls[0].enabled = false; //서있는상태박스false

        }
    }
}
