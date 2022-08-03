using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    private void Start() {
        base.Start();
        UITradeWindow.Instance.player = this;
    }
}
