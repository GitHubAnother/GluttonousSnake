/*
作者名称:YHB

脚本作用:控制蛇的方向以及其他的逻辑

建立时间:2016.8.5.19.53
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    #region 字段
    public float moveSpeed = 0.3f;//移动速度
    public GameObject player;
    public GameObject Main;

    private Vector2 dir = Vector2.right;
    private List<Transform> tail = new List<Transform>();
    private bool ate = false;
    #endregion

    #region Unity内置函数
    void Start()
    {
        InvokeRepeating("Move", 0.5f, moveSpeed);
    }
    void Update()
    {
        Controller();
    }
    #endregion

    #region 自动移动的方法
    void Move()
    {
        Vector2 v = this.transform.position;

        this.transform.Translate(dir);

        if (ate)
        {
            GameObject go = Instantiate(player, v, Quaternion.identity) as GameObject;
            tail.Insert(0, go.transform);//生成一个后直接在开头插入进去
            ate = false;//设置false就不会再次生成了，除非又吃到了食物
        }
        else if (tail.Count > 0)
        {
            tail.Last().position = v;//将集合里面最后一个元素的位置设置到当前的蛇头的位置，这个是在移动的时候计算的，不是吃到食物
            //上面只是设置了位置，在集合里面顺序没有发生改变
            tail.Insert(0, tail.Last());//这才是直接将集合里面最后一个元素拿出来插入到开头，但是这样的话实际上集合里面是多了一个元素的
            tail.RemoveAt(tail.Count - 1);//多了一个元素就将它删除掉，一定要删除集合里面的最后一个元素
        }
    }
    #endregion

    #region 键盘控制方向
    void Controller()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
    }

    #endregion

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "L")
        {
            ate = true;

            Destroy(collision.gameObject);
        }
        else
        {
            //游戏失败，出现游戏结束的UI界面，直接销毁player
            Main.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
