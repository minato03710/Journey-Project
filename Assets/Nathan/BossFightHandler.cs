using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BossFightHandler : MonoBehaviour
{

    public float antNestAmount = 4f;
    public GameObject antNest;
    public GameObject Exit;
    public GameObject Door;
    public GameObject QueenAnt;
    public AudioSource BossMusic;
    public AudioSource RegMusic;
    //public List<GameObject> allNests;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision) //Inital Start
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            BossMusic.Play();
            RegMusic.Stop();
            Door.SetActive(true);
            antNest.SetActive(true);
        }
    }
}
