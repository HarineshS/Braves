using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using AuroraFPSRuntime.SystemModules.HealthModules;

public class HPDisplay : MonoBehaviour
{

    public GameObject playerobject;
    public CharacterHealth fPHealth;

    public Text hptext;
    public GameObject DeathtText;
    public Image healthBarImage;
    public Color halfHpColor;
    public Color criticalColor;

    public Color fullHpColor;



    // Start is called before the first frame update
    void Start()
    {
        DeathtText.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {


        hptext.text = playerobject.GetComponent<CharacterHealth>().GetHealth().ToString();

        if (playerobject.GetComponent<CharacterHealth>().GetHealth() <= 0)
        {
            DeathtText.SetActive(true);
            Time.timeScale = 0.45f;
        }


        float healthFraction = (float)playerobject.GetComponent<CharacterHealth>().GetHealth() / (float)playerobject.GetComponent<CharacterHealth>().GetMaxHealth();
        healthBarImage.fillAmount = healthFraction;

        if (playerobject.GetComponent<CharacterHealth>().GetHealth() > 70)
        {
            healthBarImage.color = fullHpColor;


        }

        if (playerobject.GetComponent<CharacterHealth>().GetHealth() <= 70 && playerobject.GetComponent<CharacterHealth>().GetHealth() >= 35)
        {
            healthBarImage.color = halfHpColor;


        }

        if (playerobject.GetComponent<CharacterHealth>().GetHealth() <= 35)
        {
            healthBarImage.color = criticalColor;


        }
    }


}
