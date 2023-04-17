using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Princess : MonoBehaviour
{


    [SerializeField] GameObject Boss;
    EnemyBoss m_bossScript; // xD Hackerman
    void Start()
    {
        m_bossScript = Boss.GetComponent<EnemyBoss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss = null)
        {

        }
    }

    private void OnCollisionEnter(Collision col)
    {   
        if (m_bossScript.IsDead && col.gameObject.CompareTag("Player"))
        {
         
            CanvasManager.Instance.SwitchCanvas(CanvasType.GameOverSuccess);
        }else
        {
            Debug.Log("not player");
        }
    }
}
