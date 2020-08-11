using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game04 : MonoBehaviour
{

    public int score;

    Game04RayTarget current;
    public List<Game04RayTarget> prefabs;
    public List<Transform> spawnPoints;

    private List<GameObject> instanced;

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


        // spawn 6 targets
        var list = new List<Game04RayTarget>();
        foreach (var item in prefabs)
        {
            var go = GameObject.Instantiate<Game04RayTarget>(item);
            var go2 = GameObject.Instantiate<Game04RayTarget>(item);
            list.Add(go);
            list.Add(go2);

            instanced.Add(go.gameObject);
            instanced.Add(go2.gameObject);
        }

        // random index
        var random_sort = new List<Game04RayTarget>();
        var count = list.Count;
        for (int i = 0; i < count; i++)
        {
            var rand = Random.Range(0, list.Count);
            random_sort.Add(list[rand]);
            list.RemoveAt(rand);
        }

        // set positions
        for (int i = 0; i < random_sort.Count; i++)
        {
            random_sort[i].transform.position = spawnPoints[i].position;
            random_sort[i].transform.rotation = spawnPoints[i].rotation;
        }

    }


    public void RaycastResult(RaycastHit[] hits)
    {
        foreach (var item in hits)
        {
            var t = item.collider.GetComponent<Game04RayTarget>();
            if (t)
            {
                Select(t);
            }
        }
    }

    void Select(Game04RayTarget t)
    {
        if (current == null)
        {
            current = t;
            t.Select();
        }
        if (current == t)
        {
            // self
            // do nothing.
        }
        else
        {
            t.Select();
            if (current.id == t.id)
            {
                // match
                t.MatchFx();
                score++;
            }
            else
            {
                // failed then reset
                current.Unselect();
                t.Unselect();
            }

        }
    }
}
