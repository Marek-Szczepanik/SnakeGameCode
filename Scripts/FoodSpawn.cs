using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] BoxCollider2D GridArea;

       void Start()
    {
        spawnFood();
    }
    private void spawnFood(){
        Bounds bounds = this.GridArea.bounds;
        float x = Random.Range(bounds.min.x,bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0);

    }
    private void  OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            spawnFood();
            this.GetComponent<AudioSource>().Play();
        }
         
    }
}
