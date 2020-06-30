using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour {
    public int maxHP = 10;
    int HP = 10;

	// Use this for initialization
	void Start () {
        HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        // 총알에 닿으면 상자 체력 감소
        if(col.gameObject.tag.Equals("Bullet") && HP>1)
        {
            HP = HP - 1;
            Destroy(col.gameObject);
        }
        // 체력이 다 달면 상자 파괴
        else if(col.gameObject.tag.Equals("Bullet") && HP==1)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag.Equals("Bullet2") && HP > 1)
        {
            HP = HP - 1;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag.Equals("Bullet2") && HP == 1)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
