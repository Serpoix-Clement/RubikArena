using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersData", menuName = "Game Data/Character Data")]
public class RacesData : ScriptableObject
{
    public string CharacterName;
    public int pv;
    public int force;
    public string Description;

}