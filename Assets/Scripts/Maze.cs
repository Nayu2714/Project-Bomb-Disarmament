using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject player;

    List<int[,]> maze = new List<int[,]>();
    private int[,] currentMaze = new int[11, 11];

    [SerializeField] private int mazeNumber = 0;
    // 5*5の迷路にはx11,y11必要
    // t*tの迷路にはx(t*2+1),y(t*2+1)必要

    [SerializeField] private int plx;
    [SerializeField] private int ply;

    //0=床 1=壁 2=プレイヤー 3=ゴール 

    private int[,] maze0 =
    {
        {1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,1,0,0,0,0,0,0,0,1 },
        {1,0,1,0,1,1,1,0,1,1,1 },
        {1,0,1,0,0,0,0,0,0,0,1 },
        {1,0,1,0,1,1,1,0,1,1,1 },
        {1,0,0,0,0,0,1,0,0,0,1 },
        {1,0,1,1,1,0,1,0,1,0,1 },
        {1,0,1,0,0,0,1,0,1,0,1 },
        {1,0,1,0,1,1,1,1,1,0,1 },
        {1,0,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1 }

        /*  
         *  ###########
         *  # #       #
         *  # # ### ###
         *  # #       #
         *  # # ### ###
         *  #     #   #
         *  # ### # # #
         *  # #   # # #
         *  # # ##### #
         *  #         #
         *  ###########
         */
    };

    private int[,] maze1 =
    {
        {1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,0,0,1,0,0,0,0,0,1 },
        {1,1,1,0,1,1,1,0,1,0,1 },
        {1,0,0,0,0,0,0,0,1,0,1 },
        {1,0,1,1,1,0,1,1,1,0,1 },
        {1,0,1,0,0,0,0,0,1,0,1 },
        {1,0,1,1,1,1,1,0,1,0,1 },
        {1,0,0,0,0,0,0,0,1,0,1 },
        {1,0,1,1,1,1,1,0,1,0,1 },
        {1,0,0,0,1,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1 }

        /*
         *  ###########
         *  #   #     #
         *  ### ### # #
         *  #       # #
         *  # ### ### #
         *  # #     # #
         *  # ##### # #
         *  #       # #
         *  # ##### # #
         *  #   #     #
         *  ###########
         */
    };

    private Vector3 a = new Vector3(0f, 0f, 0f);

    // x1 → unity X+1.5
    // y1 → unity Z-1.5

    private void Start()
    {
        maze.Add(maze0);
        maze.Add(maze1);

        //mazeNumber = Random.Range(0, 2);
        currentMaze = maze[mazeNumber];

        plx = 2 * Random.Range(1, 5) - 1;//PlayerのX座標決定
        ply = 2 * Random.Range(1, 5) - 1;//PlayerのY座標決定

        currentMaze[ply, plx] = 2;//[y,x]軸が逆なので気を付ける

        CreateMaze();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void CreateMaze()
    {
        GameObject[] m = GameObject.FindGameObjectsWithTag("Maze");
        foreach (GameObject q in m)
        {
            Destroy(q);
        }

        for (int i = 0; i < currentMaze.GetLength(1); i++) // int[  ,★] x
        {

            //Debug.Log(a);

            for (int j = 0; j < currentMaze.GetLength(0); j++) // int[★,  ] y
            {
                int t = currentMaze[j, i];
                if (t == 0)
                {
                    Instantiate(floor, a, Quaternion.identity);
                }
                else if (t == 1)
                {
                    Instantiate(wall, a, Quaternion.identity);
                }
                else if (t == 2)
                {
                    Instantiate(player, a, Quaternion.identity);
                }

                a += new Vector3(0f, 0f, -1.5f);
            }

            a.z = 0f;
            a += new Vector3(1.5f, 0f, 0f);
        }
        a = new Vector3(0f, 0f, 0f);
    }

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMaze[ply - 1, plx] == 1)
            {
                Debug.Log("ouch!");
            }
            else
            {
                currentMaze[ply - 2, plx] = 2;
                currentMaze[ply, plx] = 0;

                ply -= 2;
                Debug.Log(plx + " , " + ply);
            }
            CreateMaze();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMaze[ply, plx + 1] == 1)
            {
                Debug.Log("ouch!");
            }
            else
            {
                currentMaze[ply, plx + 2] = 2;
                currentMaze[ply, plx] = 0;

                plx += 2;
                Debug.Log(plx + " , " + ply);
            }
            CreateMaze();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMaze[ply, plx - 1] == 1)
            {
                Debug.Log("ouch!");
            }
            else
            {
                currentMaze[ply, plx - 2] = 2;
                currentMaze[ply, plx] = 0;

                plx -= 2;
                Debug.Log(plx + " , " + ply);
            }
            CreateMaze();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMaze[ply + 1, plx] == 1)
            {
                Debug.Log("ouch!");
            }
            else
            {
                currentMaze[ply + 2, plx] = 2;
                currentMaze[ply, plx] = 0;

                ply += 2;
                Debug.Log(plx + " , " + ply);
            }
            CreateMaze();
        }
    }

}
