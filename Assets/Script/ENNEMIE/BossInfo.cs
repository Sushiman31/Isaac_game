using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossState
{
    Idle,
    Follow,
    Attack
};



public class BossInfo : MonoBehaviour
{
     
    GameObject player;
    public EnemyState currState = EnemyState.Idle;
    
    public float range=20f;
    public float speed;

    public float coolDown;
    private bool coolDownAttack = false;
    private bool coolDownShoot=false;
    public int life=30;
    private float randomShootX;
    private float randomShootY;
    System.Random ran = new System.Random();
    
    [SerializeField] private GameObject bullet;
    public Transform persoTransform;
    private float lastFire;
    public float speedShoot=0.3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        life=30;
        speed=10;
    }

    void Update()
    {
        switch(currState)
        {
          
            case(EnemyState.Follow):
                Follow();
            break;
            case(EnemyState.Attack):
                Attack();
            break;
        }
if(HealthMainCharacter.instance.alive==true){
            if(IsPlayerInRange(range)&& !coolDownShoot)
            {
                currState = EnemyState.Follow;
                ShootBoss();
                
            }
         
            if(Vector3.Distance(transform.position, player.transform.position) <= 6 && (!coolDownAttack))
            {
               
                currState = EnemyState.Attack;
            }
       if(life==0){//si le boss n'a plus de vie,on le supprime,détruit le player et enclenche le menu victoire
            Death();
            WinManager.instance.OnBossDeath();
            Destroy(player);
            HealthMainCharacter.instance.alive=false;

       }
}
    }

    private void ShootBoss()
    {
        //shoot randomly in any direction 
        GameObject shoot=Instantiate(bullet,persoTransform.position,Quaternion.identity);
        shoot.AddComponent<Rigidbody2D>().gravityScale=0;
        Rigidbody2D balleRigidbody=shoot.GetComponent<Rigidbody2D>();
        randomShootX = Random.Range(-1f, 1f);
        randomShootY = Random.Range(-1f, 1f); 
        balleRigidbody.AddForce(new Vector3(
            (randomShootX<0) ? Mathf.Floor(randomShootX)*1000:Mathf.Ceil(randomShootX)*1000,
            (randomShootY<0) ? Mathf.Floor(randomShootY)*1000:Mathf.Ceil(randomShootY)*1000,
            0f
        ));
        StartCoroutine(CoolDownAttaqueBoss());
        

    }

    private bool IsPlayerInRange(float range)
    {
        if(HealthMainCharacter.instance.alive==true){
            return Vector3.Distance(transform.position, player.transform.position) <= range;
            }
        return false;
    }
    void Follow()
    {
        if(HealthMainCharacter.instance.alive==true){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void Attack()
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

    private IEnumerator CoolDownAttaqueBoss()
    {
        coolDownShoot= true;
        yield return new WaitForSeconds(0.2f);
        coolDownShoot = false;
    }


    public void Death()
    {   
       
       Destroy(gameObject);
       
}
}



