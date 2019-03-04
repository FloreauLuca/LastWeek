using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BossDoor : Door
{

    protected override void ChangeRoom()
    {
        base.ChangeRoom();
        GameManager.Instance.LaunchBoss();
    }
}
