using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour {
    [SerializeField]
    public float fillAmount;
    [SerializeField]
    public float fillAmount2;
    [SerializeField]
    public float fillAmount3;
    [SerializeField]
    public Image content;
    public GameObject content2;
    public Image content3;
    public GameObject content4;
    public Image content5;
    public GameObject content6;

    public GameObject blue;
    public GameObject yellow;
    public GameObject red;

    public Boss boss;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HandlerBar();
    }
    private void HandlerBar()
    {
        content.fillAmount = fillAmount;
        content3.fillAmount = fillAmount2;
        content5.fillAmount = fillAmount3;
        if (boss.HP == 150)
        {
            content.fillAmount = 0.00f;
        }
        else if (boss.HP >= 149)
        {
            content.fillAmount = 0.02f;
        }
        else if (boss.HP >= 148)
        {
            content.fillAmount = 0.04f;
        }
        else if (boss.HP >= 147)
        {
            content.fillAmount = 0.06f;
        }
        else if (boss.HP >= 146)
        {
            content.fillAmount = 0.08f;
        }
        else if (boss.HP >= 145)
        {
            content.fillAmount = 0.10f;
        }
        else if (boss.HP >= 144)
        {
            content.fillAmount = 0.12f;
        }
        else if (boss.HP >= 143)
        {
            content.fillAmount = 0.14f;
        }
        else if (boss.HP >= 142)
        {
            content.fillAmount = 0.16f;
        }
        else if (boss.HP >= 141)
        {
            content.fillAmount = 0.18f;
        }
        else if (boss.HP >= 140)
        {
            content.fillAmount = 0.20f;
        }
        else if (boss.HP >= 139)
        {
            content.fillAmount = 0.22f;
        }
        else if (boss.HP >= 138)
        {
            content.fillAmount = 0.24f;
        }
        else if (boss.HP >= 137)
        {
            content.fillAmount = 0.26f;
        }
        else if (boss.HP >= 136)
        {
            content.fillAmount = 0.28f;
        }
        else if (boss.HP >= 135)
        {
            content.fillAmount = 0.30f;
        }
        else if (boss.HP >= 134)
        {
            content.fillAmount = 0.32f;
        }
        else if (boss.HP >= 133)
        {
            content.fillAmount = 0.34f;
        }
        else if (boss.HP >= 132)
        {
            content.fillAmount = 0.36f;
        }
        else if (boss.HP >= 131)
        {
            content.fillAmount = 0.38f;
        }
        else if (boss.HP >= 130)
        {
            content.fillAmount = 0.40f;
        }
        else if (boss.HP >= 129)
        {
            content.fillAmount = 0.42f;
        }
        else if (boss.HP >= 128)
        {
            content.fillAmount = 0.44f;
        }
        else if (boss.HP >= 127)
        {
            content.fillAmount = 0.46f;
        }
        else if (boss.HP >= 126)
        {
            content.fillAmount = 0.48f;
        }
        else if (boss.HP >= 125)
        {
            content.fillAmount = 0.50f;
        }
        else if (boss.HP >= 124)
        {
            content.fillAmount = 0.52f;
        }
        else if (boss.HP >= 123)
        {
            content.fillAmount = 0.54f;
        }
        else if (boss.HP >= 122)
        {
            content.fillAmount = 0.56f;
        }
        else if (boss.HP >= 121)
        {
            content.fillAmount = 0.58f;
        }
        else if (boss.HP >= 120)
        {
            content.fillAmount = 0.60f;
        }
        else if (boss.HP >= 119)
        {
            content.fillAmount = 0.62f;
        }
        else if (boss.HP >= 118)
        {
            content.fillAmount = 0.64f;
        }
        else if (boss.HP >= 117)
        {
            content.fillAmount = 0.66f;
        }
        else if (boss.HP >= 116)
        {
            content.fillAmount = 0.68f;
        }
        else if (boss.HP >= 115)
        {
            content.fillAmount = 0.70f;
        }
        else if (boss.HP >= 114)
        {
            content.fillAmount = 0.72f;
        }
        else if (boss.HP >= 113)
        {
            content.fillAmount = 0.74f;
        }
        else if (boss.HP >= 112)
        {
            content.fillAmount = 0.76f;
        }
        else if (boss.HP >= 111)
        {
            content.fillAmount = 0.78f;
        }
        else if (boss.HP >= 110)
        {
            content.fillAmount = 0.80f;
        }
        else if (boss.HP >= 109)
        {
            content.fillAmount = 0.82f;
        }
        else if (boss.HP >= 108)
        {
            content.fillAmount = 0.84f;
        }
        else if (boss.HP >= 107)
        {
            content.fillAmount = 0.86f;
        }
        else if (boss.HP >= 106)
        {
            content.fillAmount = 0.88f;
        }
        else if (boss.HP >= 105)
        {
            content.fillAmount = 0.90f;
        }
        else if (boss.HP >= 104)
        {
            content.fillAmount = 0.92f;
        }
        else if (boss.HP >= 103)
        {
            content.fillAmount = 0.94f;
        }
        else if (boss.HP >= 102)
        {
            content.fillAmount = 0.96f;
        }
        else if (boss.HP >= 101)
        {
            content.fillAmount = 0.98f;
        }


        if (boss.HP == 100)
        {
            content2.SetActive(false);
            blue.SetActive(false);
            content3.fillAmount = 0.00f;

        }
        else if (boss.HP >= 99)
        {
            content3.fillAmount = 0.02f;
        }
        else if (boss.HP >= 98)
        {
            content3.fillAmount = 0.04f;
        }
        else if (boss.HP >= 97)
        {
            content3.fillAmount = 0.06f;
        }
        else if (boss.HP >= 96)
        {
            content3.fillAmount = 0.08f;
        }
        else if (boss.HP >= 95)
        {
            content3.fillAmount = 0.10f;
        }
        else if (boss.HP >= 94)
        {
            content3.fillAmount = 0.12f;
        }
        else if (boss.HP >= 93)
        {
            content3.fillAmount = 0.14f;
        }
        else if (boss.HP >= 92)
        {
            content3.fillAmount = 0.16f;
        }
        else if (boss.HP >= 91)
        {
            content3.fillAmount = 0.18f;
        }
        else if (boss.HP >= 90)
        {
            content3.fillAmount = 0.20f;
        }
        else if (boss.HP >= 89)
        {
            content3.fillAmount = 0.22f;
        }
        else if (boss.HP >= 88)
        {
            content3.fillAmount = 0.24f;
        }
        else if (boss.HP >= 87)
        {
            content3.fillAmount = 0.26f;
        }
        else if (boss.HP >= 86)
        {
            content3.fillAmount = 0.28f;
        }
        else if (boss.HP >= 85)
        {
            content3.fillAmount = 0.30f;
        }
        else if (boss.HP >= 84)
        {
            content3.fillAmount = 0.32f;
        }
        else if (boss.HP >= 83)
        {
            content3.fillAmount = 0.34f;
        }
        else if (boss.HP >= 82)
        {
            content3.fillAmount = 0.36f;
        }
        else if (boss.HP >= 81)
        {
            content3.fillAmount = 0.38f;
        }
        else if (boss.HP >= 80)
        {
            content3.fillAmount = 0.40f;
        }
        else if (boss.HP >= 79)
        {
            content3.fillAmount = 0.42f;
        }
        else if (boss.HP >= 78)
        {
            content3.fillAmount = 0.44f;
        }
        else if (boss.HP >= 77)
        {
            content3.fillAmount = 0.46f;
        }
        else if (boss.HP >= 76)
        {
            content3.fillAmount = 0.48f;
        }
        else if (boss.HP >= 75)
        {
            content3.fillAmount = 0.50f;
        }
        else if (boss.HP >= 74)
        {
            content3.fillAmount = 0.52f;
        }
        else if (boss.HP >= 73)
        {
            content3.fillAmount = 0.54f;
        }
        else if (boss.HP >= 72)
        {
            content3.fillAmount = 0.56f;
        }
        else if (boss.HP >= 71)
        {
            content3.fillAmount = 0.58f;
        }
        else if (boss.HP >= 70)
        {
            content3.fillAmount = 0.60f;
        }
        else if (boss.HP >= 69)
        {
            content3.fillAmount = 0.62f;
        }
        else if (boss.HP >= 68)
        {
            content3.fillAmount = 0.64f;
        }
        else if (boss.HP >= 67)
        {
            content3.fillAmount = 0.66f;
        }
        else if (boss.HP >= 66)
        {
            content3.fillAmount = 0.68f;
        }
        else if (boss.HP >= 65)
        {
            content3.fillAmount = 0.70f;
        }
        else if (boss.HP >= 64)
        {
            content3.fillAmount = 0.72f;
        }
        else if (boss.HP >= 63)
        {
            content3.fillAmount = 0.74f;
        }
        else if (boss.HP >= 62)
        {
            content3.fillAmount = 0.76f;
        }
        else if (boss.HP >= 61)
        {
            content3.fillAmount = 0.78f;
        }
        else if (boss.HP >= 60)
        {
            content3.fillAmount = 0.80f;
        }
        else if (boss.HP >= 59)
        {
            content3.fillAmount = 0.82f;
        }
        else if (boss.HP >= 58)
        {
            content3.fillAmount = 0.84f;
        }
        else if (boss.HP >= 57)
        {
            content3.fillAmount = 0.86f;
        }
        else if (boss.HP >= 56)
        {
            content3.fillAmount = 0.88f;
        }
        else if (boss.HP >= 55)
        {
            content3.fillAmount = 0.90f;
        }
        else if (boss.HP >= 54)
        {
            content3.fillAmount = 0.92f;
        }
        else if (boss.HP >= 53)
        {
            content3.fillAmount = 0.94f;
        }
        else if (boss.HP >= 52)
        {
            content3.fillAmount = 0.96f;
        }
        else if (boss.HP >= 51)
        {
            content3.fillAmount = 0.98f;
        }



        else if (boss.HP == 50)
        {
            content4.SetActive(false);
            yellow.SetActive(false);
            content5.fillAmount = 0.00f;
        }
        else if (boss.HP >= 49)
        {
            content5.fillAmount = 0.02f;
        }
        else if (boss.HP >= 48)
        {
            content5.fillAmount = 0.04f;
        }
        else if (boss.HP >= 47)
        {
            content5.fillAmount = 0.06f;
        }
        else if (boss.HP >= 46)
        {
            content5.fillAmount = 0.08f;
        }
        else if (boss.HP >= 45)
        {
            content5.fillAmount = 0.10f;
        }
        else if (boss.HP >= 44)
        {
            content5.fillAmount = 0.12f;
        }
        else if (boss.HP >= 43)
        {
            content5.fillAmount = 0.14f;
        }
        else if (boss.HP >= 42)
        {
            content5.fillAmount = 0.16f;
        }
        else if (boss.HP >= 41)
        {
            content5.fillAmount = 0.18f;
        }
        else if (boss.HP >= 40)
        {
            content5.fillAmount = 0.20f;
        }
        else if (boss.HP >= 39)
        {
            content5.fillAmount = 0.22f;
        }
        else if (boss.HP >= 38)
        {
            content5.fillAmount = 0.24f;
        }
        else if (boss.HP >= 37)
        {
            content5.fillAmount = 0.26f;
        }
        else if (boss.HP >= 36)
        {
            content5.fillAmount = 0.28f;
        }
        else if (boss.HP >= 35)
        {
            content5.fillAmount = 0.30f;
        }
        else if (boss.HP >= 34)
        {
            content5.fillAmount = 0.32f;
        }
        else if (boss.HP >= 33)
        {
            content5.fillAmount = 0.34f;
        }
        else if (boss.HP >= 32)
        {
            content5.fillAmount = 0.36f;
        }
        else if (boss.HP >= 31)
        {
            content5.fillAmount = 0.38f;
        }
        else if (boss.HP >= 30)
        {
            content5.fillAmount = 0.40f;
        }
        else if (boss.HP >= 29)
        {
            content5.fillAmount = 0.42f;
        }
        else if (boss.HP >= 28)
        {
            content5.fillAmount = 0.44f;
        }
        else if (boss.HP >= 27)
        {
            content5.fillAmount = 0.46f;
        }
        else if (boss.HP >= 26)
        {
            content5.fillAmount = 0.48f;
        }
        else if (boss.HP >= 25)
        {
            content5.fillAmount = 0.50f;
        }
        else if (boss.HP >= 24)
        {
            content5.fillAmount = 0.52f;
        }
        else if (boss.HP >= 23)
        {
            content5.fillAmount = 0.54f;
        }
        else if (boss.HP >= 22)
        {
            content5.fillAmount = 0.56f;
        }
        else if (boss.HP >= 21)
        {
            content5.fillAmount = 0.58f;
        }
        else if (boss.HP >= 20)
        {
            content5.fillAmount = 0.60f;
        }
        else if (boss.HP >= 19)
        {
            content5.fillAmount = 0.62f;
        }
        else if (boss.HP >= 18)
        {
            content5.fillAmount = 0.64f;
        }
        else if (boss.HP >= 17)
        {
            content5.fillAmount = 0.66f;
        }
        else if (boss.HP >= 16)
        {
            content5.fillAmount = 0.68f;
        }
        else if (boss.HP >= 15)
        {
            content5.fillAmount = 0.70f;
        }
        else if (boss.HP >= 14)
        {
            content5.fillAmount = 0.72f;
        }
        else if (boss.HP >= 13)
        {
            content5.fillAmount = 0.74f;
        }
        else if (boss.HP >= 12)
        {
            content5.fillAmount = 0.76f;
        }
        else if (boss.HP >= 11)
        {
            content5.fillAmount = 0.78f;
        }
        else if (boss.HP >= 10)
        {
            content5.fillAmount = 0.80f;
        }
        else if (boss.HP >= 9)
        {
            content5.fillAmount = 0.82f;
        }
        else if (boss.HP >= 8)
        {
            content5.fillAmount = 0.84f;
        }
        else if (boss.HP >= 7)
        {
            content5.fillAmount = 0.86f;
        }
        else if (boss.HP >= 6)
        {
            content5.fillAmount = 0.88f;
        }
        else if (boss.HP >= 5)
        {
            content5.fillAmount = 0.90f;
        }
        else if (boss.HP >= 4)
        {
            content5.fillAmount = 0.93f;
        }
        else if (boss.HP >= 3)
        {
            content5.fillAmount = 0.96f;
        }
        else if (boss.HP >= 2)
        {
            content5.fillAmount = 0.98f;
        }
        else if (boss.HP >= 1)
        {
            content5.fillAmount = 1.00f;
            Destroy(gameObject);
        }
        else if (boss.HP < 1)
        {
            Destroy(gameObject);
        }
    }
}

