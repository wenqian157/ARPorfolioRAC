//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShowHideObject : MonoBehaviour
//{
//    public GameObject designA;
//    public GameObject designB;
//    public GameObject landscape;

//    private void Start()
//    {
//        designA.SetActive(true);
//        designB.SetActive(false);
//    }
//    public void OnUISwitchDesign()
//    {
//        designA.SetActive(!designA.activeSelf);
//        designB.SetActive(!designB.activeSelf);
//    }
//    public void OnUIShowOrHide()
//    {

//        landscape.SetActive(!landscape.activeSelf);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObject1 : MonoBehaviour
{
    public GameObject[] designAObjects; // 用于存储 designA 内的三个物件
    public GameObject designB;
    public GameObject landscape;

    private int state = 0; // 状态变量

    private void Start()
    {
        SetActiveForObjects(designAObjects, true);
        designB.SetActive(true); // 确保 designB 在开始时也是显示的
    }

    public void OnUISwitchDesign()
    {
        switch (state)
        {
          
            case 0:
                // 隐藏 designA
                SetActiveForObjects(designAObjects, false);
                state = 1;
                break;
            case 1:
                // 显示 designA，隐藏 designB
                SetActiveForObjects(designAObjects, true);
                designB.SetActive(false);
                state = 2; // 这里改为0，使得下次按键直接进入显示所有物件的状态
                break;  
            case 2:
             
                SetActiveForObjects(designAObjects, true);
                designB.SetActive(true);
                state = 0;
                break;
        }
    }

    public void OnUIShowOrHide()
    {
        landscape.SetActive(!landscape.activeSelf);
    }

    private void SetActiveForObjects(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isActive);
        }
    }
}


