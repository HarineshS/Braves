using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplaymanager : MonoBehaviour
{
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    public GameObject Obj4;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        //Obj1.SetActive(true);
        // Obj2.SetActive(true);
        // Obj3.SetActive(true);
        // Obj4.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("Obj1Status") == 1)
        {
            Obj1.SetActive(true);

        }
        else
        {
            Obj1.SetActive(false);
        }

        //     if (PlayerPrefs.GetInt("Obj2Status") == 1)
        //     {
        //         Obj2.SetActive(false);

        //     }
        //     else
        //     {
        //         Obj2.SetActive(true);
        //     }

        //     if (PlayerPrefs.GetInt("Obj3Status") == 1)
        //     {
        //         Obj3.SetActive(false);

        //     }
        //     else
        //     {
        //         Obj3.SetActive(true);
        //     }


        //     if (PlayerPrefs.GetInt("Obj4Status") == 1)
        //     {
        //         Obj4.SetActive(false);

        //     }
        //     else
        //     {
        //         Obj4.SetActive(true);
        //     }

    }


}
