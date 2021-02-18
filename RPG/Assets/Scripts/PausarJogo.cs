using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJogo : MonoBehaviour {
    public GameObject textoDoPause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1)
            {
                textoDoPause.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                textoDoPause.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
