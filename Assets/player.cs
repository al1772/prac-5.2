using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    float ammo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider AmmoBox) {
        if (AmmoBox.gameObject.name == "AmmoBox") {
            AmmoBox.gameObject.SetActive(false);
            ammo += 20;
        }
        
        
        
        
    }
}
