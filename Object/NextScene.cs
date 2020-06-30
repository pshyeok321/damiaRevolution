using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
  //  Animator anim;
  
	// Use this for initialization
	void Start () {
        //anim = gameObject.GetComponentInChildren<Animator>(); // 애니메이션 할당
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            //anim.SetBool("isNext", true);
            StartCoroutine("Next");
        }
    }
    IEnumerator Next()
    {        
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("LoadingScene");
      //  anim.SetBool("isNext", false);

    }
}
