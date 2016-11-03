using UnityEngine;
using System.Collections;

public class AOETrigger : MonoBehaviour {
    private bool flag;
    private GameObject player;
    private float timer;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Queen");
	}
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                player.GetComponent<Player>().getHealthSystem().applyDamage(3);
                timer = 0;
            }
        }
	}

    public void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.tag == "Player")
        {
            flag = true;
        }
    }

    public void onTriggerExit(Collider item)
    {
        flag = false;
    }
}
