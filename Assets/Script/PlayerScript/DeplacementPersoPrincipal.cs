using UnityEngine;

public class DeplacementPersoPrincipal : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 velocity=Vector3.zero;
    private int moveSpeed=700;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public int kill=0;
    public static DeplacementPersoPrincipal instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DeplacementPersoPrincipal dans la scène");
            return;
        }

        instance = this;
    }
    
   
    void FixedUpdate()
    {
        float horizontalMovement=Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float verticalMovement=Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        MovePlayer(horizontalMovement,verticalMovement);  
        
        Flip(rb.velocity.x);//permet de renverser le sens du sprite en fonction de son deplacement en x positif ou négatif

        float characterVelocityX=Mathf.Abs(rb.velocity.x);
        float characterVelocityY=Mathf.Abs(rb.velocity.y);
        animator.SetFloat("SpeedX",characterVelocityX);//change les variables dans l'animator pour activer la bonne animation
         animator.SetFloat("SpeedY",characterVelocityY);
        
    }

    void MovePlayer(float _horizontalMovement,float _verticalMovement){
        Vector3 targetVelocity=new Vector2(_horizontalMovement,_verticalMovement);
        rb.velocity=Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity,.05f);//SmoothDamp permet d'avoir un effet visuel plus jolie à regarder pendant le deplacement
    }

    void Flip(float _velocity){
        if(_velocity>0.1f){
            spriteRenderer.flipX=false;
        }
        else if(_velocity<-0.1f){
            spriteRenderer.flipX=true;
        }
    }

    public void IncreaseSpeed(int _x){//augmente la vitesse du personnage
        moveSpeed+=_x;
    }
}
