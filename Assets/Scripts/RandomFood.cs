/*
作者名称:YHB

脚本作用:随机生成食物

建立时间:2016.8.5.19.53
*/

using UnityEngine;
using System.Collections;

public class RandomFood : MonoBehaviour
{
    #region 字段
    public float randomTine = 16f;
    public GameObject L;

    private Transform HT;//横上
    private Transform HD;//横下
    private Transform VL;//纵左
    private Transform VR;//纵右
    #endregion

    #region Unity内置函数
    void Awake()
    {
        HT = this.transform.FindChild("HT").transform;
        HD = this.transform.FindChild("HD").transform;
        VL = this.transform.FindChild("VL").transform;
        VR = this.transform.FindChild("VR").transform;
    }
    void Start()
    {
        InvokeRepeating("RandomCreate", 1f, randomTine);
    }
    #endregion

    #region  循环调用的生成方法
    void RandomCreate()
    {
        int x = (int)Random.Range(VL.position.x, VR.position.x);
        int y = (int)Random.Range(HD.position.y, HT.position.y);

        Instantiate(L, new Vector2(x, y), Quaternion.identity);
    }
    #endregion
}
