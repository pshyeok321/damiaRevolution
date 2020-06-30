using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemdrop : MonoBehaviour {
    public GameObject[] items = new GameObject[3];
    Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 v = new Vector3(0f, 0f, 0f);
            trans.position = other.transform.position + v;
            StartCoroutine("dropTheItems");
            // 코루틴을 사용하도록 한다 :D
        }
    }

    IEnumerator dropTheItems()
    {
        //int maxItems = 10;
        yield return new WaitForSeconds(0.3f);
        //for (int i = 0; i < maxItems; i++)
        //{
            int rand = Random.Range(0, 3);
            // 랜덤수를 설정합니다(0 ~2까지)
            yield return new WaitForSeconds(0.3f); // 딜레이를 만듭니다.
            Instantiate(items[rand], trans.position, Quaternion.identity);
            // 고쳐야함
            // 아이템을 몬스터 자리에 소환합니다.
        //}
        Destroy(this.gameObject);

        // 구동 후 본 스크립트는 더이상 구동하면 안되기 때문에 파괴한다.
    }
}


