using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {
    private GameObject enemy;
    private GameObject player;
    private GameObject torch;

	// Use this for initialization
	void Start () {
        if (this.gameObject.name == "Torch1")
        {
            enemy = GameObject.Find("FireEnemy1");
            torch = GameObject.Find("Torch1");
        }
        else if (this.gameObject.name == "Torch2")
        {
            enemy = GameObject.Find("FireEnemy2");
            torch = GameObject.Find("Torch2");
        }
        player = GameObject.Find("Queen");
    }
	
	// Update is called once per frame
	void Update () {
        if (enemy!= null && !enemy.GetComponent<TorchEnemy>().getHealthSystem().deathCheck())
        {
            torch.transform.position = enemy.transform.position;
        }
        else
        {
            torch.transform.position = player.transform.position;
        }
        
	}
}
