using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game01 : MonoBehaviour
{
    public int score;
    public GameObject hitFx;
    
    public List<Game03.Coin> prefabs;
    public List<Transform> spawns;

    private List<Transform> rand_points;
    private List<GameObject> instanced;

    private int maxWeight;

    void Start()
    {
        Init();
       
    }


    public void Init()
    {
        score = 0;

        if (instanced == null)
            instanced = new List<GameObject>();

        foreach (var item in instanced)
        {
            if (item)
                GameObject.Destroy(item);
        }

        instanced.Clear();

        maxWeight = Game03.Coin.GetMaxWeight(prefabs);
        
        // try to spawn targets.
        rand_points = RandomPoints(spawns);
        var count = rand_points.Count;
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }

    List<Transform> RandomPoints(List<Transform> list)
    {
        var _list = new List<Transform>();
        _list.AddRange(list);

        var points = new List<Transform>();
        var count = _list.Count;
        for (int i = 0; i < count; i++)
        {
            var rand = Random.Range(0, _list.Count);
            points.Add(_list[rand]);
            _list.RemoveAt(rand);
        }

        return points;
    }

    void Spawn()
    {
        var point = GetRandomPoint();
        if (point)
        {
            var rand = Random.Range(0, maxWeight);
            var coin = Game03.Coin.GetRandom(prefabs, rand);
            var go = GameObject.Instantiate<GameObject>(coin.prefab);
            var spawn_point = go.GetComponent<RandomSpawnPoint>();
            if (spawn_point)
                go.transform.position = spawn_point.GetPosition;
            else
                go.transform.position = point.position;
            go.transform.rotation = point.rotation;

            go.SetActive(true);

            instanced.Add(go);
        }
    }

    Transform GetRandomPoint()
    {
        if (rand_points.Count > 0)
        {
            var rand = Random.Range(0, rand_points.Count);
            var p = rand_points[rand];

            rand_points.Remove(p);

            return p;
        }
        else
            return null;
    }

    public void RaycastResult(RaycastHit[] hits)
    {
        foreach (var item in hits)
        {
            var t = item.collider.GetComponent<Game01RayTarget>();
            if (t)
            {
                var add_score = t.GotHit();
                score += add_score;

                t.gameObject.SetActive(false);
                // play fx here
            }
        }
    }
}
