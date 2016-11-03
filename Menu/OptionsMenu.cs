using UnityEngine;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
    private bool OptionA = false;
    private bool OptionB = false;

    public void onClick()
    {
        if (OptionA) Screen.SetResolution(1920, 1080, true);
        else if(OptionB) Screen.SetResolution(1360, 768, true);
    }

    public void setA()
    {
        OptionB = false;
        OptionA = true;
    }

    public void setB()
    {
        OptionA = false;
        OptionB = true;
    }
}
