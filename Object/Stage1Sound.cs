using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Sound : MonoBehaviour {
    public Player player;
    FMOD.Studio.EventInstance stage1;
    FMOD.Studio.ParameterInstance distance;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    void Awake()
    {
        stage1 = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/stage1");
        stage1.getParameter("distance", out distance);
    }
    // Use this for initialization
    void Start () {
        stage1.start();
    }

    // Update is called once per frame
    void Update () {
        Bgmdistance();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            stage1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }

    void Bgmdistance()
    {
       if(player.transform.position.x > 20f)
        {
            distance.setValue(0.2f);
        }
        if (player.transform.position.x > 100f)
        {
            distance.setValue(0.4f);
        }
        else if (player.transform.position.x > 130f)
        {
            distance.setValue(0.6f);
        }
        else if (player.transform.position.x > 150f)
        {
            distance.setValue(0.8f);
        }
        else if (player.transform.position.x > 165f)
        {
            distance.setValue(0.9f);
        }
        else if (player.transform.position.x > 180f)
        {
            distance.setValue(1.0f);
        }
        
    }
}
