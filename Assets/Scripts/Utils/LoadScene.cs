using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void Load(string text)
    {
        SceneManager.LoadScene(text);
    }
}
