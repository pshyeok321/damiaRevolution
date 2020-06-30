using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pt3sc : MonoBehaviour {
    //public bool R1, R2, R3, R4;
    public Player player;
    //public Vector2 speed;
    //public float shootTime = 2f;
    //public Rigidbody2D rb;
    //public int RD = Random.Range(-50, -20);


    public float delayTimer = 0f;
    public float startAttackTime = 3.0f;

    // Use this for initialization
    void Start () {
   //     rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        //player2 = Transform.FindObjectOfType("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update () {

        delayTimer += Time.deltaTime;
        if (delayTimer >= startAttackTime)
        {
            float speed = Random.Range(-0.1f, -0.03f);
            transform.Translate(speed, 0, 0);
        }
        //else
            //transform.Translate(0, 0, 0);
        //if (shootTime > Time.deltaTime)
        //{
            //rb.velocity = speed * -RD;
        //}
        //else rb.velocity = speed;
       
    }

}
