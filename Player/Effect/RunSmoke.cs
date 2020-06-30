using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSmoke : MonoBehaviour {
    public Player player;

    public new SpriteRenderer renderer;
    // Use this for initialization
    void Start () {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //spriterenderer 변수 선언

    }

    // Update is called once per frame
    void Update () {
        if (player.RBDown == true && player.SBDown == false && player.fliped == false && player.CBDown == false || player.RBDown == true && player.SBDown == false && player.fliped == false && player.CBDown == false)
        {
            renderer.enabled = true;
        }
        else
            renderer.enabled = false;
    }


}
