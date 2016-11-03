using UnityEngine;
using System.Collections;

public class EndBoss : MonoBehaviour {
    private GameObject player;
    private GameObject aoe;
    private GameObject[] aoes;
    private HealthSystem health;
    private float distance;
    private float timer;
    private float deathTimer = 0;
    [SerializeField]
    private Material texture;
    // Use this for initialization
    void Start()
    {
        health = new HealthSystem();
        health.setHealth(400);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        health.deathCheck();
        death();
        aoeList();
        deleteAoe();
    }

    public HealthSystem getHealthSystem()
    {
        return health;
    }

    private void death()
    {
        if (health.deathCheck() == true)
        {
            //play death animation
            deathTimer += Time.deltaTime;
           // if (deathTimer > 5f)
           // {
                Destroy(this.gameObject);
          //  }
        }
    }

    private void movement()
    {
        if (health.deathCheck() == false) {
            player = GameObject.Find("Queen");
            distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
            if (distance <= 5)
            {
               //run away
            }
            else if (distance < 15 && distance > 0f)
            {
                timer += Time.deltaTime;
                if(timer > 2)
                {
                    attack();
                    timer = 0;
                }
            }

            else
            {
                //this.gameObject.GetComponent<Animation>().CrossFadeQueued("run", 0.3f, QueueMode.PlayNow);
                // this.gameObject.GetComponent<Animation>().CrossFade("idle");
            }
        }
    }

    private void attack()
    {
        print("attack");
        spawnAOE();
    }

    private void spawnAOE()
    {
        aoe = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //Add TexturegameObject.renderer.material.mainTexture = myTexture;
        aoe.GetComponent<Renderer>().material = texture;
        aoe.GetComponent<CapsuleCollider>().isTrigger = true;
        aoe.AddComponent<AOETrigger>();
        aoe.name = "Aoe";
        aoe.tag = "Aoe";
        aoe.transform.position = player.transform.position;
    }

    private void deleteAoe()
    {
       if(aoes.Length > 6)
        {
            Destroy(aoes[0]);
        }
    }

    private void aoeList()
    {
        aoes = GameObject.FindGameObjectsWithTag("Aoe");
    }
}
