using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovingBat : MonoBehaviour
{
    public GameObject bat;
    public bool interact = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            interact = true;
            bat.SetActive(false);
        }
    }
}
