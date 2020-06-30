using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    public GameObject gold;
    public GameObject[] items = new GameObject[3];
    Transform trans;
    public Player player;
    public float maxHP = 150; // 목숨
    public float HP = 150;
    Animator anim;
    static public bool isAttack;
    // 총알 무한 발사 제한을 위한 시간 변수들
    float delayTimer = 0f;
    public float shootDelayTime = 4.0f;    
    float delayTimer2 = 0f;
    public float startAttackTime = 2.0f;
    public GameObject pattern1,pattern2, pattern3;    
    
    // Transform Monster5FirePos;
    public GameObject explo, explo2, explo3, explo4, explo5; // 폭발 프리펩

    public Transform FirePos, FirePos2, FirePos3, FirePos4;

    //   Transform Monster5FirePos, Monster5FirePos2; // 총알이 나가는 위치
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
        HP = maxHP; // 시작시 목숨 설정
        anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당

        FirePos = transform.Find("FirePos"); //오른쪽총알나가는곳
        FirePos2 = transform.Find("FirePos2"); //왼쪽총알나가는곳        
        FirePos3 = transform.Find("FirePos3"); //왼쪽총알나가는곳     
        FirePos4 = transform.Find("FirePos4"); //왼쪽총알나가는곳     

        //Monster5FirePos = transform.Find("Monster5FirePos");        
        //InvokeRepeating("Attack", 1, 2); // 야쿠쿠가 공격모션시작
        //Invoke("RandomAttack", 0.1f);
    }
    // Update is called once per frame
    void Update()
    {
        Last();


        delayTimer2 += Time.deltaTime;
        if (!player.RB6 && !player.RB7 && !player.RB8)
            Destroy(GameObject.Find("Explosion(Clone)"), 0.2f);
        if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
            Destroy(GameObject.Find("Explosion3(Clone)"), 0.2f);
        if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
            Destroy(GameObject.Find("Explosion3(Clone)"), 0.2f);
        if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
            Destroy(GameObject.Find("Explosion4(Clone)"), 0.2f); 
        Destroy(GameObject.Find("Explosion2(Clone)"), 0.2f);
        Destroy(GameObject.Find("PT11(Clone)"), 3f);
        Destroy(GameObject.Find("PT22(Clone)"), 3f);
        Destroy(GameObject.Find("PT33(Clone)"), 3f);

        if (delayTimer2 > startAttackTime && HP >= 2)
        {
            int RandAttack = Random.Range(1, 4);
            if (RandAttack == 1)
            {
                StartCoroutine("AT1");
                delayTimer2 = 0;
            }
            else if (RandAttack == 2)
            {                
                StartCoroutine("AT2");
                delayTimer2 = 0;
            }
            else if (RandAttack == 3)
            {                
                StartCoroutine("AT3");
                delayTimer2 = 0;
            }


        }
        else if (delayTimer2 > startAttackTime && HP <= 1)
        {
            BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            anim.SetBool("isAttack1", false);
            anim.SetBool("isAttack2", false);
            anim.SetBool("isAttack3", false);
            anim.SetBool("isDie", true);
            //Destroy(gameObject, 0.6f);
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
        }        
    }
    public IEnumerator AT1()
    {
        anim.SetBool("isAttack1", true);
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("isAttack1", false);
    }
    public IEnumerator AT2()
    {
        anim.SetBool("isAttack2", true);
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("isAttack2", false);
    }
    public IEnumerator AT3()
    {
        anim.SetBool("isAttack3", true);
        yield return new WaitForSeconds(0.65f);
        anim.SetBool("isAttack3", false);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
        // 만약 총알과 부딪히고 체력이 1보다 클 때
        // 총알을 -> 방향으로 맞았을 경우
        if (col.gameObject.tag.Equals("Bullet") && HP > 1)
        {
            // HP를 -1함
            HP = HP - player.attackpower;
            // 총알 즉시 삭제
            Destroy(col.gameObject);
            // 폭발프리펩 실행(이펙트)
            //anim.SetBool("isAttack", true);
            if (!player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo, transform.position, Quaternion.identity);
            if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo3, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
                Instantiate(explo4, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
                Instantiate(explo5, transform.position, Quaternion.identity); player.FeverGauge += 1;

        }
        // HP가 1일경우
        else if (col.gameObject.tag.Equals("Bullet") && HP <= 1)
        {
            // 몬스터 죽음 실행
            //    anim.SetBool("isAttack", false);
            //    anim.SetBool("isDie", true);
            Destroy(col.gameObject);
            // 0.55초 후 몬스터 삭제(즉시삭제하면 Enemy1Die애니메이션을 실행하지 않고 삭제됨
            //Destroy(gameObject, 0.53f);
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
            if (!player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo, transform.position, Quaternion.identity);
            if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo3, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
                Instantiate(explo4, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
                Instantiate(explo5, transform.position, Quaternion.identity); player.FeverGauge += 1;

        }
        else if (col.gameObject.tag.Equals("EnemyStone") && HP > 1)
        {
            HP = HP - 3;
            Destroy(col.gameObject);
            Instantiate(explo2, new Vector3(1.7f, -0.3f, 0f), Quaternion.identity); //transform.position, Quaternion.identity);//  new Vector3(1.7f, -0.3f, 0f), Quaternion.identity);
            player.FeverGauge += 1;

        }
        else if (col.gameObject.tag.Equals("EnemyStone") && HP <= 1)
        {
            //    anim.SetBool("isAttack", false);
            //    anim.SetBool("isDie", true);
            Destroy(col.gameObject);
            //Destroy(gameObject, 0.53f);
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
            // 0.55초 후 몬스터 삭제(즉시삭제하면 Enemy1Die애니메이션을 실행하지 않고 삭제됨
            Instantiate(explo2, new Vector3(1.7f, -0.3f, 0f), Quaternion.identity);
            player.FeverGauge += 1;
        }
        else if (col.gameObject.tag.Equals("Fever") && HP > 1)
        {
            HP = HP - 10;
            Destroy(col.gameObject, 0.1f);
            Instantiate(explo, new Vector3(1.7f, -0.3f, 0f), Quaternion.identity);
            player.FeverGauge += 1;

        }
        else if (col.gameObject.tag.Equals("Fever") && HP == 1)
        {
            //Destroy(gameObject, 0.55f);           
            //Destroy(col.gameObject);
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
            Instantiate(explo, new Vector3(1.7f, -0.3f, 0f), Quaternion.identity);
            player.FeverGauge += 1;
        }
    }
    IEnumerator Monster()
    {
        yield return new WaitForSeconds(0.1f);
        Attack();
        int RandAttack2 = Random.Range(1, 4);
        if(RandAttack2 == 1)
        {
            Invoke("PT1RandomAttack", 0);
        }
        if(RandAttack2 == 2)
        {
            Invoke("RandomAttack", 0);
            Invoke("RandomAttack2", 0);
            Invoke("RandomAttack3", 0);
            Invoke("RandomAttack4", 0);
            Invoke("RandomAttack5", 0);
        }
        if(RandAttack2 == 3)
        {
            Invoke("PT3RandomAttack", 0);
        }        
    }
    public void Last()
    {
        delayTimer += Time.deltaTime;
        if (delayTimer > shootDelayTime)
        {
            StartCoroutine("Monster");
            delayTimer = 0f;
        }
    }    

    public void Attack()
    {
        isAttack = true;
    }
    public void NoAttack()
    {
        isAttack = false;
        //anim.SetBool("isIdle", true);
    }
    public void PT1RandomAttack()
    {
        float randomX = Random.Range(-0.25f, 1f);

        if (isAttack)
        {
            GameObject temp = Instantiate(pattern1, new Vector3(player.transform.position.x +1.0f, -0.4f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.

        }
    }   

    public void RandomAttack()
    {
        float randomX = Random.Range(-0.25f, 1f);

        if (isAttack)
        {
            GameObject temp = Instantiate(pattern2, new Vector3(randomX, 1.5f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<EnemyStone>().player = this.player;

        }
    }
    public void RandomAttack2()
    {
        float randomX2 = Random.Range(-1.75f, -0.5f);
        if (isAttack)
        {
            GameObject temp = Instantiate(pattern2, new Vector3(randomX2, 1.5f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<EnemyStone>().player = this.player;

        }
    }
    public void RandomAttack3()
    {
        float randomX3 = Random.Range(-3f, -2f);
        if (isAttack)
        {
            GameObject temp = Instantiate(pattern2, new Vector3(randomX3, 1.5f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<EnemyStone>().player = this.player;
        }
    }
    public void RandomAttack4()
    {
        float randomX3 = Random.Range(-1f, 1f);
        if (isAttack)
        {
            GameObject temp = Instantiate(pattern2, new Vector3(randomX3, 1.5f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<EnemyStone>().player = this.player;
        }
    }
    public void RandomAttack5()
    {
        float randomX3 = Random.Range(-3f, 2f);
        if (isAttack)
        {
            GameObject temp = Instantiate(pattern2, new Vector3(randomX3, 1.5f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            temp.GetComponent<EnemyStone>().player = this.player;
        }
    }
    public void PT3RandomAttack()
    {
        
        //float randomX = Random.Range(-0.25f, 1f);
        if (isAttack)
        {
            Instantiate(pattern3, FirePos.position, Quaternion.identity);
            Instantiate(pattern3, FirePos2.position, Quaternion.identity);
            Instantiate(pattern3, FirePos3.position, Quaternion.identity);
            Instantiate(pattern3, FirePos4.position, Quaternion.identity);

        }
    }

   

    IEnumerator dropTheItems()
    {
        Vector3 v = new Vector3(0.3f, -0.2f, 0f);
        Vector3 v2 = new Vector3(-0.1f, -0.23f, 0f);
        Vector3 v3 = new Vector3(-0.3f, -0.23f, 0f);
        Vector3 v4 = new Vector3(-0.5f, -0.23f, 0f);
        Vector3 v5 = new Vector3(-0.7f, -0.23f, 0f);
        Vector3 v6 = new Vector3(0.1f, -0.23f, 0f);
        yield return new WaitForSeconds(0.3f);

        int rand = Random.Range(0, 3);
        // 랜덤수를 설정합니다(0 ~2까지)
        yield return new WaitForSeconds(0.3f);
        Instantiate(gold, trans.position + v, Quaternion.identity);
        Instantiate(items[rand], trans.position + v2, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Instantiate(items[rand], trans.position + v3, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Instantiate(items[rand], trans.position + v4, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Instantiate(items[rand], trans.position + v5, Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        Instantiate(items[rand], trans.position + v6, Quaternion.identity);
        Destroy(this.gameObject);
    }
}

