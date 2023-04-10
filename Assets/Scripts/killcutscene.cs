using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killcutscene : MonoBehaviour
{

    public GameObject CutSceneCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {


            CutSceneCamera.SetActive(false);
            Destroy(CutSceneCamera);
        }

    }
}
