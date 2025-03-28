using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirePersoPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public Transform persoTransform;
    private float lastFire;
    public float speedShoot=0.5f;
    public static TirePersoPrincipal instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de TirePersoPrincipal dans la scène");
            return;
        }

        instance = this;
    }

    
    
    private void Shoot(float _x,float _y)
    {
        GameObject shoot=Instantiate(bullet,persoTransform.position,Quaternion.identity);
        shoot.AddComponent<Rigidbody2D>().gravityScale=0;
        Rigidbody2D balleRigidbody=shoot.GetComponent<Rigidbody2D>();
        balleRigidbody.AddForce(new Vector3(//en fonction de la position de la balle on lui donne une vitesse et un sens de propagation
            (_x<0) ? Mathf.Floor(_x)*1000:Mathf.Ceil(_x)*1000,
            (_y<0) ? Mathf.Floor(_y)*1000:Mathf.Ceil(_y)*1000,
            0f
        ));
    }
    public void IncreaseShootFrequency(float _x){
       if(_x!=0){ 
        speedShoot=speedShoot*_x;
       }
    }

    // Update is called once per frame
    void Update()
    {   
        float ShootHori=Input.GetAxis("ShootHorizontal");//génère des balles en fonction du bouton
        float ShootVerti=Input.GetAxis("ShootVertical");
        if((Input.GetAxis("ShootHorizontal")!=0 || Input.GetAxis("ShootVertical")!=0) && (Time.time>lastFire+speedShoot)){//les balles ne sont créees que si le temps d'attente est passé
                Shoot(ShootHori,ShootVerti);
                lastFire=Time.time;
        }
    }
}
