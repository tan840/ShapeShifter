using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using TMPro;
using UnityEngine.SceneManagement;
//using GameAnalyticsSDK;
//using Hamba.CoreGameTemplate;
public enum CanvasType
{
    StartScene,
    GameScene,
    GameOverSuccess,
    GameOverFail
}
public class CanvasManager : MonoBehaviour
{
    private static CanvasManager _instance;
    CanvasEntity m_currentActiveCanvas;
    [SerializeField] TMP_Text m_Coin;
    int m_CoinCount = 0;
    public static CanvasManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (CanvasManager)FindObjectOfType(typeof(CanvasManager));

                if (FindObjectsOfType(typeof(CanvasManager)).Length > 1)
                {
                    Debug.LogWarning("There is more than one manager of this type in this scene : " + typeof(CanvasManager).Name);
                    return _instance;
                }

                if (_instance == null) return null;
            }

            return _instance;

        }
    }

    public TMP_Text LevelText { get => m_LevelText; set => m_LevelText = value; }

    [SerializeField] List<CanvasEntity> m_CanvasEntities;
    bool isGameStarted = false;
    [SerializeField] TMP_Text m_LevelText;
    private void OnEnable()
    {
        LeanTouch.OnFingerDown += OnFingerDown;  
    }
    private void OnDisable()
    {
        LeanTouch.OnFingerDown -= OnFingerDown;
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        m_CanvasEntities.ForEach(x => x.gameObject.SetActive(false));
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SwitchCanvas(CanvasType.StartScene);
            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, LevelController.Instance.ActualLevelNumber.ToString());
        }
        m_Coin.text = 0.ToString();
        //LeanTouch.OnFingerDown += OnFingerDown;
        isGameStarted = false;
    }
    public void CoinIncriment()
    {
        m_CoinCount++;
        m_Coin.text = m_CoinCount.ToString();
    }
    void OnFingerDown(LeanFinger Finger)
    {
        if (!isGameStarted)
        {
            isGameStarted = true;
            SwitchCanvas(CanvasType.GameScene);
        }
    }
    public void SwitchCanvas(CanvasType _type, float time = 0)
    {
       StartCoroutine(SwitchMenu(_type, time));
    }
    IEnumerator SwitchMenu(CanvasType _type , float time)
    {
        yield return new WaitForSeconds(time);
        if (_type == CanvasType.GameOverSuccess)
        {
            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, LevelController.Instance.ActualLevelNumber.ToString());
        }
        else if (_type == CanvasType.GameOverFail)
        {
            //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, LevelController.Instance.ActualLevelNumber.ToString());
        }
        if (m_currentActiveCanvas != null)
        {
            m_currentActiveCanvas.gameObject.SetActive(false);
        }
        ActivateCanvas(_type);
    }
    void ActivateCanvas(CanvasType _Type)
    {
        CanvasEntity desiredCanvas = m_CanvasEntities.Find(x => x.canvasType == _Type);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            m_currentActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("CanvasNotFound");
        }
    }
}
