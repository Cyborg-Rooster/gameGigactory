using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializerController : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(Init());
    }

    IEnumerator Init()
    {
        DatabaseInitializerManager.Init();
        yield return null;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
