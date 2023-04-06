using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius = 20;
    public GameObject OBJ4LocationTrigger;

    public GameObject OBJ4Position;

    public GameObject Player;
    public GameObject CutSceneCamera;
    public bool reached = false;
    // Start is called before the first frame update
    void Start()
    {
        //OBJ4LocationTrigger = GameObject.Find("Obj4Trigger");
        //OBJ4Position = GameObject.Find("OBJ4Location");
        PlayerPrefs.SetInt("SceneLoadStatus", 0);


    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Singleplayer");




        if (Vector3.Distance(Player.transform.position, OBJ4Position.transform.position) < radius)
        {
            StartCoroutine(DestinationReached());



        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            CutSceneCamera.SetActive(false);
            StopAllCoroutines();
            Destroy(CutSceneCamera);
        }


    }

    public IEnumerator DestinationReached()
    {
        //GameObject OBJ4Position = GameObject.Find("OBJ4Location");
        if (!reached)
        {
            StartCoroutine(cutscene());
            OBJ4LocationTrigger.SetActive(true);
            PlayerPrefs.SetInt("SceneLoadStatus", 1);
            yield return new WaitForSeconds(5f);
            OBJ4LocationTrigger.SetActive(false);
            reached = true;

        }




    }

    public IEnumerator cutscene()
    {
        //Player.SetActive(false);
        CutSceneCamera.SetActive(true);
        yield return new WaitForSeconds(99f);
        //Player.SetActive(true);
        CutSceneCamera.SetActive(false);
    }
}
