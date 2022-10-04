using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public bool completed = false;
    public CursorManager cursorManager;

    [Space(5)]

    List<int[,]> maze = new List<int[,]>();
    private int[,] currentMaze = new int[11, 11];

    //迷路の形状を二次元配列にて設定
    // 5*5の迷路にはx11,y11必要
    // t*tの迷路にはx(t*2+1),y(t*2+1)必要
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

    [SerializeField] private int mazeNumber = 0;
    [SerializeField] private int startEndGenFunction = 3;

    [Space(5)]

    [SerializeField] private int plx = 0;
    [SerializeField] private int ply = 0;
    [Space(1)]
    [SerializeField] private int gox = 0;
    [SerializeField] private int goy = 0;

    [Space(5)]

    [SerializeField] private GameObject invisibleWall;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject passage;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject goal;
    [Space(1)]
    [SerializeField] private GameObject upper;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject lower;
    [Space(1)]
    [SerializeField] private GameObject displaySquare;
    [SerializeField] private GameObject displayVWall;
    [SerializeField] private GameObject displayHWall;

    private void Start()
    {
        maze.Add(maze0);
        maze.Add(maze1);
        maze.Add(maze2);

        mazeNumber = Random.Range(0, 2);
        currentMaze = RotateMaze(maze[mazeNumber], Random.Range(0, 4));

        while (!(((Mathf.Abs(plx - gox) + Mathf.Abs(ply - goy)) / 2) >= startEndGenFunction))
        {
            plx = 2 * Random.Range(1, 5) - 1;
            ply = 2 * Random.Range(1, 5) - 1;

            gox = 2 * Random.Range(1, 5) - 1;
            goy = 2 * Random.Range(1, 5) - 1;
            //Debug.Log(((Mathf.Abs(plx - gox) + Mathf.Abs(ply - goy)) / 2));
        }

        currentMaze[ply, plx] = 2;//[y,x]軸が逆なので気を付ける
        currentMaze[goy, gox] = 3;

        CreateMaze(currentMaze);
    }

    private void Update()
    {
        if (!completed)
        {
            MovePlayer(currentMaze);
        }

    }

    private void CreateMaze(int[,] maze)
    {
        foreach (Transform q in displaySquare.transform) Destroy(q.gameObject);
        foreach (Transform q in displayHWall.transform) Destroy(q.gameObject);
        foreach (Transform q in displayVWall.transform) Destroy(q.gameObject);

        for (int i = 0; i < maze.GetLength(1); i++) // int[  ,★] x
        {
            for (int j = 0; j < maze.GetLength(0); j++) // int[★,  ] y
            {
                int t = maze[j, i];
                if (t == 0)//道
                {
                    if (i % 2 == 1 && j % 2 == 0)//x軸が奇数列、y軸が偶数列　
                    {
                        GameObject pa = Instantiate(passage);
                        pa.transform.SetParent(displayVWall.transform, false);
                    }
                    else if (i % 2 == 0 && j % 2 == 1)//x軸が偶数列、y軸が奇数列
                    {
                        GameObject pa = Instantiate(passage);
                        pa.transform.SetParent(displayHWall.transform, false);
                    }
                    else
                    {
                        GameObject fl = Instantiate(floor);
                        fl.transform.SetParent(displaySquare.transform, false);
                    }
                }
                else if (t == 1)//見えない壁
                {
                    if (i % 2 == 1 && j % 2 == 0)//x軸が奇数列、y軸が偶数列　
                    {
                        GameObject wa = Instantiate(invisibleWall);
                        wa.transform.SetParent(displayVWall.transform, false);
                    }
                    else if (i % 2 == 0 && j % 2 == 1)//x軸が偶数列、y軸が奇数列
                    {
                        GameObject wa = Instantiate(invisibleWall);
                        wa.transform.SetParent(displayHWall.transform, false);
                    }
                }
                else if (t == 11)//当たった壁
                {
                    if (i % 2 == 1 && j % 2 == 0)//x軸が奇数列、y軸が偶数列　
                    {
                        GameObject wa = Instantiate(wall);
                        wa.transform.SetParent(displayVWall.transform, false);
                    }
                    else if (i % 2 == 0 && j % 2 == 1)//x軸が偶数列、y軸が奇数列
                    {
                        GameObject wa = Instantiate(wall);
                        wa.transform.SetParent(displayHWall.transform, false);
                    }
                }
                else if (t == 2)//ターゲット
                {
                    GameObject ta = Instantiate(target);
                    ta.transform.SetParent(displaySquare.transform, false);
                }
                else if (t == 3)//ゴール
                {
                    GameObject go = Instantiate(goal);
                    go.transform.SetParent(displaySquare.transform, false);
                }
            }
        }
    }

    private void MovePlayer(int[,] maze)
    {
        GameObject co = cursorManager.GetCursorObject();

        if ((co == upper) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply - 1, plx] == 1)
            {
                Debug.Log("ouch!");
                maze[ply - 1, plx] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply - 1, plx] == 11)
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

        if ((co == right) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply, plx + 1] == 1)
            {
                Debug.Log("ouch!");
                maze[ply, plx + 1] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply, plx + 1] == 11)
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

        if ((co == left) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply, plx - 1] == 1)
            {
                Debug.Log("ouch!");
                maze[ply, plx - 1] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply, plx - 1] == 11)
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

        if ((co == lower) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply + 1, plx] == 1)
            {
                Debug.Log("ouch!");
                maze[ply + 1, plx] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply + 1, plx] == 11)
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