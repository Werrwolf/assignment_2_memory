using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void triggerMenuBehaviour (int wichButton){
        // 0: play again; 1: quit game
        switch (wichButton){
        default:
        case (0):
            SceneManager.LoadScene("Level");
            break;
        case(1):
            Application.Quit();
            break;
        }
    }
}
