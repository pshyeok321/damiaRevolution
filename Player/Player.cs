using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour {
    public bool TT;
    public bool CR;
    public LoadingScene Loading;
    public GameObject nomalpanel;
    //FMOD.Studio.EventInstance stage1;
    //FMOD.Studio.ParameterInstance distance;
    FMOD.Studio.EventInstance Run;
    FMOD.Studio.ParameterInstance waterful;

    FMOD.Studio.EventInstance Shoot;
    FMOD.Studio.ParameterInstance kind;

    FMOD.Studio.EventInstance Fever;

    FMOD.Studio.EventInstance Rain;
    FMOD.Studio.ParameterInstance raining;
    
    public bool RB1, RB2, RB5, RB6, RB7, RB8;

    void Awake()
    {
        //stage1 = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/stage1");
        //stage1.getParameter("distance", out distance);
        Run = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Run");
        Run.getParameter("waterful", out waterful);
        Shoot = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Shoot");
        Shoot.getParameter("kind", out kind);
        Fever = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Fever");

        Rain = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Rain");
        Rain.getParameter("raining", out raining);
    }
    public GameObject player1;
    public GameObject player2; //차져곰인형
    public GameObject player3; //돌고래물총


    public bool zoomed;


    public bool jumped = false; // 점프상태여부
    public bool grounded = false; // 땅 닿는여부
    public bool iswaterful = false;    
    public float movePower = 3f; // 초기 움직임 값
    public float jumpPower = 1f; // 초기 점프 값    
    public int maxHP = 3; // 목숨
    //bool isCreep = false; // 엎드린 여부
    // float timeSpan; // 경과시간을 갖는 변수
    //float checkTime; // 특정시간을 갖는 변수

    Rigidbody2D rigid; // 리지드바디 변수 선언
    public new SpriteRenderer[] renderer; // 스프라이트렌더러 변수 선언
    public SpriteRenderer playerRenderer;
    public Animator[] anim; // 애니메이터 변수 선언 
    //public Animator anim; // 애니메이터 변수 선언 
    public Animator playerAnim;
    public GameObject  FeverEffect, LeftBullet, RightBullet, FeverBullet, RBullet5, LBullet5, RBullet6, LBullet6, RBullet7, LBullet7, RBullet8, LBullet8; //왼쪽 오른쪽 총알
    public Transform FeverPos, FirePos, FirePos2, FirePos3, FirePos4, FirePos5, Smoke, Smoke2; // 총알 날라가는 위치들

    public int HP = 3; //현재체력

    // 총알 무한 발사 억제를 위한 시간 변수
    float delayTimer = 0f;

    public float shootDelayTime = 0.2f;
    public float shootDelayTime2 = 0.5f;

    public GameObject PlayerExplisionR, PlayerExplisionR2, PlayerExplisionR3; // 총구 발사 관련 이펙트
    public GameObject PlayerExplisionL, PlayerExplisionL2, PlayerExplisionL3; // 총구 발사 관련 이펙트
    private static bool playerExists;
    private static bool isShoot;
    public bool isUnBeatTime;
    private static bool isCreep;

    public HPPannel hppannel;

    public bool LBDown;
    public bool RBDown;
    public bool SBDown;
    public bool JBDown;
    public bool CBDown;
    public bool FBDown;
    public int FeverGauge = 0;
    public bool isFever;

    public int lowStone = 0; //하급 조각
    public int midStone = 0; //중급 조각
    public int highStone = 0; //상급 조각
    public int gold = 0; //돈
    public bool isrunning;
    public float attackpower = 1;

    public bool fliped = false;

    public bool stage2map = false;
    public bool stage3map = false;





    void Start() {
        
      //  stage1.start();
        Rain.start();
        rigid = gameObject.GetComponent<Rigidbody2D>(); // rigidbody2d 변수 선언
        renderer[0] = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>(); // gameObject.GetComponentInChildren<SpriteRenderer>(); //spriterenderer 변수 선언
        renderer[1] = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        renderer[2] = transform.GetChild(2).GetComponentInChildren<SpriteRenderer>();
        playerRenderer = renderer[0];

        //anim = gameObject.GetComponentInChildren<Animator>();
        anim[0] = transform.GetChild(0).GetComponentInChildren<Animator>();
        anim[1] = transform.GetChild(1).GetComponentInChildren<Animator>();//gameObject.GetComponentInChildren<Animator>(); //animator 변수 선언               
        anim[2] = transform.GetChild(2).GetComponentInChildren<Animator>();//gameObject.GetComponentInChildren<Animator>(); //animator 변수 선언               
        playerAnim = anim[0];

        FeverPos = transform.Find("FeverPos"); //오른쪽총알나가는곳
        FirePos = transform.Find("FirePos"); //오른쪽총알나가는곳
        FirePos2 = transform.Find("FirePos2"); //왼쪽총알나가는곳        
        FirePos3 = transform.Find("FirePos3"); //왼쪽총알나가는곳     
        FirePos4 = transform.Find("FirePos4"); //왼쪽총알나가는곳     
        FirePos5 = transform.Find("FirePos5"); //피버총알
        Smoke = transform.Find("Smoke");
        Smoke2 = transform.Find("Smoke2");
        HP = maxHP; // 시작시 목숨 설정        
        if (!playerExists)
        {
            playerExists = true;
            if (HP > 0)
            {
                DontDestroyOnLoad(transform.gameObject);
            }
            else if (HP == 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        //  timeSpan = 0.0f;
        //  checkTime = 0.3f; // 특정이간 0.3초
    }
    public int Life()
    {
        return HP;
    }

    /*
    void Bgmdistance()
    {
     
        if (TT)
        {
            if (transform.position.x < 10f && transform.position.x >= 0f)
            {
                distance.setValue(0.2f);
            }
            else if (transform.position.x < 30f && transform.position.x >= 10f)
            {
                distance.setValue(0.4f);
            }
            else if (transform.position.x < 45F && transform.position.x >= 30f)
            {
                distance.setValue(0.6f);
            }
            else if (transform.position.x < 57f && transform.position.x >= 45f)
            {
                distance.setValue(0.8f);
            }
            else if (transform.position.x < 65f && transform.position.x >= 57f)
            {
                distance.setValue(0.9f);
            }
            else if (transform.position.x < 80f && transform.position.x >= 65f)
            {
                distance.setValue(1.0f);
            }
        }

    }
    */
    void RainingDistance()
    {
        Rain.setPaused(false);
        if (TT)
        {
            if (transform.position.x > 124 && transform.position.x < 135)
                raining.setValue(1f);
            else if (transform.position.x > 123 && transform.position.x < 136)
                raining.setValue(0.9f);
            else if (transform.position.x > 122 && transform.position.x < 137)
                raining.setValue(0.85f);
            else if (transform.position.x > 121 && transform.position.x < 138)
                raining.setValue(0.8f);
            else if (transform.position.x > 120 && transform.position.x < 139)
                raining.setValue(0.7f);
            else if (transform.position.x > 119 && transform.position.x < 140)
                raining.setValue(0.6f);
            else if (transform.position.x > 118 && transform.position.x < 142)
                raining.setValue(0.5f);
            else if (transform.position.x > 117 && transform.position.x < 144)
                raining.setValue(0.4f);
            else if (transform.position.x > 116 && transform.position.x < 146)
                raining.setValue(0.3f);
            else if (transform.position.x > 115  && transform.position.x < 148)
                raining.setValue(0.0f);
        }
    }
    // Update is called once per frame
    void Update()
    {        
       // Bgmdistance();
        RainingDistance();
        if (RB1)
        {           
                playerAnim = anim[1];
                playerRenderer = renderer[1];
                kind.setValue(1.0f);           
        }
        else if(RB2)
        {        
                playerAnim = anim[2];
                playerRenderer = renderer[2];
                kind.setValue(2.0f);
        }

        if (HP <= 0 && !RB1 && !RB2)
        {
            anim[0].SetBool("isDie", true);
            StartCoroutine("EndGame");
          //  stage1.setPaused(true);
        }
        else if (HP <= 0 && RB1 && !RB2)
        {
            anim[1].SetBool("isDie", true);
            StartCoroutine("EndGame");
           // stage1.setPaused(true);
        }
        else if (HP <= 0 && !RB1 && RB2)
        {
            anim[2].SetBool("isDie", true);
            StartCoroutine("EndGame");
          //  stage1.setPaused(true);
        }


        if (LBDown)
        {

            

            //    distance.setValue(50f);
            //    breath.setPaused(false);

            LeftButtonDown();
        }
        
        else if (RBDown)
        {
          
            
            //    distance.setValue(0f);
            //   breath.setPaused(false);

            RightButtonDown();
            //player1.SetActive(false);
            //player2.SetActive(true);
            //anim = player2.GetComponent<Animator>();
        }
        else if (FBDown && !isFever)
        {
            return;
        }
        else if(FBDown && isFever)
        {
            FeverButtonDown();
        }
        hppannel.UpdateLife(Life());
        // 시간을 자동 계산해서 delayTimer에 넣어줌
        delayTimer += Time.deltaTime;
        // 총알 이펙트 자동 삭제
        Destroy(GameObject.Find("PlayerExplisionR(Clone)"), 0.2f);
        if(RB7)
            Destroy(GameObject.Find("PlayerExplisionR2(Clone)"), 0.2f);
        if(RB8)
            Destroy(GameObject.Find("PlayerExplisionR3(Clone)"), 0.2f);

        Destroy(GameObject.Find("PlayerExplisionL(Clone)"), 0.2f);
        if(RB7)
            Destroy(GameObject.Find("PlayerExplisionL2(Clone)"), 0.2f);
        if(RB8)
            Destroy(GameObject.Find("PlayerExplisionL3(Clone)"), 0.2f);
    }
 
    
    void FixedUpdate()   // 물리적 처리 함수
    {
      
        if (SBDown)
        {            
            ShotButtonDown();
        }
        else if (JBDown)
        {
            JumpButtonDown();
        }
        else if (CBDown)
        {
            CreepButtonDown();
        }
        else if (!CBDown)
        {
            CreepButtonUp();
        }
        else if (!SBDown)
        {
            Shoot.setPaused(true);
            ShotButtonUp();
        }
        Creep();        
        Jump(); // Jump 함수 실행              
        
    }
    // 움직임 함수
    public void ShotButtonDown()
    {
        if (!RB1 && !RB2)
        {
            SBDown = true;
            anim[0].SetBool("isShoot", true);
            anim[0].SetBool("isJump", false);
            isShoot = true;
            FireFix();
        }
        else if(RB1 && !RB2)
        {
            SBDown = true;
            anim[1].SetBool("isShoot", true);
            anim[1].SetBool("isJump", false);
            isShoot = true;
            FireFix();
        }
        else if(!RB1 && RB2)
        {
            SBDown = true;
            anim[2].SetBool("isShoot", true);
            anim[2].SetBool("isJump", false);
            isShoot = true;
            FireFix();
        }
    }
    public void ShotButtonUp()
    {
        if (!RB1 && !RB2)
        {
            SBDown = false;
            anim[0].SetBool("isShoot", false);
        }
        else if (RB1 && !RB2)
        {
            SBDown = false;
            anim[1].SetBool("isShoot", false);
        }
        else if (!RB1 && RB2)
        {
            SBDown = false;
            anim[2].SetBool("isShoot", false);
        }
    }
    public void  LeftButtonDown()
    {
       
            if (delayTimer > shootDelayTime2)
            {
                Run.start();
                Run.setPaused(false);
            if (grounded && !isCreep)
            {
                waterful.setValue(0.0f);
                Run.setPaused(false);
            }
            else if (iswaterful && !isCreep)
            {
                waterful.setValue(1.0f);
                Run.setPaused(false);
            }
            else if (isCreep)
            {
                Run.setPaused(true);
            }
            delayTimer = 0;
            }
        LBDown = true;
        transform.Translate(Vector3.left * movePower * Time.deltaTime); //왼쪽으로 움직임

        
        fliped = true;
        isrunning = true;         
        
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isRun", true);
            anim[0].SetBool("isShoot", false);
            anim[0].SetBool("isJump", false);
            renderer[0].flipX = true; // 고개도 왼쪽방향으로
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isRun", true);
            anim[1].SetBool("isShoot", false);
            anim[1].SetBool("isJump", false);
            renderer[1].flipX = true; // 고개도 왼쪽방향으로
        }
        else if (!RB1 && RB2)
        {
            anim[2].SetBool("isRun", true);
            anim[2].SetBool("isShoot", false);
            anim[2].SetBool("isJump", false);
            renderer[2].flipX = true; // 고개도 왼쪽방향으로
        }

    }
    public void LeftButtonUp()
    {
        //    breath.setPaused(true);
        Run.setPaused(true);
        LBDown = false;
        if (Input.GetAxisRaw("Horizontal") == 0 && !RB1 && !RB2)
        {
            anim[0].SetBool("isRun", false);
            anim[0].SetBool("isJump", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && RB1 && !RB2)
        {
            anim[1].SetBool("isRun", false);
            anim[1].SetBool("isJump", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && !RB1 && RB2)
        {
            anim[2].SetBool("isRun", false);
            anim[2].SetBool("isJump", false);
        }
    }
    public void RightButtonDown()
    {
        if (delayTimer > shootDelayTime2)
        {
            Run.start();

            if (grounded && !isCreep)
            {
                waterful.setValue(0.0f);
                Run.setPaused(false);
            }
            else if (iswaterful && !isCreep)
            {
                waterful.setValue(1.0f);
                Run.setPaused(false);
            }
            else if (isCreep)
            {
                Run.setPaused(true);
            }
            delayTimer = 0;
        }
        
        RBDown = true;
        transform.Translate(Vector3.right * movePower * Time.deltaTime); //오른쪽으로 움직임
        
        fliped = false;
        isrunning = true;
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isRun", true);
            anim[0].SetBool("isShoot", false);
            anim[0].SetBool("isJump", false);
            renderer[0].flipX = false; // 고개는 오른쪽방향으로 (flipX = false의 뜻은 왼쪽방향이 아니란 뜻)
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isRun", true);
            anim[1].SetBool("isShoot", false);
            anim[1].SetBool("isJump", false);
            renderer[1].flipX = false; // 고개는 오른쪽방향으로 (flipX = false의 뜻은 왼쪽방향이 아니란 뜻)
        }
        else if (!RB1 && RB2)
        {
            anim[2].SetBool("isRun", true);
            anim[2].SetBool("isShoot", false);
            anim[2].SetBool("isJump", false);
            renderer[2].flipX = false; // 고개는 오른쪽방향으로 (flipX = false의 뜻은 왼쪽방향이 아니란 뜻)
        }
    }
    public void RightButtonUp()
    {
        Run.setPaused(true);
        //    breath.setPaused(true);

        RBDown = false;
        if (Input.GetAxisRaw("Horizontal") == 0&& !RB1 && !RB2)
        {
            anim[0].SetBool("isRun", false);
            anim[0].SetBool("isJump", false);
        }
        else if(Input.GetAxisRaw("Horizontal") == 0 && RB1 && !RB2)
        {
            anim[1].SetBool("isRun", false);
            anim[1].SetBool("isJump", false);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && !RB1 && RB2)
        {
            anim[2].SetBool("isRun", false);
            anim[2].SetBool("isJump", false);
        }
    }
    public void JumpButtonDown()
    {
        if (grounded && !RB1 && !RB2) // 만약 땅에 닿았다면
        {
            //isJumping = true; // 점프상태 = true
            JBDown = true;

            grounded = false; //땅상태 = false
            anim[0].SetBool("isJump", false);
            anim[0].SetBool("isCreep", false); //기는상태 false
            anim[0].SetBool("isShoot", false); //총쏘는모션 false           
        }
        else if(grounded && RB1 && !RB2) // 만약 땅에 닿았다면
        {
            //isJumping = true; // 점프상태 = true
            JBDown = true;
            grounded = false; //땅상태 = false
            anim[1].SetBool("isJump", false);
            anim[1].SetBool("isCreep", false); //기는상태 false
            anim[1].SetBool("isShoot", false); //총쏘는모션 false           
        }
        else if (grounded && !RB1 && RB2) // 만약 땅에 닿았다면
        {
            //isJumping = true; // 점프상태 = true
            JBDown = true;
            grounded = false; //땅상태 = false
            anim[2].SetBool("isJump", false);
            anim[2].SetBool("isCreep", false); //기는상태 false
            anim[2].SetBool("isShoot", false); //총쏘는모션 false           
        }


        else if (iswaterful && !RB1 && !RB2) // 만약 땅에 닿았다면
        {
            //isJumping = true; // 점프상태 = true
            JBDown = true;

            iswaterful = false; //땅상태 = false
            anim[0].SetBool("isJump", false);
            anim[0].SetBool("isCreep", false); //기는상태 false
            anim[0].SetBool("isShoot", false); //총쏘는모션 false           
        }
        else if (iswaterful && RB1 && !RB2) // 만약 땅에 닿았다면
        {
            //isJumping = true; // 점프상태 = true
            JBDown = true;
            iswaterful = false; //땅상태 = false
            anim[1].SetBool("isJump", false);
            anim[1].SetBool("isCreep", false); //기는상태 false
            anim[1].SetBool("isShoot", false); //총쏘는모션 false           
        }
        else if (iswaterful && !RB1 && RB2) // 만약 땅에 닿았다면
        {
            //isJumping = true; // 점프상태 = true
            JBDown = true;
            iswaterful = false; //땅상태 = false
            anim[2].SetBool("isJump", false);
            anim[2].SetBool("isCreep", false); //기는상태 false
            anim[2].SetBool("isShoot", false); //총쏘는모션 false           
        }
    }
    public void JumpButtonUp()
    {
        JBDown = false;
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isJump", false);
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isJump", false);
        }
        else if(!RB1 && RB2)
        {
            anim[2].SetBool("isJump", false);
        }
    }
    public void CreepButtonDown()
    {
        CBDown = true;
        isCreep = true;
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isCreep", true);            //기기
            anim[0].SetBool("isShoot", false); // 총쏘면안되는데쏨...
            anim[0].SetBool("isJump", false);  // 점프 불가능인데 함
            anim[0].SetBool("isRun", false);
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isCreep", true);            //기기
            anim[1].SetBool("isShoot", false); // 총쏘면안되는데쏨...
            anim[1].SetBool("isJump", false);  // 점프 불가능인데 함
            anim[1].SetBool("isRun", false);
        }
        else if (!RB1 && RB2)
        {
            anim[2].SetBool("isCreep", true);            //기기
            anim[2].SetBool("isShoot", false); // 총쏘면안되는데쏨...
            anim[2].SetBool("isJump", false);  // 점프 불가능인데 함
            anim[2].SetBool("isRun", false);
        }
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
        colls[0].enabled = false; //서있는상태박스false
        colls[1].enabled = true; //앉은상태박스true
        movePower = 1f; // 기는 이동속도
    }
    public void CreepButtonUp()
    {
        CBDown = false;
        isCreep = false;
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isCreep", false);         //일어나기
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isCreep", false);         //일어나기
        }
        else if (!RB1 && RB2)
        {
            anim[2].SetBool("isCreep", false);         //일어나기
        }
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
        colls[0].enabled = true; //서있는상태박스true
        colls[1].enabled = false; //앉아있는상태박스false
        movePower = 3.0f; //뛰는 이동속도
    }
    public void FeverButtonDown()
    {
        if (FeverGauge >= 100 && !RB1 && !RB2)
        {
            anim[0].SetBool("isFever", true);
            //StartCoroutine("SpellStart");
            StartCoroutine("FeverAttack");
            isFever = true;
            FBDown = true;
            FeverGauge = 0;
        }
        else if(FeverGauge < 100)
        {
          //  anim.SetBool("isFever", false);
            isFever = false;
            FBDown = false;                     
        }
        else if (FeverGauge >= 100 && RB1 && !RB2)
        {
            anim[1].SetBool("isFever", true);
            //StartCoroutine("SpellStart");
            StartCoroutine("FeverAttack");
            isFever = true;
            FBDown = true;
            FeverGauge = 0;
        }
        else if (FeverGauge >= 100 && !RB1 && RB2)
        {
            anim[2].SetBool("isFever", true);
            //StartCoroutine("SpellStart");
            StartCoroutine("FeverAttack");
            isFever = true;
            FBDown = true;
            FeverGauge = 0;
        }
    }
    /*
    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isJump", false);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) // 만약 키보드의 <-키를 눌렀다면
        {
            transform.Translate(Vector3.left * movePower * Time.deltaTime); //왼쪽으로 움직임
            renderer.flipX = true; // 고개도 왼쪽방향으로
            anim.SetBool("isRun", true);
            anim.SetBool("isShoot", false);
            anim.SetBool("isJump", false);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // 만약 키보드의 -> 키를 눌렀다면
        {
            transform.Translate(Vector3.right * movePower * Time.deltaTime); //오른쪽으로 움직임
            renderer.flipX = false; // 고개는 오른쪽방향으로 (flipX = false의 뜻은 왼쪽방향이 아니란 뜻)
            anim.SetBool("isRun", true);
            anim.SetBool("isShoot", false);
            anim.SetBool("isJump", false);
        }

    }
    */
    // 점프 함수
    void Jump()
    {
        if (JBDown)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse); // AddForce(Vector, ForceMode) = 정해준 방향으로 힘을 가해주는 로직으로 첫번째 매개변수로 방향값을, 두번째에는 포스모드를 넣어줌
            JBDown = false;//isJumping = false; //점프상태 꺼짐        
        }
    }

    void Creep()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) //아래방향키누르고잇으면
        {
            isCreep = true;
            if (!RB1 && !RB2) { 
                anim[0].SetBool("isCreep", true);            //기기
                anim[0].SetBool("isShoot", false); // 총쏘면안되는데쏨...
                anim[0].SetBool("isJump", false);  // 점프 불가능인데 함
            }
            else if (RB1 && !RB2)
            {
                anim[1].SetBool("isCreep", true);            //기기
                anim[1].SetBool("isShoot", false); // 총쏘면안되는데쏨...
                anim[1].SetBool("isJump", false);  // 점프 불가능인데 함
            }
            else if (!RB1 && RB2)
            {
                anim[2].SetBool("isCreep", true);            //기기
                anim[2].SetBool("isShoot", false); // 총쏘면안되는데쏨...
                anim[2].SetBool("isJump", false);  // 점프 불가능인데 함
            }
            BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            colls[0].enabled = false; //서있는상태박스false
            colls[1].enabled = true; //앉은상태박스true            
            movePower = 1f; // 기는 이동속도
                            //   isCreep = true; // 기는거 true
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)) //때는순간
        {
            isCreep = false;
            if (!RB1 && !RB2)
            {
                anim[0].SetBool("isCreep", false);         //일어나기
            }
            else if (RB1 && !RB2)
            {
                anim[1].SetBool("isCreep", false);         //일어나기
            }
            else if (!RB1 && RB2)
            {
                anim[2].SetBool("isCreep", false);         //일어나기
            }
            BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
            colls[0].enabled = true; //서있는상태박스true
            colls[1].enabled = false; //앉아있는상태박스false
            movePower = 3.0f; //뛰는 이동속도
                              // isCreep = false;
        }
    }

    
    // 총알 발사
    void Fire()
    {
        isShoot = true;
        //노강화포탄
        if (!RB1 && !RB2)
        {
            if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RightBullet, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RightBullet, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LeftBullet, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LeftBullet, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }

            //첫번째강화포탄
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet5, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet5, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet5, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet5, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            //두번째강화포탄
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet6, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet6, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet6, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet6, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            //세번째강화포탄
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet7, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR2, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet7, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR2, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet7, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL2, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet7, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL2, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //네번째강화포탄
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && !RB7 && RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet8, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR3, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && !RB7 && RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet8, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR3, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && !RB7 && RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet8, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL3, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[0].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && !RB7 && RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet8, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL3, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //(renderer[0].flipX == true  || renderer[1].flipX == true || renderer[2].flipX == true) 
        }


        if (RB1 && !RB2)
        {
            if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RightBullet, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RightBullet, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LeftBullet, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LeftBullet, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }

            //첫번째강화포탄
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet5, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet5, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet5, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet5, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //두번째강화포탄
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet6, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet6, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet6, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet6, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //세번째강화포탄
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet7, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR2, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet7, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR2, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet7, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL2, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet7, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL2, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //네번째강화포탄
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && !RB7 && RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet8, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR3, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && !RB7 && RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet8, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR3, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && !RB7 && RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet8, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL3, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[1].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && !RB7 && RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet8, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL3, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
        }

        if (!RB1 && RB2)
        {
            if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RightBullet, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RightBullet, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LeftBullet, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LeftBullet, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f;
                Shoot.start();
                Shoot.setPaused(false);
            }

            //첫번째강화포탄
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet5, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && RB5 && !RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet5, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet5, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && RB5 && !RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet5, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //두번째강화포탄
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet6, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && RB6 && !RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet6, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet6, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && RB6 && !RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet6, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //세번째강화포탄
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet7, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR2, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && RB7 && !RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet7, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR2, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet7, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL2, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && RB7 && !RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet7, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL2, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            //네번째강화포탄
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && !RBDown && !RB5 && !RB6 && !RB7 && RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet8, FirePos3.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR3, FirePos3.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == false && delayTimer > shootDelayTime && !isCreep && RBDown && !RB5 && !RB6 && !RB7 && RB8) //만약 오른쪽 쳐다보고 총쏘면
            {
                Instantiate(RBullet8, FirePos.position, Quaternion.identity); //오른쪽으로 나가고
                Instantiate(PlayerExplisionR3, FirePos.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && !LBDown && !RB5 && !RB6 && !RB7 && RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet8, FirePos4.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL3, FirePos4.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
            else if (renderer[2].flipX == true && delayTimer > shootDelayTime && !isCreep && LBDown && !RB5 && !RB6 && !RB7 && RB8) //왼쪽쳐다보고 쏘면
            {
                Instantiate(LBullet8, FirePos2.position, Quaternion.identity); //왼쪽으로나감
                Instantiate(PlayerExplisionL3, FirePos2.position, Quaternion.identity);
                delayTimer = 0f; Shoot.start();
                Shoot.setPaused(false);
            }
        }
    }
    void FireFix()
    {
        if(isShoot == true)
        {
            Fire();
        }
        else if(!isShoot)
        {
            delayTimer = 0f;
        }
    }
    // 죽음
    public void Die()
    {
        rigid.velocity = Vector2.zero;
        //anim.SetBool("isDie", true); // 죽는 모션 만들어지면 넣을예정
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>();
        colls[0].enabled = false;
        colls[1].enabled = false;
        //Destroy(gameObject, 0.6f);      
    }



   // void OnTriggerEnter2D(Collider2D col)
   // {
   //     if (col.gameObject.tag.Equals("EnemyBullet"))
  //      {
