using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_TextFollower : MonoBehaviour
{
    public Transform Player;
    [SerializeField] float offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x, Player.position.y + offset, Player.position.z);
    }
}
