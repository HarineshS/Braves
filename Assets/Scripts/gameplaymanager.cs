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

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered by player");
            StartCoroutine(DestinationReached());
        }
    }

    public IEnumerator DestinationReached()
    {
        GameObject objectiveText = GameObject.Find("sniperobjtext"); // Replace "ObjectiveText" with the name of your objective text GameObject
        objectiveText.SetActive(true);
        yield return new WaitForSeconds(3f);
        objectiveText.SetActive(false);
    }




}
