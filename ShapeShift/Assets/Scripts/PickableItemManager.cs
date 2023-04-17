using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles Pickable Items
/// </summary>

public class PickableItemManager : MonoBehaviour
{
    [SerializeField] GameObject m_CoinPrefab;
    [SerializeField] GameObject m_KeyPrefab;
    [SerializeField] int SpawnCount = 5;
    [SerializeField] Player m_Player;
    public void SpawnPickable(int _itemIndex, Transform _SpawnPoint)
    {
        Vector3 spawnPos = _SpawnPoint.position;
        if (_itemIndex <= 1)
        {
           StartCoroutine(SpawnItemWithDelay(m_CoinPrefab, spawnPos));
        }
        else
        {
            StartCoroutine(SpawnItemWithDelay(m_KeyPrefab, spawnPos));
        }
        
    }
    IEnumerator SpawnItemWithDelay(GameObject prefab, Vector3 _SpawnPosition)
    {     
        GameObject item;
        for (int i = 0; i < SpawnCount; i++)
        {
            //print("Spawnned");
            item = Instantiate(prefab);
            Coin coin = item.GetComponent<Coin>();
            coin.MovetoPlayerWithDelay(m_Player);
            item.transform.position = _SpawnPosition + new Vector3(0, 5,0);
            Rigidbody rb = item.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Random.Range(-5, 5), Random.Range(0, 15), Random.Range(-5, 5)) , ForceMode.Impulse);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
