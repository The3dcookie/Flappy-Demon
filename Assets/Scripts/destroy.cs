using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour { 

    public GameObject Sound;

    public void Start()
    {
        Destroy(Sound, 0.5f);
    }

}
