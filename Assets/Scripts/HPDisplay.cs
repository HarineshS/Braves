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



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


        hptext.text = playerobject.GetComponent<CharacterHealth>().GetHealth().ToString();

    }


}
