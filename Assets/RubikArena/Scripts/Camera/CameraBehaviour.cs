using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //les game object des deux joueurs
    public GameObject joueur1;
    public GameObject joueur2;

    //les positions des deux joueurs
    private Vector3 position1;
    private Vector3 position2;

    //distance entre les deux joueur
    private float distance;

    private void Update()
    {
        position1 = joueur1.transform.position;
        position2 = joueur2.transform.position;

        distance = (position1-position2).magnitude;
        transform.position = new Vector3(position1.x - Mathf.Abs(distance)/2, transform.position.y, transform.position.z);
    }
}
