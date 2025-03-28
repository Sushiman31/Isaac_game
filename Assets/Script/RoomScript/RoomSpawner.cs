using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	private bool spawned = false;

	

	void Start(){
		
		templates = GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}


	void Spawn(){//noud allons prendre des salles en fonctions des portes disponibles dans celles-ci,cela permettra d'avoir des portes en face d'autres portes
		if(spawned == false){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, templates.bottomRooms.Length);
				Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, templates.topRooms.Length);
				Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, templates.leftRooms.Length);
				Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0, templates.rightRooms.Length);
				Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
			}
			spawned = true;//Le generateur de seul ne peut plus en générer
		}
	}

	void OnTriggerEnter2D(Collider2D _something){
		if(_something.CompareTag("PointAppariton")){
			if(_something.GetComponent<RoomSpawner>().spawned == false && spawned == false){//Permet de créer une salle fermé si deux portes mènent en dehors de la scène
				Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
				Destroy(gameObject);
			} 
			spawned = true;
		    
        }
	}

  
}




	
