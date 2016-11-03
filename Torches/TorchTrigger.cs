using UnityEngine;
using System.Collections;


public class TorchTrigger : MonoBehaviour {
    private bool flag;
    private GameObject p;
    private GameObject gate;
    private Vector3 position;
    private GameObject torch;
    private GameObject light;
    private GameObject fence;
    private float timer;
    private bool notPlayed = true;
    // Update is called once per frame
    void Start()
    {
        if (this.gameObject.name == "FirstPillar")
        {
            p = GameObject.Find("ParticleSystem1");
            p.GetComponent<Renderer>().enabled = false;
            light = GameObject.Find("Light1");
            light.SetActive(false);
            gate = GameObject.Find("Fence1");
            position = new Vector3(gate.transform.position.x, 3, gate.transform.position.z);
            torch = GameObject.Find("Torch1");
            
        }
        else if (this.gameObject.name == "SecondPillar")
        {
            p = GameObject.Find("ParticleSystem2");
            p.GetComponent<Renderer>().enabled = false;
            light = GameObject.Find("Light2");
            light.SetActive(false);
            gate = GameObject.Find("Fence2");
            position = new Vector3(gate.transform.position.x, 3, gate.transform.position.z);
            torch = GameObject.Find("Torch2");
        }
        
    }

	void Update () {
        if (flag)
        {
           timer += Time.deltaTime;
            p.GetComponent<Renderer>().enabled = true;
            light.SetActive(true);
            gate.transform.position = Vector3.MoveTowards(gate.transform.position, position, 0.15f);
            AudioSource audio = gate.GetComponent<AudioSource>();
            if (notPlayed)
            {
                audio.Play(1);
                notPlayed = false;
            }
            if (timer >= 5) audio.Stop();
            Destroy(torch);
        }
	}
 
    public void OnTriggerEnter(Collider item)
    {
        if (item.gameObject.tag == "Player")
        {
            notPlayed = true;
            flag = true;
        }
    }
}
