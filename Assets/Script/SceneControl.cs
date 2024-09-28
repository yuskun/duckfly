using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
     void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
   public void  ToGameScene() {
    SceneManager.LoadScene(1);
   }
    public void  Quit() {
    
    Application.Quit();
   }
}
