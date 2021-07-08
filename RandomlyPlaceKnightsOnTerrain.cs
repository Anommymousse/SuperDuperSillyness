using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomlyPlaceKnightsOnTerrain : MonoBehaviour
{
    float width = 100f;
    float length = 1250f;
    public float widthScale = 1f;
    public float lengthScale = 1f;
    public int amountToPlace = 80;
    public GameObject KnightReference;
    List<GameObject> KnightRandomInstances;
    Vector3 _position;
    void Start()
    {
        
    }

    void Awake()
    {
        KnightRandomInstances = new List<GameObject>(amountToPlace);
        KnightRandomInstances.Clear();
        for (int i = 0; i < amountToPlace; i++)
        {
            var randomz = Random.Range(40f, 1100f);
            var randomx = Random.Range(10f, 80f);
            _position.x = randomx;
            _position.y = 180f;
            _position.z = randomz;
            var knightInstance = Instantiate(KnightReference, _position, Quaternion.identity);
            Debug.Log($"Hmmmmmm {i}"); 
            KnightRandomInstances.Add(knightInstance);       
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
