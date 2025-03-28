using UnityEngine;

public class AddRoom : MonoBehaviour
{
  private RoomTemplates templates;
  void Start(){
    templates=GameObject.FindGameObjectWithTag("rooms").GetComponent<RoomTemplates>();
    templates.rooms.Add(this.gameObject);
  }
}
