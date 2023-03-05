using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesScript : MonoBehaviour
{
    [SerializeField] List<GameObject> Choice;
    [SerializeField] GameObject empty;

    List<GameObject> choiseInstances;
    List<bool> avalible;
    private int currentlyAvalible;

    void Start()
    {
        choiseInstances = new List<GameObject>();
        avalible = new List<bool>();
        for (int i = 0; i < Choice.Count; i++)
        {
            avalible.Add(true);
        }
        currentlyAvalible = avalible.Count;
    }

    void Update()
    {
        foreach (GameObject item in choiseInstances)
        {
            if (item.activeInHierarchy == false)
            {
                int i = choiseInstances.IndexOf(item);
                avalible[i] = false;
                currentlyAvalible--;
                DestoryRest();
            }
        }
    }

    public void Multiplechoices()
    {
        for (int i = 0; i < Choice.Count; i++)
        {
            if (avalible[i] == true)
            {
                choiseInstances.Add(Instantiate(Choice[i], new Vector2(transform.position.x + i*5, transform.position.y), Choice[i].transform.rotation));
            }
            else
            {
                choiseInstances.Add(Instantiate(empty, new Vector2(transform.position.x + i*5, transform.position.y), Choice[i].transform.rotation));
            }
        }
    }


    public void DestoryRest()
    {
        foreach (GameObject item in choiseInstances)
        {
            Destroy(item);
        }
        choiseInstances.Clear();
    }
}