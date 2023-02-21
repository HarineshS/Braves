using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using AuroraFPSRuntime.SystemModules.HealthModules;

public class AILeaderScript : MonoBehaviour
{

    //public GameObject Leaderobject;

    public GameObject obj4completeText;
    public CharacterHealth AIHealth;

    public float health;
    // Start is called before the first frame update
    void Start()
    {

        obj4completeText.SetActive(false);
        PlayerPrefs.SetInt("Obj4Status", 0);



    }

    // Update is called once per frame
    void Update()
    {
        GameObject Leaderobject = GameObject.Find("AI Leader");
        health = Leaderobject.GetComponent<CharacterHealth>().GetHealth();

        if (health <= 0f)
        {
            StartCoroutine(OBJ4Completed());
        }



    }

    public IEnumerator OBJ4Completed()
    {
        obj4completeText.SetActive(true);
        yield return new WaitForSeconds(3f);
        obj4completeText.SetActive(false);
        PlayerPrefs.SetInt("Obj4Status", 1);
    }
}
