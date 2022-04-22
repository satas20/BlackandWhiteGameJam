using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptreverse : MonoBehaviour
{
    public static bool clicked;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {

            door.SetActive(true);
           
        }
        
    }
}
