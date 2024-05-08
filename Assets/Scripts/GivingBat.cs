using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingBat : MonoBehaviour
{
    public GameObject bat;
    public RemovingBat interact;

    private void Start()
    {
        interact = FindObjectOfType<RemovingBat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interact.interact = true;
            bat.SetActive(true);
        }
    }
}
