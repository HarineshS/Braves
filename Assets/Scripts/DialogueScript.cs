using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{

    public AudioSource Audio;
    public AudioClip[] clips;



    public bool played1 = false;
    public bool played2 = false;
    public bool played3 = false;
    public bool played4 = false;
    public bool played5 = false;
    public bool played6 = false;
    public bool playedsceneload = false;

    void Start()
    {
        played1 = false;
        played2 = false;
        played3 = false;
        played4 = false;
        played5 = false;
        played6 = false;

        //PlayerPrefs.SetInt("SceneLoadStatus", 0);

        playedsceneload = false;


    }


    void Update()
    {
        if (PlayerPrefs.GetInt("Obj1Status") == 1)
        {
            if (!Audio.isPlaying && played1 == false)
            {
                Audio.PlayOneShot(clips[0]);
                played1 = true;



            }


        }

        if (PlayerPrefs.GetInt("Obj2Status") == 1)
        {
            if (!Audio.isPlaying && played2 == false)
            {
                Audio.PlayOneShot(clips[1]);
                played2 = true;



            }


        }

        if (PlayerPrefs.GetInt("Obj3Status") == 1)
        {
            if (!Audio.isPlaying && played3 == false)
            {
                Audio.PlayOneShot(clips[2]);
                played3 = true;



            }


        }

        if (PlayerPrefs.GetInt("Obj4Status") == 1)
        {
            if (!Audio.isPlaying && played4 == false)
            {
                Audio.PlayOneShot(clips[3]);
                played4 = true;



            }


        }

        if (PlayerPrefs.GetInt("Obj5Status") == 1)
        {
            if (!Audio.isPlaying && played5 == false)
            {
                Audio.PlayOneShot(clips[4]);
                played5 = true;



            }


        }

        if (PlayerPrefs.GetInt("Obj6Status") == 1)
        {
            if (!Audio.isPlaying && played6 == false)
            {
                Audio.PlayOneShot(clips[5]);
                played6 = true;



            }


        }

        if (PlayerPrefs.GetInt("SceneLoadStatus") == 1)
        {
            if (!Audio.isPlaying && playedsceneload == false)
            {
                Audio.PlayOneShot(clips[6]);
                playedsceneload = true;



            }


        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Audio.Stop();
        }

    }
}
