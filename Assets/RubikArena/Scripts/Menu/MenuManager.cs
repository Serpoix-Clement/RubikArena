using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    //Fonction pour lancer la partie 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Fonction pour quitter le jeux
    public void OnQuit()
    {
        Application.Quit(); 
    }

}
