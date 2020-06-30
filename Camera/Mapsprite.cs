using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapsprite : MonoBehaviour {
    public new SpriteRenderer renderer; // 스프라이트렌더러 변수 선언
    public Sprite[] MapSprite = new Sprite[3];
    public Player player;
    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponent<SpriteRenderer>(); //spriterenderer 변수 선언
        renderer.sprite = MapSprite[0];
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
        if (player.stage2map)
        {
            renderer.sprite = MapSprite[1];
        }
        else if (player.stage3map)
        {
            renderer.sprite = MapSprite[2];
        }
        else
            renderer.sprite = MapSprite[0];
    }
}
