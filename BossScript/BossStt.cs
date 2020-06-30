using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStt : MonoBehaviour {
    float delayTime = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;
        if (delayTime > 1.35f)
        {
            Destroy(gameObject);
        }
    }
}
