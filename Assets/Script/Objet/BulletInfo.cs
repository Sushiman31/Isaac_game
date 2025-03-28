using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    public MonsterInfo monsterLife;
    private void Start(){
        StartCoroutine(WaitUntilDestruction());//permet de détruire les balles au bout d'un certain temps
        
    }


    private IEnumerator WaitUntilDestruction(){
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="monster"){
            collision.gameObject.GetComponent<MonsterInfo>().TakeDomages();//si collision avec un monstre on enlève de la vie à celui-ci et on détruit la balle
            Destroy(gameObject);
        }
        if(collision.tag=="boss"){
            collision.gameObject.GetComponent<BossInfo>().TakeDomages();//si collision avec le boss on enlève de la vie à celui-ci et on détruit la balle
            Destroy(gameObject);
        }
        if(collision.tag=="decor"){
            Destroy(gameObject);
            
    }
    }

}
