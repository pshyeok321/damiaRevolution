using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRightButton : MonoBehaviour {
    public Player player;
    public GameObject DontPush;
    public GameObject Push;

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {/**/
        if (player.RBDown)
        {
            Push.SetActive(true);
            DontPush.SetActive(false);
        }
        else
        {
            Push.SetActive(false);
            DontPush.SetActive(true);
        }
    }
}
