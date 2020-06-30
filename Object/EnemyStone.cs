using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStone : MonoBehaviour {

    public Player player;
    Animator anim;
    float delayTimer = 0f;
    public float startAttackTime = 1.0f;
    FMOD.Studio.EventInstance Stonee;
    FMOD.Studio.ParameterInstance Broken;
    void Awake()
    {
        Stonee = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Stonee");
        Stonee.getParameter("Broken", out Broken);
    }
    // Use this for initialization
    void Start()
    {
        Stonee.start();

        anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당        
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {

        delayTimer += Time.deltaTime;

        if (delayTimer >= startAttackTime)
        {
            float speed = Random.Range(-0.03f, -0.06f);
            transform.Translate(0, speed, 0);
        }
        else
            transform.Translate(0, 0, 0);
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
            anim.SetBool("isAttack", true);
            BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            colls[0].enabled = false; //서있는상태박스false
            colls[1].enabled = true; //서있는상태박스false
            Destroy(gameObject, 0.3f);
            Broken.setValue(1.0f);
        }
        else if (col.gameObject.tag.Equals("Player") && player.isUnBeatTime == false)
        {
            player.HP--;
            anim.SetBool("isAttack", true);
            BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            colls[0].enabled = false; //서있는상태박스false
            Destroy(gameObject, 0.3f);
            Broken.setValue(1.0f);
        }
        else if (col.gameObject.tag.Equals("Player") && player.isUnBeatTime == true)
        {            
            anim.SetBool("isAttack", true);
            BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            colls[0].enabled = false; //서있는상태박스false
            Destroy(gameObject, 0.3f);
            Broken.setValue(1.0f);
        }
        else if (col.gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Scene")
        {
            Destroy(gameObject);
        }
    }
}
