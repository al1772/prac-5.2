using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider FPSController)
    {
        GameObject parent = transform.parent.gameObject;
        Animation animation = parent.GetComponent<Animation>();
        animation.Play("OpenDoor");
    }

    void OnCollisionStay(Collision FPSController) {
        if (FPSController.gameObject.name == "FPSController") {
            FPSController.gameObject.SetActive(false);

        }
    }
}
