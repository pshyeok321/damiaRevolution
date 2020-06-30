using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpObject : MonoBehaviour {
    new SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        // 플레이어와 부딪히면
        if(col.gameObject.tag == "Player")
        {
            
            StartCoroutine("hide"); // hide 코루틴 실행
        }
        // 총알과 부딪히면 총알 삭제
        else if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }

    IEnumerator hide()
    {
        yield return new WaitForSeconds(0.5f); // 5초 후에
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); // 점프대
        colls[0].enabled = false; //점프대 비활성화
        renderer.enabled = false; //이미지도 비활성화
        yield return new WaitForSeconds(3.0f); // 5초 후에
        colls[0].enabled = true; // 점프대 활성화              
        renderer.enabled = true; // 이미지도 활성화
    }
}
