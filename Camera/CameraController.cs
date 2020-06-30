using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Player;
    public float offset, offset2;
    private Vector3 PlayerPosition;
    public float offsetSmooting;
    public Player p;
    private static bool cameraExists;
    public GameObject NomalPanel;
    public Player player;
    public bool iszoomed = false;
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Use this for initialization
    void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
	void Start () {

        DontDestroyOnLoad(transform.gameObject);
        
        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }   
    

    // Update is called once per frame
    void Update () {
        Zoom();
    
        PlayerPosition = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);

        if (!player.TT)
        {
            if (Player.transform.position.x < 2.3f)
            {
                PlayerPosition = new Vector3(PlayerPosition.x - offset, PlayerPosition.y, PlayerPosition.z);
            }
            else
            {
                PlayerPosition = new Vector3(PlayerPosition.x + offset2, PlayerPosition.y, PlayerPosition.z);
            }
        }
        else if (player.TT)
        {

            if (Player.transform.localScale.x > 0f)
            {
                PlayerPosition = new Vector3(PlayerPosition.x - offset, PlayerPosition.y, PlayerPosition.z);
            }
            else
            {
                PlayerPosition = new Vector3(PlayerPosition.x - offset, PlayerPosition.y, PlayerPosition.z);
            }
        }
            transform.position = Vector3.Lerp(transform.position, PlayerPosition, offsetSmooting * Time.deltaTime);
        
        if (p.zoomed)
        {
            StartCoroutine("Zoom");
        }
	}
    IEnumerator Zoom()
    {
        GetComponent<Camera>().orthographicSize = 1.0f;
        offset = -1;
        offsetSmooting = 100;
        NomalPanel.SetActive(false);
        yield return new WaitForSeconds(.5f);
        GetComponent<Camera>().orthographicSize = 2.0f;
        offset = -2;
        offsetSmooting = 6;
        NomalPanel.SetActive(true);
    }

}
