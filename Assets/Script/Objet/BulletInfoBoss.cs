using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class BulletInfoBoss : MonoBehaviour

{

    private void Start(){

        StartCoroutine(WaitUntilDestruction());

       

    }




    private IEnumerator WaitUntilDestruction(){

        yield return new WaitForSeconds(2);

        Destroy(gameObject);

       

    }



    
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.tag=="Player"){

            collision.gameObject.GetComponent<HealthMainCharacter>().TakeDomage(20);

            Destroy(gameObject);

        }

        if(collision.tag=="decor"){

            Destroy(gameObject);

           

    }

    }



}