//            Instantiate(effect, transform.position, Quaternion.identity);

    //    }
    //}
    // 콜리전
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Rain")
        {
            //grounded = true;
            iswaterful = true;
            grounded = false;
        }

        if(collision.transform.tag == "NoWalk")
        {
            transform.position = new Vector3(transform.position.x -3f  , -0.1830001f, 0);
            --HP;
        }
        if (collision.transform.tag == "NoWalk2")
        {
            transform.position = new Vector3(transform.position.x - 1f, 1.2f, 0);
            --HP;
        }
        // 만약 플레이어가 땅에 닿았다면
        else if (collision.transform.tag == "Ground")
        {
            
            // 땅인걸 확인시켜줌 = 점프할 수 있다는걸 알려줌
            grounded = true;
            iswaterful = false;
        }
        // 만약 플레이어가 점프오브젝트를 밟았다면
        else if (collision.gameObject.tag == "Jump")
        {
            // 자동점프 한번 해주고
            //JBDown = true;
            // 점프를 또 할 수 있다는걸 알려줌
            grounded = true;
            iswaterful = true;
        }
        else if(collision.gameObject.tag == "Creep")
        {
            CBDown = true;
            isCreep = true;
        }
        // 플레이어가 적과 부딪혔을경우
        if (collision.gameObject.tag == "Enemy" && HP > 0 && !isUnBeatTime)
        {
            // 무적 실행(아직 안됨)
            isUnBeatTime = true;
            // 무적코루틴 실행
            StartCoroutine("Unbeattime");      
        }
        // 만약 HP가 1이면
        else if (collision.gameObject.tag == "Enemy" && HP == 0 && !isUnBeatTime)
        {
            //isUnBeatTime = true;
            //죽음 함수 실행
            //Die();
            //anim.SetBool("isDie", true); // 죽는 모션 만들어지면 넣을예정
            //StartCoroutine("EndGame");
        }
        else if (collision.gameObject.tag == "Enemy2" && HP > 0 && !isUnBeatTime)
        {
            HP = HP - 0;
            // 무적 실행(아직 안됨)
         //   isUnBeatTime = true;
            // hp는 -1해줌
          //  HP--;
            // 무적코루틴 실행
       //     StartCoroutine("Unbeattime");
        }
        // 만약 HP가 1이면
        else if (collision.gameObject.tag == "Enemy2" && HP == 0 && !isUnBeatTime)
        {
            HP = HP - 0;
            //죽음 함수 실행
            //Die();
            // anim.SetBool("isDie", true); // 죽는 모션 만들어지면 넣을예정
            // StartCoroutine("EndGame");
        }
        // 몬스터의 총알에 맞았을경우
       // else if(collision.gameObject.tag == "EnemyBullet" && HP > 0 && !isUnBeatTime)
        //{
            //Destroy(collision.gameObject);
            //isUnBeatTime = true;
            ////HP--;
            //StartCoroutine("Unbeattime");
        //}
        //else if(collision.gameObject.tag == "EnemyBullet" && HP == 0 && !isUnBeatTime)
        //{
            //Destroy(collision.gameObject);
            //Die();
           // anim.SetBool("isDie", true); // 죽는 모션 만들어지면 넣을예정
           // StartCoroutine("EndGame");
        //}
        else if (collision.gameObject.tag == "EnemyStone" && HP >0 && !isUnBeatTime)
        {
           // isUnBeatTime = true;
          //  StartCoroutine("Unbeattime");
        }
        else if (collision.gameObject.tag == "EnemyStone" && HP ==0 && !isUnBeatTime)
        {
            //Die();
          //  anim.SetBool("isDie", true); // 죽는 모션 만들어지면 넣을예정
          //  StartCoroutine("EndGame");
        }
        else if(collision.gameObject.tag == "HP" && HP > 0)
        {
            if(HP==maxHP)
            {
                HP = maxHP;
            }
            else if (HP < maxHP)
            {
                HP++;
            }            
        }
        else if(collision.gameObject.tag == "Fever")
        {
            grounded = true;            
        }
        else if (collision.gameObject.tag == "Stage1")
        {
            //StartCoroutine("Stage2");
            SceneManager.LoadScene("LoadingScene");
            RBDown = false;
            SBDown = false;
            TT = true;
            stage2map = false;
            stage3map = false;
            //stage1.setPaused(true);
            //stage1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Run.setPaused(true);
            //Shoot.setPaused(true);
            //Fever.setPaused(true);
            Rain.setPaused(true);
            //Rain.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else if (collision.gameObject.tag == "Stage2" && !stage2map && TT)
        {
            //StartCoroutine("Stage2");
            SceneManager.LoadScene("LoadingScene");
            RBDown = false;
            SBDown = false;
            stage2map = true;
            stage3map = false;
            //stage1.setPaused(true);
            //stage1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Run.setPaused(true);
            Shoot.setPaused(true);
            Fever.setPaused(true);
            Rain.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else if(collision.gameObject.tag == "Scene")
        {
            SceneManager.LoadScene("LoadingScene");
            stage2map = false;
            //StartCoroutine("Stage2");            
            stage3map = true;
            RBDown = false;
            SBDown = false;
            Run.setPaused(true);
            Shoot.setPaused(true);
            Fever.setPaused(true);
            //stage1.setPaused(true);
        }
        else if (collision.gameObject.tag == "Clear" && !CR)
        {
            nomalpanel.SetActive(false);
            //SceneManager.LoadScene("LoadingScene");
            CR = true;
            //stage2map = false;
            //StartCoroutine("Stage2");            
            //stage3map = false;            
            //RBDown = false;
            //SBDown = false;
            Run.setPaused(true);
            Shoot.setPaused(true);
            Fever.setPaused(true);
            
            //stage1.setPaused(true);
        }
    }
    
   // IEnumerator Stage2()
   // {
  //      yield return new WaitForSeconds(0.001f);
  //      SceneManager.LoadScene("LoadingScene");
 //       //  anim.SetBool("isNext", false);

//    }


    IEnumerator Unbeattime()
    {
        int countTime = 0;  
        
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                renderer[0].color = new Color32(255, 255, 255, 150);
            else
                renderer[0].color = new Color32(255, 255, 255, 210);
            yield return new WaitForSeconds(.2f);
            countTime++;
        }
        renderer[0].color = new Color32(255, 255, 255, 255);
        isUnBeatTime = false;
        yield return null;
    }    
    IEnumerator EndGame()
    {
        //yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("1");
        HP = 3;
        RBDown = false;
        SBDown = false;
        CBDown = false;
        LBDown = false;
        gold = 0;
        highStone = 0;
        midStone = 0;
        lowStone = 0;
        FeverGauge = 0;
        //stage1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);        
        Run.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);     
        Shoot.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Fever.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        Rain.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);        
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isDie", false);
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isDie", false);
        }
        else if (!RB1 && RB2)
        {
            anim[2].SetBool("isDie", false);
        }
        yield return new AsyncOperation();
    }
    IEnumerator FeverAttack()
    {
        //int countTime2 = 0;
        //while (countTime2 < 10)
        //{
        zoomed = true;
        Time.timeScale = 0.05f;
        //Instantiate(LeftBullet, FirePos2.position, Quaternion.identity); //왼쪽으로나감
        Fever.start();
        Instantiate(FeverBullet, FirePos5.position, Quaternion.identity); //오른쪽으로 나가고
        Instantiate(FeverEffect, FeverPos.position, Quaternion.identity); //오른쪽으로 나가고
                                                                          //   anim.SetBool("isFever", true);

        yield return new WaitForSeconds(0.1f);
        //  countTime2++;
        //}  
        Time.timeScale = 1.0f;
        //anim.SetBool("isFever", false);
        zoomed = false;
        if (!RB1 && !RB2)
        {
            anim[0].SetBool("isFever", false);
        }
        else if (RB1 && !RB2)
        {
            anim[1].SetBool("isFever", false);
        }
        else if (!RB1 && RB2)
        {
            anim[2].SetBool("isFever", false);
        }
        yield return null;                
    }

    /*
    public GameObject obj;
    IEnumerator SpellStart()
    {

        //float angle = 360 / oneShoting;
        float oneShoting = 10;
        float speed =    1f;


        // 저는 총알을 쏘는 갯수를 변수로 지정해서,

        do
        {
            for (int i = 0; i < oneShoting; i++)
            {
                Debug.Log(i);
                
                obj = (GameObject)Instantiate(SpellBullet, FirePos5.transform.position, Quaternion.identity);

                //보스의 위치에 bullet을 생성합니다.


                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / oneShoting), speed * Mathf.Sin(Mathf.PI * i * 2 / oneShoting)));
                objt.transform.Rotate(new Vector3(0f, 1f, 0f), 10f);

                


            }
            //지정해둔 각도의 방향으로 모든 총탄을 날리고, 날아가는 방향으로 방향회전을 해줍니다.
            yield return new WaitForSeconds(1f);
        }
        while (true);
        }
       */

}


