using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarScript : MonoBehaviour{
    private float fillAmount;
    [SerializeField]
    private Image content;
    
    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);

        }
    }
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        HandleBar();
    }

    private void HandleBar()
    {
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    private float Map(float value, float min, float max, float outMin, float outMax)
    {
        return (value - min) * (outMax - outMin) / (max - min) + outMin;
    }
}
