using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpPad : MonoBehaviour
{
    [SerializeField] Transform m_JumpPad;
    [SerializeField] Transform m_destinationPoint;
    bool hasInteracted = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hasInteracted) return;
            hasInteracted = true;
            Player m_PlayerScript = other.GetComponent<Player>();
            m_PlayerScript.CanMove = false;
            print("Player Entered");
            m_JumpPad.DOBlendableLocalMoveBy(new Vector3(0,0,0), 0.1f).OnComplete(() => {

                other.transform.DOJump(m_destinationPoint.position, 20, 0, 2f).SetEase(Ease.InFlash).OnComplete(() => {

                    m_PlayerScript.CanMove = true;
                });
            });
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(m_destinationPoint.position, Vector3.one);
    }
}
