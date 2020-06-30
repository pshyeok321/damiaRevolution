using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Clearsc : MonoBehaviour {
    public Player player;


    public GameObject Clear;
    public GameObject Clear2;
    public GameObject ClearBT;

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {

        if (player.CR)
        {
            Clear.SetActive(true);
            Clear2.SetActive(true);
            ClearBT.SetActive(true);
        }
    }

    public void ClearBTClick()
    {
        SceneManager.LoadScene("LoadingScene");
        Clear.SetActive(false);
        Clear2.SetActive(false);
        ClearBT.SetActive(false);

    }
}

