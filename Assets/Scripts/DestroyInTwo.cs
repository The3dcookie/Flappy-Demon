using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInTwo : MonoBehaviour { 

    public GameObject Sound;

    public void Start()
    {
        Destroy(Sound, 3.5f);
    }

}
