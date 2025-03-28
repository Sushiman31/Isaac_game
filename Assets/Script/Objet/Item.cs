using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName ="Inventory/New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public string nameItem;
    public string description;
    public int hpGiven;
    public int speedGiven;
    public float frequencyShoot;

    
    
}
