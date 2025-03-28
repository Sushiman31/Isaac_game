using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public  GameObject player;
    public float timeOffset;
    public Vector3 posCam;
    private Vector3 velocity;

    void Update(){
        if(HealthMainCharacter.instance.alive==true){
        transform.position=Vector3.SmoothDamp(transform.position,player.transform.position+posCam,ref velocity,timeOffset);
    }
    }
}
