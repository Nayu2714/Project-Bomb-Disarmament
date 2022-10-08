using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    public bool completed = false;
    public MainMaster mainMaster;
    public CursorManager cursorManager;
    public CompletedManager completedManager;

    [Space(5)]

    List<int[,]> maze = new List<int[,]>();
    private int[,] currentMaze = new int[11, 11];

    //���H�̌`���񎟌��z��ɂĐݒ�
    // 5*5�̖��H�ɂ�x11,y11�K�v
    // t*t�̖��H�ɂ�x(t*2+1),y(t*2+1)�K�v
    //0=�� 1=�� 2=�v���C���[ 3=�S�[�� 9=�ڈ�

    private int[,] maze0 =
    {
        {1,1,1,1,1,1,1,1,1,1,1 },
        {1,9,1,0,0,0,0,0,0,0,1 },
        {1,0,1,1,1,1,1,0,1,1,1 },
        {1,0,1,0,0,0,0,0,0,0,1 },
        {1,0,1,0,1,1,1,1,1,1,1 },
        {1,0,0,0,1,0,1,9,0,0,1 },
        {1,0,1,1,1,0,1,0,1,0,1 },
        {1,0,1,0,0,0,1,0,1,0,1 },
        {1,0,1,0,1,1,1,1,1,0,1 },
        {1,0,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1 }

        /*  
         *  ###########
         *  #        @#
         *  # ##### ###
         *  # #       #
         *  # # #######
         *  #   # #   #
         *  # ### # # #
         *  # #   #@# #
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
        {1,9,0,0,0,0,0,0,1,9,1 },
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
         *  #@      #@#
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
        {1,0,0,0,1,9,1,0,0,0,1 },
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
         *  #   #@#   #
         *  # # # # # #
         *  # #   # # #
         *  ###########
         */
    };

    [SerializeField] private bool mazeRundomization = true;

    [SerializeField] private int mazeNumber = 0;
    [SerializeField] private int mazeRotationParameter = 0;
    [SerializeField] private int startEndGenFunction = 3;

    [Space(5)]

    [SerializeField] private int plx = 0;
    [SerializeField] private int ply = 0;
    [Space(3)]
    [SerializeField] private int gox = 0;
    [SerializeField] private int goy = 0;

    [Space(5)]

    [SerializeField] private GameObject hiddenWall;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject passage;
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject goal;
    [Space(3)]
    [SerializeField] private GameObject mark;
    [Space(3)]
    [SerializeField] private GameObject upper;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject lower;
    [Space(3)]
    [SerializeField] private GameObject displaySquare;
    [SerializeField] private GameObject displayVWall;
    [SerializeField] private GameObject displayHWall;
    [SerializeField] private GameObject Marks;

    private void Start()
    {
        mainMaster = GameObject.Find("Main Master").GetComponent<MainMaster>();
        cursorManager = GameObject.Find("Main Master").GetComponent<CursorManager>();

        maze.Add(maze0);
        maze.Add(maze1);
        maze.Add(maze2);

        if (mazeRundomization)
        {
            mazeNumber = Random.Range(0, 2);
            mazeRotationParameter = Random.Range(0, 4);
        }

        currentMaze = RotateMaze(maze[mazeNumber], mazeRotationParameter);

        for (int i = 0; i < currentMaze.GetLength(1); i++)
        {
            for (int j = 0; j < currentMaze.GetLength(0); j++)
            {
                if (currentMaze[j, i] == 9)
                {
                    Instantiate(mark, new Vector3((3.25f * i - 1.5f), (-3.25f * j + 1.5f), 0), Quaternion.identity).transform.SetParent(Marks.transform, false);
                    currentMaze[j, i] = 0;
                }
            }
        }

        while (!(((Mathf.Abs(plx - gox) + Mathf.Abs(ply - goy)) / 2) >= startEndGenFunction))
        {
            plx = 2 * Random.Range(1, 5) - 1;
            ply = 2 * Random.Range(1, 5) - 1;

            gox = 2 * Random.Range(1, 5) - 1;
            goy = 2 * Random.Range(1, 5) - 1;
            //Debug.Log(((Mathf.Abs(plx - gox) + Mathf.Abs(ply - goy)) / 2));
        }

        currentMaze[ply, plx] = 2;//[y,x]�����t�Ȃ̂ŋC��t����
        currentMaze[goy, gox] = 3;

        CreateMaze(currentMaze);
    }

    private void Update()
    {
        if (!completed)
        {
            MovePlayer(currentMaze);
        }
        else
        {
            completedManager.completedDisplaying(true);
        }

    }

    private void CreateMaze(int[,] maze)
    {
        foreach (Transform q in displaySquare.transform) Destroy(q.gameObject);
        foreach (Transform q in displayHWall.transform) Destroy(q.gameObject);
        foreach (Transform q in displayVWall.transform) Destroy(q.gameObject);

        for (int i = 0; i < maze.GetLength(1); i++) // int[  ,��] x
        {
            for (int j = 0; j < maze.GetLength(0); j++) // int[��,  ] y
            {
                int t = maze[j, i];
                if (t == 0)//��
                {
                    if (i % 2 == 1 && j % 2 == 0)//x�������Ay����������@
                    {
                        GameObject pa = Instantiate(passage);
                        pa.transform.SetParent(displayVWall.transform, false);
                    }
                    else if (i % 2 == 0 && j % 2 == 1)//x����������Ay�������
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
                else if (t == 1)//�����Ȃ���
                {
                    if (i % 2 == 1 && j % 2 == 0)//x�������Ay����������@
                    {
                        GameObject wa = Instantiate(hiddenWall);
                        wa.transform.SetParent(displayVWall.transform, false);
                    }
                    else if (i % 2 == 0 && j % 2 == 1)//x����������Ay�������
                    {
                        GameObject wa = Instantiate(hiddenWall);
                        wa.transform.SetParent(displayHWall.transform, false);
                    }
                }
                else if (t == 11)//����������
                {
                    if (i % 2 == 1 && j % 2 == 0)//x�������Ay����������@
                    {
                        GameObject wa = Instantiate(wall);
                        wa.transform.SetParent(displayVWall.transform, false);
                    }
                    else if (i % 2 == 0 && j % 2 == 1)//x����������Ay�������
                    {
                        GameObject wa = Instantiate(wall);
                        wa.transform.SetParent(displayHWall.transform, false);
                    }
                }
                else if (t == 2)//�^�[�Q�b�g
                {
                    GameObject ta = Instantiate(target);
                    ta.transform.SetParent(displaySquare.transform, false);
                }
                else if (t == 3)//�S�[��
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
                maze[ply - 1, plx] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply - 1, plx] == 11)
            {
                return;
            }

            if (maze[ply - 2, plx] == 3)
            {
                completed = true;
            }

            maze[ply - 2, plx] = 2;
            maze[ply, plx] = 0;

            ply -= 2;

            CreateMaze(maze);
        }

        if ((co == right) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply, plx + 1] == 1)
            {
                maze[ply, plx + 1] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply, plx + 1] == 11)
            {
                return;
            }

            if (maze[ply, plx + 2] == 3)
            {
                completed = true;
            }

            maze[ply, plx + 2] = 2;
            maze[ply, plx] = 0;

            plx += 2;

            CreateMaze(maze);
        }

        if ((co == left) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply, plx - 1] == 1)
            {
                maze[ply, plx - 1] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply, plx - 1] == 11)
            {
                return;
            }

            if (maze[ply, plx - 2] == 3)
            {
                completed = true;
            }

            maze[ply, plx - 2] = 2;
            maze[ply, plx] = 0;

            plx -= 2;

            CreateMaze(maze);
        }

        if ((co == lower) && (Input.GetMouseButtonDown(0)))
        {
            if (maze[ply + 1, plx] == 1)
            {
                maze[ply + 1, plx] = 11;
                CreateMaze(maze);
                return;
            }
            else if (maze[ply + 1, plx] == 11)
            {
                return;
            }

            if (maze[ply + 2, plx] == 3)
            {
                completed = true;
            }

            maze[ply + 2, plx] = 2;
            maze[ply, plx] = 0;

            ply += 2;

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
        else if (r == 1)/*�@90�x��]�@*/ /*�@�s���񐔂�����ւ��@*/
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
            return maze;
        }
    }

}