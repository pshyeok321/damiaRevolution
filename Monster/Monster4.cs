    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4 : MonoBehaviour {

    public GameObject gold;

    public GameObject[] items = new GameObject[3];
    Transform trans;
    //Transform target;
    //Transform enemy;

    public Player player;
    public float maxHP = 5; // 목숨
    public float HP = 5;
  //  bool isShoot = false; // 총을 쏘는지 안쏘는지에 대한 bool값
    Animator anim;
    public float movePower; // 초기 움직임 속도 설정
    public GameObject Monster4BulletL; // 총알 생성

    // 총알 무한 발사 제한을 위한 시간 변수들
    float delayTimer = 0f; 
    public float shootDelayTime = 0.1f;
    public float startAttackTime = 1.0f;

    public GameObject explo, explo2, explo3, explo4; // 폭발 프리펩
    public bool isDie;
    Transform Monster4FirePos; // 총알이 나가는 위치
  //  public bool isUnBeatTime = false;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    public void Start () {
        trans = GetComponent<Transform>();
        HP = maxHP; // 시작시 목숨 설정
        anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당
        Monster4FirePos = transform.Find("Monster4FirePos"); // 총알 할당
        //Monster4FirePos2 = transform.Find("Monster4FirePos2");
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    public void Update ()
    {
        if (HP <= 0){
            anim.SetBool("isDie", true);
            anim.SetBool("isShoot", false);
        }
        // 지연시간을 현재 진행시간에 더해줌
        delayTimer += Time.deltaTime;
        if (delayTimer < startAttackTime)
        {
           // isUnBeatTime = true;
            //StartCoroutine("Unbeattime");
        }
        // 일정 시간 후 클론 자동 삭제
        if (!player.RB6 && !player.RB7 && !player.RB8)
            Destroy(GameObject.Find("Explosion(Clone)"), 0.2f);
        if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
            Destroy(GameObject.Find("Explosion2(Clone)"), 0.2f);
        if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
            Destroy(GameObject.Find("Explosion3(Clone)"), 0.2f);
        if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
            Destroy(GameObject.Find("Explosion4(Clone)"), 0.2f);        // 일정 시간 후 몬스터 삭제
        //Destroy(gameObject, 20f);
        // 몬스터의 이동 방향 및 속도
        transform.Translate(Vector3.left * movePower * Time.deltaTime);
        // 총알 발사 코르틴 실행
        Fire();

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언

        if (col.gameObject.tag.Equals("Player") && HP > 0)//isUnBeatTime)
        {
            colls[0].isTrigger = true; //서있는상태박스false
            StartCoroutine("IsTrig");
            player.HP--;
        }
        else if (col.gameObject.tag.Equals("Player") && HP > 0 && player.isUnBeatTime == false)
        {
            player.HP--;
            colls[0].isTrigger = true; //서있는상태박스false
            StartCoroutine("IsTrig");
        }
        // 만약 총알과 부딪히고 체력이 1보다 클 때
        // 총알을 -> 방향으로 맞았을 경우
        else if (col.gameObject.tag.Equals("Bullet") && HP > 0 && !isDie)
        {
            // HP를 -1함
            HP = HP - player.attackpower;
            // 총알 즉시 삭제
            Destroy(col.gameObject);
            // 맞는 모션 실행
            anim.SetBool("isHeart", true);
            // 맞음과 동시에 오른쪽으로 약간 밀림
            transform.Translate(Vector3.right * 1f * 0.2f);
            // Heart코루틴 실행
            StartCoroutine(Heart(0.01f));
            // 폭발프리펩 실행(이펙트)
            if (!player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo, transform.position, Quaternion.identity);
            if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo2, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
                Instantiate(explo3, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
                Instantiate(explo4, transform.position, Quaternion.identity); player.FeverGauge += 1;

        }
        // HP가 1일경우
        else if (col.gameObject.tag.Equals("Bullet") && HP <= 0)
        {
            isDie = true;
            transform.Translate(Vector3.right * 1f * 0.2f);
            // 몬스터 죽음 실행
            anim.SetBool("isDie", true); Destroy(col.gameObject);
            // 0.55초 후 몬스터 삭제(즉시삭제하면 Enemy1Die애니메이션을 실행하지 않고 삭제됨
            //Destroy(gameObject, 0.53f);
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
            if (!player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo, transform.position, Quaternion.identity);
            if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo2, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
                Instantiate(explo3, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
                Instantiate(explo4, transform.position, Quaternion.identity); player.FeverGauge += 1;

        }
        // 총알을 <- 방향으로 맞았을 경우
        else if (col.gameObject.tag.Equals("Bullet2") && HP > 0 && !isDie)
        {
            HP = HP - player.attackpower;
            Destroy(col.gameObject);
            anim.SetBool("isHeart", true);
            transform.Translate(Vector3.left * 1f * 0.2f);
            StartCoroutine(Heart(0.01f));
            if (!player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo, transform.position, Quaternion.identity);
            if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo2, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
                Instantiate(explo3, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
                Instantiate(explo4, transform.position, Quaternion.identity);  player.FeverGauge += 1;

        }
        else if (col.gameObject.tag.Equals("Bullet2") && HP <= 0)
        {
            isDie = true;
            transform.Translate(Vector3.left * 1f * 0.2f);
            // 몬스터 죽음 실행
            anim.SetBool("isDie", true); Destroy(col.gameObject);
            //Destroy(gameObject, 0.53f);
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
            if (!player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo, transform.position, Quaternion.identity);
            if (!player.RB5 && player.RB6 && !player.RB7 && !player.RB8)
                Instantiate(explo2, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && player.RB7 && !player.RB8)
                Instantiate(explo3, transform.position, Quaternion.identity);
            if (!player.RB5 && !player.RB6 && !player.RB7 && player.RB8)
                Instantiate(explo4, transform.position, Quaternion.identity); player.FeverGauge += 1;
        }
        else if (col.gameObject.tag.Equals("Fever"))
        {
            isDie = true;
            // 몬스터 죽음 실행
            anim.SetBool("isDie", true);
            // 0.55초 후 몬스터 삭제(즉시삭제하면 Enemy1Die애니메이션을 실행하지 않고 삭제됨
            //Destroy(gameObject, 0.55f);            
            colls[0].enabled = false;
            StartCoroutine("dropTheItems");
            Instantiate(explo, transform.position, Quaternion.identity);
        }
    }
    public IEnumerator Heart(float waitTime)
    {
        //0.4초 후에
        yield return new WaitForSeconds(0.4f);
        // 맞는모션 false
        anim.SetBool("isHeart", false);
    }



    public void Fire()
    {
       
        if (player.transform.position.x >= transform.position.x -5.5f &&  delayTimer > shootDelayTime)// && dir.x<=0) {
        {
            // 몬스터의 총알이 할당받은 위치로 나간다.
            Instantiate(Monster4BulletL, Monster4FirePos.position, Quaternion.identity);            
            delayTimer = 0f;
            anim.SetBool("isShoot", true);
            movePower = 0.3f;
        } 
        else if(player.transform.position.x < transform.position.x -5.5f)
        {
            anim.SetBool("isShoot", false);
            movePower = 0f;
        }
    }

    IEnumerator IsTrig()
    {
        //0.25초 후에
        yield return new WaitForSeconds(1f);
        // isHeart를 false상태로 바꿔줌
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
        colls[0].isTrigger = false;
    }
    IEnumerator dropTheItems()
    {
        Vector3 v2 = new Vector3(-0.1f, 0.05f, 0f);
        Vector3 v = new Vector3(0.1f, 0.05f, 0f);

        //int maxItems = 10;
        yield return new WaitForSeconds(0.3f);
        //for (int i = 0; i < maxItems; i++)
        //{
        int rand = Random.Range(0, 3);
        // 랜덤수를 설정합니다(0 ~2까지)
        yield return new WaitForSeconds(0.3f); // 딜레이를 만듭니다.
        Instantiate(items[rand], trans.position + v2, Quaternion.identity);
        Instantiate(gold, trans.position + v, Quaternion.identity);
        // 고쳐야함
        // 아이템을 몬스터 자리에 소환합니다.
        //}
        Destroy(this.gameObject);

        // 구동 후 본 스크립트는 더이상 구동하면 안되기 때문에 파괴한다.
    }
}
