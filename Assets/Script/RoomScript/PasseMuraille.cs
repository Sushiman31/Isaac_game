using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasseMuraille : MonoBehaviour
{
    public BoxCollider2D collid;
    public BoxCollider2D collid2;
    GameObject player;
    
    void Start(){//on cherche le GameObject Player dans la scene et on active le Trigger sur les portes
		
		player = GameObject.FindGameObjectWithTag("Player");
        collid.isTrigger=true;
        collid2.isTrigger=true;
		
	}
    void Update(){
        if( DeplacementPersoPrincipal.instance.kill%5==0)//si le Player a tué un multiple de 5 de monstres alors le portes sont ouvertes
            {
            collid.isTrigger=true;
            collid2.isTrigger=true;
    }
        else{//dans le cas constraire elle sont fermés
            collid.isTrigger=false;
            collid2.isTrigger=false;
        }
    }

}
    

