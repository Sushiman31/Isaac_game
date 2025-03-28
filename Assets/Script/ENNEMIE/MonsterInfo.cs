using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EnemyState
{
    Idle,
    Follow,
    Attack
};



public class MonsterInfo : MonoBehaviour
{
    GameObject player;
    public EnemyState currState = EnemyState.Idle;
    
    public float range=20f;
    public float speed;

    public float coolDown;
    private bool monsterAlive;
    
    private bool coolDownAttack = false;
    public int life=2;
    private int rand;
    public Inventaire inventaire;
    System.Random ran = new System.Random();
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        life=2;
        speed=8;
    }

    void Update()
    {
        switch(currState)//permet de donner lancer une methode lorsque l'on rentre dans un certain état
        {
          
            case(EnemyState.Follow):
                Follow();
            break;
            case(EnemyState.Attack):
                Attack();
            break;
        }
        if(HealthMainCharacter.instance.alive==true){
            if(IsPlayerInRange(range))
            {
                currState = EnemyState.Follow;
            }
         
            if(Vector3.Distance(transform.position, player.transform.position) <= 6 && (!coolDownAttack))//si le temps d'invulnérabilité est passé et que la distance est bonne
            {
                currState = EnemyState.Attack;
            }
       if(life==0){
        Death();
       }
        }
       
    }

    private bool IsPlayerInRange(float range)
    {
        if(HealthMainCharacter.instance.alive==true){
            return Vector3.Distance(transform.position, player.transform.position) <= range;
            }
        return false;
    }


    void Follow()//méthode permettant de suivre le joueur
    {
        if(HealthMainCharacter.instance.alive){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void Attack() //appel de TakeDomage pour enlever de la vie au player
    {
        HealthMainCharacter.instance.TakeDomage(20);
        StartCoroutine(CoolDown());
            
    }
  

    public void TakeDomages(){
        life--;
    }

    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }

    public void Death()//méthode permettant de génerer un item aléatoire ou de ne rien générer à la suite de la mort d'un monstre
    {   
        
 int entierUnChiffre = ran.Next(10); //Génère un entier compris entre 0 et 9
        
        
       
           if(entierUnChiffre>6){
            rand = Random.Range(0, inventaire.objet.Length);
            Instantiate(inventaire.objet[rand], transform.position,inventaire.objet[rand].transform.rotation);
            Destroy(gameObject);
            DeplacementPersoPrincipal.instance.kill++;
           }
        
      else{
            Destroy(gameObject);
            DeplacementPersoPrincipal.instance.kill++;
      } 
       
    }
}

 