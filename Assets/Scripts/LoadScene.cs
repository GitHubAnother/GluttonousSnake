/*
作者名称:YHB

脚本作用:切换场景

建立时间:2016.8.5.21.33
*/

using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour
{
    public void LoadScenes()
    {
        if (Application.loadedLevel == 0)
        {
            Application.LoadLevel(1);
        }
        else
        {
            Application.LoadLevel(0);
        }
    }
}
