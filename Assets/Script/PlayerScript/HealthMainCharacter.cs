using UnityEngine;


public class HealthMainCharacter : MonoBehaviour
{
   public int maxHealth=100;
   public int currentHealth;
   public HealthBar healthBar;
   public bool alive=true;

    public static HealthMainCharacter instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de HealthMainCharacter dans la scène");
            return;
        }

        instance = this;
    } 
   void Start(){//à chaque début de partie la vie doit être à 100
    currentHealth=maxHealth;
    healthBar.SetMaxHealth(currentHealth);

   }
   void Update(){
    if(currentHealth<=0){
        Death();
    }
   }
   public void TakeDomage(int _domage){
    currentHealth-=_domage;
    healthBar.SetHealth(currentHealth);

   }
    public void HealCharacter(int _x){//permet de heal le player sans lui faire dépasser le max de vie
        if(currentHealth+_x>100){
            currentHealth=100;
            healthBar.SetHealth(currentHealth);
        }
        else{
            currentHealth+=_x;
            healthBar.SetHealth(currentHealth);
        }
    }
   
    public void Death(){//Détruit le Player et active l'UI
        Destroy(gameObject);
        alive=false;
        GameOverManager.instance.OnPlayerDeath();
    }
    
 
}
