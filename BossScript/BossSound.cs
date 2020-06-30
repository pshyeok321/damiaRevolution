using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour {
    public Boss boss;
    FMOD.Studio.EventInstance stage3;
    FMOD.Studio.ParameterInstance bosshp;
    public Player player;

    void Awake()
    {
        stage3 = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/stage3");
        stage3.getParameter("bosshp", out bosshp);

    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Use this for initialization
    void Start()
    {
        stage3.start();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= 9f)
        {
            stage3.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else if(player.HP <= 0)
        {
            stage3.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        else if (boss.HP >= 101)
        {
            bosshp.setValue(1.0f);
        }
        else if (boss.HP >= 50)
        {
            bosshp.setValue(2.2f);
        }
        else if (boss.HP >= 2)
        {
            bosshp.setValue(3.2f);
        }
        else if (boss.HP <= 1)
        {
            bosshp.setValue(3.9f);
        }
    }
}
