using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static SceneController instance;

    private void Awake(){
        instance = this;
    }

    public void LoadScene(string scene){
        SceneManager.LoadScene(scene);
    }
    
    public void ReloadScene(string scene){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
