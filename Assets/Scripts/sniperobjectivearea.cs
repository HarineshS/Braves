using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sniperobjectivearea : MonoBehaviour
{

    public float radius = 20;
    public GameObject OBJ4LocationTrigger;

    public GameObject OBJ4Position;
    public bool reached = false;
    // Start is called before the first frame update
    void Start()
    {
        //OBJ4LocationTrigger = GameObject.Find("Obj4Trigger");
        //OBJ4Position = GameObject.Find("OBJ4Location");
        PlayerPrefs.SetInt("Obj5Status", 0);


    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Singleplayer");




        if (Vector3.Distance(Player.transform.position, OBJ4Position.transform.position) < radius)
        {
            StartCoroutine(DestinationReached());



        }


    }

    public IEnumerator DestinationReached()
    {
        //GameObject OBJ4Position = GameObject.Find("OBJ4Location");
        if (!reached)
        {
            OBJ4LocationTrigger.SetActive(true);
            PlayerPrefs.SetInt("Obj5Status", 1);
            yield return new WaitForSeconds(5f);
            OBJ4LocationTrigger.SetActive(false);
            reached = true;

        }




    }
}
