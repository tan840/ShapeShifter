using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 20;
    [SerializeField] float MoveDelay = 1;
    [SerializeField] Collider m_collider;
    [SerializeField] Rigidbody m_Rb;
 
    public void MovetoPlayerWithDelay(Player player)
    {
        StartCoroutine(MoveToPlayer(player));
    }
    IEnumerator MoveToPlayer(Player player)
    {
        yield return new WaitForSeconds(MoveDelay);
        m_collider.isTrigger = true;
        m_Rb.isKinematic = true;
        print("Move to player");
        while (Vector3.Distance(player.transform.position, transform.position) > 0.25f)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 10f * Time.deltaTime);
        }
        Destroy(gameObject);
    }
}
