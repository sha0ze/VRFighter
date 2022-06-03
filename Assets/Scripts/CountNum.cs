using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountNum : MonoBehaviour
{
    public int num;
    

    void Update()
    {
        num = 4;
        if (!GameObject.Find("Robot_Soldier_Camo1"))
        {
            num--;
        }
        if (!GameObject.Find("Robot_Soldier_Camo2"))
        {
            num--;
        }
        if (!GameObject.Find("Robot_Soldier_Green"))
        {
            num--;
        }
        if (!GameObject.Find("Robot_Soldier_Blue"))
        {
            num--;
        }
    }

}
