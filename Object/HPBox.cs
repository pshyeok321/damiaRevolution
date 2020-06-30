using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBox : MonoBehaviour
{
    FMOD.Studio.EventInstance GetHP;

    public Player player;

    void Awake()
    {
        GetHP = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/GetHP");
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    /*
    
    void OnCollisionEnter2D(Collision2D col)
    {
        // 총알에 닿으면 상자 체력 감소
        if (col.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
        else if(col.gameObject.tag.Equals("Bullet"))
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag.Equals("Bullet2"))
        {
            Destroy(col.gameObject);
        }
    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (player.HP != player.maxHP)
            {
                GetHP.start();
                player.HP++;
                Destroy(gameObject);
            }
            else
            {
                GetHP.start();

                Destroy(gameObject);
            }
        }
    }
}
