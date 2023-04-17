using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CamFollower : MonoBehaviour
{
    
    public Transform Player;


    private void Start()
    {
        transform.position = Player.position + new Vector3(0, 10, 0);
    }
    void Update()
    {
        //follows the player for rendering map.
        transform.position = new Vector3(transform.position.x,transform.position.y,Player.position.z); 
    }
}
