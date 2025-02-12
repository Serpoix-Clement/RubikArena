using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Rubikarena/CharacterData")]
public class CharacterData: ScriptableObject
{
    [System.Serializable]
    public class CharacterType
    {
        public string name;
    

        public GameObject prefab;

        public int force;
        public int PV;
        public string description; 
    }

    public List<CharacterType>  CharactersTypes; 
}
