using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public bool completed = false;

    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject goal;

    List<int[,]> maze = new List<int[,]>();
    private int[,] currentMaze = new int[11, 11];


    [SerializeField] private int mazeNumber = 0;
    // 5*5の迷路にはx11,y11必要
    // t*tの迷路にはx(t*2+1),y(t*2+1)必要

    [SerializeField] private int plx;
    [SerializeField] private int ply;

    [SerializeField] private int gox;
    [SerializeField] private int goy;

    //0=床 1=壁 2=プレイヤー 3=ゴール 9=目印

    private int[,] maze0 =
    {
        {1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,1,0,0,0,0,0,0,0,1 },
        {1,0,1,1,1,1,1,0,1,1,1 },
        {1,0,1,0,0,0,0,0,0,0,1 },
        {1,0,1,0,1,1,1,1,1,1,1 },
        {1,0,0,0,1,0,1,0,0,0,1 },
        {1,0,1,1,1,0,1,0,1,0,1 },
        {1,0,1,0,0,0,1,0,1,0,1 },
        {1,0,1,0,1,1,1,1,1,0,1 },
        {1,0,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1 }

        /*  
         *  ###########
         *  # #       #
         *  # ##### ###
         *  # #       #
         *  # # #######
         *  #   # #   #
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
        {1,1,1,0,1,1,1,0,1,1,1 },
        {1,0,0,0,0,0,0,0,1,0,1 },
        {1,0,1,1,1,0,1,1,1,0,1 },
        {1,0,1,0,0,0,0,0,1,0,1 },
        {1,0,1,1,1,1,1,1,1,0,1 },
        {1,0,0,0,0,0,0,0,1,0,1 },
        {1,0,1,1,1,1,1,0,1,0,1 },
        {1,0,0,0,1,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1 }

        /*
         *  ###########
         *  #   #     #
         *  ### ### ###
         *  #       # #
         *  # ### ### #
         *  # #     # #
         *  # ####### #
         *  #       # #
         *  # ##### # #
         *  #   #     #
         *  ###########
         */
    };

    private int[,] maze2 =
    {
        {1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,0,0,1,0,1,0,0,0,1 },
        {1,0,1,0,1,0,1,0,1,0,1 },
        {1,0,1,0,0,0,0,0,1,0,1 },
        {1,1,1,1,1,0,1,1,1,1,1 },
        {1,0,0,0,0,0,0,0,0,0,1 },
        {1,1,1,0,1,1,1,0,1,1,1 },
        {1,0,0,0,1,0,1,0,0,0,1 },
        {1,0,1,0,1,0,1,0,1,0,1 },
        {1,0,1,0,0,0,1,0,1,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1 },

        /*  ###########
         *  #   # #   #
         *  # # # # # #
         *  # #     # #
         *  ##### #####
         *  #         #
         *  ### ### ###
         *  #   # #   #
         *  # # # # # #
         *  # #   # # #
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
        maze.Add(maze2);

        mazeNumber = Random.Range(0, 2);
        currentMaze = RotateMaze(maze[mazeNumber], Random.Range(0, 4));

        plx = 2 * Random.Range(1, 5) - 1;//PlayerのX座標決定
        ply = 2 * Random.Range(1, 5) - 1;//PlayerのY座標決定

        gox = 2 * Random.Range(1, 5) - 1;
        goy = 2 * Random.Range(1, 5) - 1;

        currentMaze[ply, plx] = 2;//[y,x]軸が逆なので気を付ける
        currentMaze[goy, gox] = 3;

        CreateMaze(currentMaze);
    }

    private void Update()
    {
        if (!completed) MovePlayer(currentMaze);
    }

    private void CreateMaze(int[,] maze)
    {
        GameObject[] m = GameObject.FindGameObjectsWithTag("Maze");
        foreach (GameObject q in m)
        {
            Destroy(q);
        }

        for (int i = 0; i < maze.GetLength(1); i++) // int[  ,★] x
        {

            //Debug.Log(a);

            for (int j = 0; j < maze.GetLength(0); j++) // int[★,  ] y
            {
                int t = maze[j, i];
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
                else if (t == 3)
                {
                    Instantiate(goal, a, Quaternion.identity);
                }

                a += new Vector3(0f, 0f, -1.5f);
            }

            a.z = 0f;
            a += new Vector3(1.5f, 0f, 0f);
        }
        a = new Vector3(0f, 0f, 0f);
    }

    private void MovePlayer(int[,] maze)
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (maze[ply - 1, plx] == 1)
            {
                Debug.Log("ouch!");
                return;
            }

            if (maze[ply - 2, plx] == 3)
            {
                Debug.Log("clear!");
                completed = true;
            }

            maze[ply - 2, plx] = 2;
            maze[ply, plx] = 0;

            ply -= 2;
            Debug.Log(plx + " , " + ply);

            CreateMaze(maze);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (maze[ply, plx + 1] == 1)
            {
                Debug.Log("ouch!");
                return;
            }

            if (maze[ply, plx + 2] == 3)
            {
                Debug.Log("clear!");
                completed = true;
            }

            maze[ply, plx + 2] = 2;
            maze[ply, plx] = 0;

            plx += 2;
            Debug.Log(plx + " , " + ply);

            CreateMaze(maze);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (maze[ply, plx - 1] == 1)
            {
                Debug.Log("ouch!");
                return;
            }

            if (maze[ply, plx - 2] == 3)
            {
                Debug.Log("clear!");
                completed = true;
            }

            maze[ply, plx - 2] = 2;
            maze[ply, plx] = 0;

            plx -= 2;
            Debug.Log(plx + " , " + ply);

            CreateMaze(maze);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (maze[ply + 1, plx] == 1)
            {
                Debug.Log("ouch!");
                return;
            }

            if (maze[ply + 2, plx] == 3)
            {
                Debug.Log("clear!");
                completed = true;
            }

            maze[ply + 2, plx] = 2;
            maze[ply, plx] = 0;

            ply += 2;
            Debug.Log(plx + " , " + ply);

            CreateMaze(maze);
        }
    }

    private int[,] RotateMaze(int[,] maze, int r)
    {
        int I = maze.GetLength(0);
        int J = maze.GetLength(1);

        if (r == 0)
        {
            return maze;
        }
        else if (r == 1)/*　90度回転　*/ /*　行数列数が入れ替わる　*/
        {
            int[,] a = new int[J, I];
            for (int i = 0; i < J; i++)
            {
                for (int j = 0; j < I; j++)
                {
                    a[i, j] = maze[I - 1 - j, i];
                }
            }
            return a;
        }
        else if (r == 2)
        {
            int[,] a = new int[I, J];
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    a[i, j] = maze[I - 1 - i, J - 1 - j];
                }
            }
            return a;
        }
        else if (r == 3)
        {
            int[,] a = new int[J, I];
            for (int i = 0; i < J; i++)
            {
                for (int j = 0; j < I; j++)
                {
                    a[i, j] = maze[j, J - 1 - i];
                }
            }
            return a;
        }
        else
        {
            Debug.Log("有効な値が入力されていません。");
            return maze;
        }
    }

}
