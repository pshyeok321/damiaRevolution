using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern1 : MonoBehaviour {
    public float nowTime = 0;
    public float AttackTime0 = 0.01f;
    public float AttackTime = 0.2f;
    public float AttackTime2 = 0.4f;
    public float AttackTime3 = 0.6f;
    public float AttackTime4 = 0.8f;
    public float AttackTime5 = 1.0f;
    public float AttackTime6 = 1.2f;
    public float AttackTime7 = 1.4f;
    public float AttackTime8 = 1.6f;
    public float AttackTime9 = 1.8f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
        nowTime += Time.deltaTime;
        //StartCoroutine("pt1");
        if (AttackTime0 > nowTime)
        {
            colls[0].enabled = true;

            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = true;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime2 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = true;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime3 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = true;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime4 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = true;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime5 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = true;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime6 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = true;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }
        else if (AttackTime7 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = true;
            colls[7].enabled = false;
        }
        else if(AttackTime8 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = true;
        }
        else if (AttackTime9 > nowTime)
        {
            colls[0].enabled = false;
            colls[1].enabled = false;
            colls[2].enabled = false;
            colls[3].enabled = false;
            colls[4].enabled = false;
            colls[5].enabled = false;
            colls[6].enabled = false;
            colls[7].enabled = false;
        }

    }

    /*
    IEnumerator pt1()
    {
        BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D>(); //박스2개선언
        colls[0].enabled = true;
        
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);

        colls[0].enabled = false;
        colls[1].enabled = true;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);

        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = true;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);

        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = true;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;
        //
        yield return new WaitForSeconds(.16f);

        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = true;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);
        //
        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = true;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);
        //
        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = true;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);

        colls[0].enabled = false;
        colls[1].enabled = true;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return new WaitForSeconds(.16f);

        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = true;

        yield return new WaitForSeconds(.16f);
        colls[0].enabled = false;
        colls[1].enabled = false;
        colls[2].enabled = false;
        colls[3].enabled = false;
        colls[4].enabled = false;
        colls[5].enabled = false;
        colls[6].enabled = false;
        colls[7].enabled = false;

        yield return null;
    }
    */
}
