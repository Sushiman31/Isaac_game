using UnityEngine;

[CreateAssetMenu(fileName = "NewInventaire", menuName ="Data/New inventaire")]
[System.Serializable]
public class Inventaire : ScriptableObject
{
    public GameObject[] objet;
  
}
