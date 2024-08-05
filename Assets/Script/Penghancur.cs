using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penghancur : MonoBehaviour
{
    void OnTriggerEnter(Collider cek)
    {
        if(cek.gameObject.tag == "NETRAL" || cek.gameObject.tag == "RACUN")
        {
            Destroy(cek.gameObject);
        }
    }
}
