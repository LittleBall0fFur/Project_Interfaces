using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private HealthSystem health;
    private float movementSpeed = 7;
    private float turningSpeed = 180;
    private float deathTimer = 0;
    private GameObject player;
    private GameObject[] enemies;
    private GameObject endBoss;
    private int notAttacking = 0;
    private bool flag = false;
    [SerializeField]
    private BarScript bar;

    void Start()
    {
        health = new HealthSystem();
        health.setHealth(100);
        endBoss = GameObject.Find("EndBoss");
    }

    void Update() {
        attack();
        animationHandler();
        movement();
        health.healthbarUpdate();
        health.deathCheck();
        health.regeneration();
        checkEndGame();
    }

    private void movement()
    {
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
    }

    public HealthSystem getHealthSystem()
    {
        return health;
    }

    public BarScript getBarScript()
    {
        return bar;
    }

    private void animationHandler()
    {
        notAttacking++;
        player = GameObject.Find("Queen");
        if (Input.GetAxis("Vertical") > 0.2 && Input.GetKey("w"))
        {
            player.GetComponent<Animation>().CrossFade("Walk");
        }
        else if (Input.GetAxis("Vertical") < 0.2 && notAttacking >= 60)
        {
            player.GetComponent<Animation>().Stop("Idle");
            player.GetComponent<Animation>().CrossFade("Idle");
        }
    }

    private void attack()
    {
        player = GameObject.Find("Queen");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (Input.GetMouseButtonDown(0))
        {
            notAttacking = 0;
            player.GetComponent<Animation>().Stop("Idle");
            player.GetComponent<Animation>().CrossFade("Attack");
            if(enemies != null) {
                foreach(GameObject enemy in enemies)
                {
                    float distance = Vector3.Distance(enemy.transform.position, transform.position);
                    if (distance < 3.2f)
                    {
                        if(enemy.name == "FireEnemy1" || enemy.name == "FireEnemy2") enemy.GetComponent<TorchEnemy>().getHealthSystem().applyDamage(10);
                        if (enemy.name == "valkier2") enemy.GetComponent<Grunt>().getHealthSystem().applyDamage(5);
                        if (enemy.name == "EndBoss") enemy.GetComponent<EndBoss>().getHealthSystem().applyDamage(30);
                    }
                }
            }
        }
    }

    private void checkEndGame()
    {
        if (endBoss != null && endBoss.GetComponent<EndBoss>().getHealthSystem().deathCheck() == true)
        {
            flag = true;
        }
        if(flag == true)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer > 4f) SceneManager.LoadScene("Menu");
        }
    }
}
