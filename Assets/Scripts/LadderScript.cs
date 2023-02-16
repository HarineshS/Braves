using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public float climbSpeed;
    public float climbDownSpeed;

    private bool isClimbing;
    private GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.Translate(Vector3.up * climbSpeed * Time.deltaTime);
                isClimbing = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                player.transform.Translate(Vector3.down * climbDownSpeed * Time.deltaTime);
                isClimbing = true;
            }
            else
            {
                isClimbing = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isClimbing = false;
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (player.transform.position.y <= transform.position.y)
                {
                    isClimbing = false;
                }
            }
        }
    }
}