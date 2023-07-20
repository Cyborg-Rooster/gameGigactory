using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DatabaseInitializerManager.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
