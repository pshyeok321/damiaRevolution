using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navi : MonoBehaviour {
    public Player player;
    public float movePower;
    public float movePower2 = -1f; // 초기 움직임 속도 설정

    new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update () {
        movePower = 0.3f;
        if (player.transform.position.x >= transform.position.x - 5.5f)
        {
            movePower = 0.3f;
        }
        else if (player.transform.position.x < transform.position.x - 5.5f)
        {
            movePower = 0;
        }
        transform.Translate(Vector3.left * movePower * Time.deltaTime);
        Destroy(gameObject, 40f);
    }   
}
