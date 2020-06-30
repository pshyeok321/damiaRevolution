using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour {
    public Vector2 speed;
    public Player player;
    Rigidbody2D rb;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        //player2 = Transform.FindObjectOfType("Player").GetComponent<Player>();
    }
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed; // 총알 속도 설정
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player") && player.isUnBeatTime == false)
        {
            --player.HP;
            player.StartCoroutine("Unbeattime");
            Destroy(gameObject);
        }
        else if (col.gameObject.tag.Equals("Player") && player.isUnBeatTime == true)
        {
        }
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 벽에 닿아도 삭제
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }        
       // 점프오브젝트에 닿아도 삭제
        else if (col.gameObject.tag == "Jump")
        {
            Destroy(gameObject);
        }
        // 아이템상자에 닿아도 삭제
        else if (col.gameObject.tag == "Item")
        {
            Destroy(gameObject);
        }
        // 땅에 닿아도 삭제
        else if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
        else if (col.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Fever")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Scene")
        {
            Destroy(gameObject);
        }
    }
}
