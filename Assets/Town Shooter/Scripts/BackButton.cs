using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class BackButton : MonoBehaviour
{
public void BackScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }   

}
