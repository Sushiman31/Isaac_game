using UnityEngine;

public class PickUpItem : MonoBehaviour
{
     public Item item;
     GameObject player;
     
     
    
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){//si collision avec le player on récupère les différents attributs des items
            Destroy(gameObject);
            HealthMainCharacter.instance.HealCharacter(item.hpGiven);
            DeplacementPersoPrincipal.instance.IncreaseSpeed(item.speedGiven);
            TirePersoPrincipal.instance.IncreaseShootFrequency(item.frequencyShoot);

         }
    }

   

    
}
