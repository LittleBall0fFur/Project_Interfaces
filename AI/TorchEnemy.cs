using UnityEngine;
using System.Collections;

public class TorchEnemy : MonoBehaviour
{
    private GameObject player;
    private GameObject[] enemies;
    private HealthSystem health;
    private float distance;
    private float timer;
    // Use this for initialization
    void Start()
    {
        health = new HealthSystem();
        health.setHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        health.deathCheck();
        death();
    }

    public HealthSystem getHealthSystem()
    {
        return health;
    }

    private void death()
    {
        if (health.deathCheck() == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void movement()
    {
        player = GameObject.Find("Queen");
        distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (distance <= 3)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                // this.gameObject.GetComponent<Animation>().CrossFadeQueued("run", 0.3f, QueueMode.PlayNow);
                //  this.gameObject.GetComponent<Animation>().CrossFade("attack");
                player.GetComponent<Player>().getHealthSystem().applyDamage(5);
                timer = 0f;
            }
        }
        else if (distance < 5 && distance > 2f)
        {
            // this.gameObject.GetComponent<Animation>().CrossFadeQueued("attack", 0.3f, QueueMode.PlayNow);
            // this.gameObject.GetComponent<Animation>().CrossFade("run");
            this.gameObject.transform.LookAt(player.transform.position);
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, 0.15f);
        }

        else
        {
            //this.gameObject.GetComponent<Animation>().CrossFadeQueued("run", 0.3f, QueueMode.PlayNow);
            // this.gameObject.GetComponent<Animation>().CrossFade("idle");
        }
    }
}