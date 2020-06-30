using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverControl : MonoBehaviour
{

    public Vector2 speed;

    Rigidbody2D rb;
    new SpriteRenderer renderer; // 스프라이트렌더러 변수 선언


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //spriterenderer 변수 선언
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity = speed;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //총알이 벽에 닿으면 삭제
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Ground")
        {
            renderer.color = new Color32(255, 255, 255, 0);
            //EdgeCollider2D[] colls = gameObject.GetComponents<EdgeCollider2D>(); //박스2개선언
            //colls[0].enabled = false;
            //colls[1].enabled = true;
            Destroy(gameObject, 0.53f);
        }
        else if(col.gameObject.tag == "Enenmy")
        {
            renderer.color = new Color32(255, 255, 255, 0);
            //EdgeCollider2D[] colls = gameObject.GetComponents<EdgeCollider2D>(); //박스2개선언
            //colls[0].enabled = false;
            //colls[1].enabled = true;
            Destroy(col.gameObject);
            //Destroy(gameObject, 0.5f);
        }
        else if (col.gameObject.tag == "EnenmyBullet")
        {
            renderer.color = new Color32(255, 255, 255, 0);
            //EdgeCollider2D[] colls = gameObject.GetComponents<EdgeCollider2D>(); //박스2개선언
            //colls[0].enabled = false;
            //colls[1].enabled = true;
            Destroy(col.gameObject);
            //Destroy(gameObject, 0.5f);
        }
    }

}
