using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fever : MonoBehaviour {
    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image content;
    public Player player;
    public GameObject FeverGaugenoFull;
    public GameObject FeverGaugeFull;
    // Animator anim;
    // Use this for initialization
    void Start() {
        //    anim = gameObject.GetComponentInChildren<Animator>(); //animator 변수 선언       
    }
    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update() {
        HandlerBar();
    }
    private void HandlerBar()
    {
        content.fillAmount = fillAmount;
        if (player.FeverGauge <= 10)
        {
            content.fillAmount = 0f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //  anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 20)
        {
            content.fillAmount = 0.1f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //   anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 30)
        {
            content.fillAmount = 0.2f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //   anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 40)
        {
            content.fillAmount = 0.3f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //  anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 50)
        {
            content.fillAmount = 0.4f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //   anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 60)
        {
            content.fillAmount = 0.5f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //  anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 70)
        {
            content.fillAmount = 0.6f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //   anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 80)
        {
            content.fillAmount = 0.7f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //  anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 90)
        {
            content.fillAmount = 0.8f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            // anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge <= 99)
        {
            content.fillAmount = 0.9f;
            FeverGaugenoFull.SetActive(true);
            FeverGaugeFull.SetActive(false);
            //    anim.SetBool("isFull", false);
        }
        else if (player.FeverGauge >= 100)
        {
            content.fillAmount = 1f;
            FeverGaugenoFull.SetActive(false);
            FeverGaugeFull.SetActive(true);
            //   anim.SetBool("isFull", true);
        }
        //fillAmount;        
    }
        
}
