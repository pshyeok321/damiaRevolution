using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	public void Awake () {
    }

    // Update is called once per frame
    public void Update () {
    }
    public void PlayButton()
    {
        Invoke("restgame", 1f);
    }
    void restgame()
    {
        SceneManager.LoadScene("HYOEK");
    }
}
