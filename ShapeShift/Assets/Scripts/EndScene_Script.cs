using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScene_Script : MonoBehaviour
{
    //Ends the when quit button is pressed
    public void EndGame()
    {
        Application.Quit();
    }

    //restarts the level to the first level
    public void First_level()
    {
        SceneManager.LoadScene("Level_1");
    }
}
