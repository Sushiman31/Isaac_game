using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms; 
    public GameObject[] topRooms; 
    public GameObject[] leftRooms; 
    public GameObject[] rightRooms; 
    public GameObject closedRooms;
    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    void Update(){//on stocke les différentes salles et on génère une salle de boss
    if(waitTime<=0 && spawnedBoss==false){
        
            Instantiate(boss,rooms[rooms.Count-1].transform.position,Quaternion.identity);
            spawnedBoss=true;
        
        }
    
    else{
        waitTime-=Time.deltaTime;
    }
    

}
}
