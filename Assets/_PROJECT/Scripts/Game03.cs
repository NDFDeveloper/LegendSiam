using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game03 : MonoBehaviour
{
    public int score;

    public float coinRate = 0.2f;
    private float _next_coin;

    public Transform spawner;
    public Game03Bucket bucket;

    [System.Serializable]
    public class Coin
    {
        public int weight = 1;
        public GameObject prefab;

        public static int GetMaxWeight(List<Coin> prefabs)
        {
            var count = 0;
            foreach (var item in prefabs)
            {
                count += item.weight;
            }

            return count;
        }

        public static Coin GetRandom(List<Coin> prefabs, float value)
        {
            foreach (var item in prefabs)
            {
                if (value < item.weight)
                    return item;
                value -= item.weight;
            }

            return prefabs[prefabs.Count - 1];
        }
    }
    public List<Coin> coinPrefabs;
    private int maxWeight;

    List<Game03Target> list;
    
    void Start()
    {
        list = new List<Game03Target>();

        maxWeight = Coin.GetMaxWeight(coinPrefabs);
        
        bucket.onGet.AddListener(OnGetCoin);   
    }
    
    void FixedUpdate()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i])
            {
                list[i].collider.position = bucket.projection(list[i].transform.position);
            }
            else
            {
                list.RemoveAt(i--); // clear null item
            }
                
        }

        if (Time.time > _next_coin)
        {
            _next_coin = Time.time + coinRate;
            SpawnCoin();
        }
        
    }

    void SpawnCoin()
    {
        var rand = Random.Range(0, maxWeight);
        var coin = Coin.GetRandom(coinPrefabs, rand);
        var go = GameObject.Instantiate<GameObject>(coin.prefab, spawner.position, spawner.rotation);
        go.SetActive(true);

        list.Add(go.GetComponent<Game03Target>());
    }

    void OnGetCoin(Game03Target coin)
    {
        score += coin.score;
        GameObject.Destroy(coin.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(spawner.position, 1f);
    }
}
