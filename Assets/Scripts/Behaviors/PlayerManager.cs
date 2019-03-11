using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerManager : CharacterManager
{
    GameManager myGameMgr;
    HUDManager myHUDMgr;

    // Use this for initialization
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myGameMgr = GameObject.Find("GameManager").GetComponent<GameManager>();
        myHUDMgr = myGameMgr.getHUDManager();
        myHUDMgr.SetHealth(this.health);
    }


    public override void LoseHealth(int loss)
    {
        base.LoseHealth(loss);
        if (myHUDMgr != null)
        {
            myHUDMgr.SetHealth(this.health);
        }
    }


    public override void GainHealth(int gain)
    {
        base.GainHealth(gain);

        if (myHUDMgr != null)
        {
            myHUDMgr.SetHealth(this.health);
        }
    }
}