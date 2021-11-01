using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Common class for Turrets and Enemies
public class CommonClass : MonoBehaviour

{
    [SerializeField] public int health = 10;
    [SerializeField] public float cooldown = 1;
    [SerializeField] public int goldValue = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Die() // Turrets and Enemies have the same death routine
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 0.2f, ForceMode.Impulse);
        GetComponent<Transform>().Rotate (0,50,0*Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Global>().credits += goldValue;
        Destroy(gameObject);
    }
}