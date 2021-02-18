using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScene : MonoBehaviour
{
    public string nomeDaCena;

    public void Changes(){
        SceneManager.LoadScene(nomeDaCena);
    } 

    public void Sair(){
        Application.Quit();
    }
}
