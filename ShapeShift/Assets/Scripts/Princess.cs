using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Princess : MonoBehaviour
{


    [SerializeField] GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Boss == null && col.gameObject.CompareTag("Player"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            CanvasManager.Instance.SwitchCanvas(CanvasType.GameOverSuccess);
        }
    }
}
