using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour{
    public string nomeDaCena;
    public void PlayGame(){
        SceneManager.LoadScene(nomeDaCena);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
