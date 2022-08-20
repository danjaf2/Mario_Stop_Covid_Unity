using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public static bool special;
    // Start is called before the first frame update
    public void LoadScene(string scene)
    {
        special = false;
        SceneManager.LoadScene(scene);
    }

    public void LoadSpecialScene(string scene)
    {
        special = true;
        SceneManager.LoadScene(scene);
    }

}
