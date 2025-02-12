using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class selectionBehaviour : MonoBehaviour
{
    public List<GameObject> listePerso;
    public TextMeshProUGUI titreNom;

    private void Start()
    {
        CacherToutLeMonde();
        listePerso[0].SetActive(true);
    }

    public void CacherToutLeMonde()
    {
        foreach (GameObject obj in listePerso)
        {
            obj.SetActive(false);
        }
    }

    public void ButtonAnthony()
    {
        CacherToutLeMonde();
        foreach (GameObject obj in listePerso)
        {
            if (obj.name == "MSH_Anthony")
            {
                obj.SetActive(true);
            }
        }
        titreNom.text = "Anthony";
    }

    public void ButtonEric()
    {
        CacherToutLeMonde();
        foreach (GameObject obj in listePerso)
        {
            if (obj.name == "MSH_Eric")
            {
                obj.SetActive(true);
            }
        }
        titreNom.text = "Eric";
    }
}
