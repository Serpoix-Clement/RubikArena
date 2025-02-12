using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Camera Cam;
    public GameObject BackGroundMain;
    public GameObject BackGroundCredit;
    public GameObject MainMenu;
    public GameObject CreditsMenu;



    //Fonction pour lancer la partie 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //Fonction pour les Credits 
    public void Credits()
    {
        //je désactive le Fond Du MenuPrincipale
        //pour Opti
        BackGroundMain.SetActive(false);

        //J'active le Fond Du Credits
        //Car de base désactiver pour l'opti
        BackGroundCredit.SetActive(true);

        //la camera tourne 
        Cam.transform.rotation = Quaternion.Euler(0, 180, 0);


        //Je désactive le gameobject contenant Tout L'UI Du Menu Principale
        MainMenu.SetActive(false);

        //J'active le gameobject contenant tout l'UI du Credits
        //Car de base désactiver
        CreditsMenu.SetActive(true);

    }

    public void ReturnMain()
    {
        BackGroundMain.SetActive(true );
        BackGroundCredit.SetActive(false);
        Cam.transform.rotation = Quaternion.Euler(0,0,0);
        CreditsMenu.SetActive(false );
        MainMenu.SetActive(true);
    }

    //Fonction pour quitter le jeux
    public void OnQuit()
    {
        Application.Quit(); 
    }

}
