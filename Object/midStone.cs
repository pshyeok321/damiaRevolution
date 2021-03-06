﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class midStone : MonoBehaviour
{

    FMOD.Studio.EventInstance GetCristal;

    public Player player;
    float delayTimer = 0f;
    public float dropTime = 0.9f;
    Animator anim;
    void Awake()
    {
        GetCristal = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/GetCristal");
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당
    }

    // Update is called once per frame
    void Update()
    {
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

            player.midStone += 1;
            Destroy(gameObject);
            //BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            //colls[0].enabled = false; //서있는상태박스false        }
        }
    }
}
