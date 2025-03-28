using UnityEngine;

public class GenerationMap : MonoBehaviour
{
    System.Random ran = new System.Random();

    [SerializeField] private GameObject obstacle;
    public Transform zone;
    private int ZoneApparition=15;
    // Start is called before the first frame update
    void Start()
    { 
        //créeation d'obstaque 
        int entierUnChiffre = ran.Next(4); //Génère un entier compris entre 0 et 3
        for(int i=0;i<entierUnChiffre;i++){
        Instantiate(obstacle,zone.position+new Vector3(Random.Range(-ZoneApparition,ZoneApparition),Random.Range(-ZoneApparition,ZoneApparition),0),Quaternion.identity);
        }
    }

}
