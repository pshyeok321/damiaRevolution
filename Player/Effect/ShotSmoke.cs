using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSmoke : MonoBehaviour {
    public Player player;

    public new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //spriterenderer 변수 선언
    }

    // Update is called once per frame
    void Update () {
        if (player.SBDown == true && player.RBDown == false && player.fliped == false|| player.SBDown == true && player.LBDown == false && player.fliped == false)
        {            
            renderer.enabled = true;
        }
        else
            renderer.enabled = false;
	}
}
