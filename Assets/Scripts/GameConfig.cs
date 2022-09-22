using System.Collections.Generic;
using UnityEngine;

public class GameConfig
{
    public readonly Dictionary<int, Color> Colors;
    public readonly float DoorMoveSpeed = 0.2f;
    public readonly float DoorRotateSpeed = 0.5f;
    public readonly float PlayerMoveSpeed = 5.0f;
    public readonly float PlayerRotateSpeed = 8.0f;

    public GameConfig()
    {
        Colors = new Dictionary<int, Color>
        {
            {0, Color.blue},
            {1, Color.green},
            {2, Color.yellow},
            {3, Color.red}
        };
    }
}