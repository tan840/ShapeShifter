using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 15;
    [SerializeField] float MoveDelay = 1;
    [SerializeField] Collider m_collider;
    [SerializeField] Rigidbody m_Rb;
 
    //Call function for moving towards player
    public void MovetoPlayerWithDelay(Player player)
    {
        StartCoroutine(MoveToPlayer(player));
    }

    //coin movement towards player after falling on the ground
    IEnumerator MoveToPlayer(Player player)
    {
        yield return new WaitForSeconds(MoveDelay);
        m_collider.isTrigger = true;
        m_Rb.isKinematic = true;
        //print("Move to player");
        while (Vector3.Distance(player.transform.position, transform.position) > 1f)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
        }
        CanvasManager.Instance.CoinIncriment();
        gameObject.SetActive(false);
        Destroy(gameObject, 0.5f);
    }
}
