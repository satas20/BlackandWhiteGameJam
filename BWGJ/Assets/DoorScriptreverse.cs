using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptreverse : MonoBehaviour
{
    [SerializeField]
    public static bool clicked=false;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        clicked=false;
        door.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {

            door.SetActive(true);
           
        }
        else { door.SetActive(false); }
        
    }
}
