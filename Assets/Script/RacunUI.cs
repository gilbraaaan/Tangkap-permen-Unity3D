using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacunUI : MonoBehaviour
{
    Manager manager;
    float waktu = 0f;
    void Start()
    {
        manager = FindObjectOfType<Manager>();    
    }
    private void Update()
    {
        if (waktu <= 1)
        {
            waktu += 1 / 1.5f * Time.deltaTime;
            if (waktu > 1)
            {
                manager.ActiveTouch = true;
                waktu = 0f;
                this.gameObject.SetActive(false);
            }
        }
    }
}
