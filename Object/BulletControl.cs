using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    FMOD.Studio.EventInstance Hearted;

    public Vector2 speed;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
	}
    void Awake()
    {
        Hearted = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Heart");
    }
    // Update is called once per frame
    void Update () {
        rb.velocity = speed;
    } 
    private void OnCollisionEnter2D(Collision2D col)
    {
        //총알이 벽에 닿으면 삭제
        if(col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        //총알이 몬스터총알에 닿아도 우리총말만 삭제
    else if(col.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Enemy")
        {
            Hearted.start();
        }
        else if (col.gameObject.tag == "Enemy2")
        {
            Hearted.start();
        }
    }

}
