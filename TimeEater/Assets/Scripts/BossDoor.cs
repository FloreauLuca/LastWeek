using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoor : Door
{
    protected override void ChangeRoom()
    {
        base.ChangeRoom();
        GameManager.Instance.LaunchBoss();
    }
}
