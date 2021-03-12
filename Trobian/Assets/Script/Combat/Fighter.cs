using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Combat{
    public class Fighter : MonoBehaviour
    {
       public void Attack(CombatTarget target)
        {
            print("Attack!!!!");
            SceneManager.LoadScene("Combate");
        }
    }
}
