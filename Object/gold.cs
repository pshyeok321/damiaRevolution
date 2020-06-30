using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour {

    FMOD.Studio.EventInstance GetGold;

    // Use this for initialization
    public Player player;
    float delayTimer = 0f;
    public float dropTime = 0.9f;
    Animator anim;

    void Awake()
    {
        GetGold = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/GetGold");

    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Start () {
        anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당
    }

    // Update is called once per frame
    void Update () {
        delayTimer += Time.deltaTime;

        anim.SetBool("isDrop", true);
        if (delayTimer > dropTime)
        {
            anim.SetBool("isDrop", false);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetGold.start();
            int goldrand = Random.Range(10, 31);
            player.gold += goldrand;
            Destroy(gameObject);            
        }
    }
}
