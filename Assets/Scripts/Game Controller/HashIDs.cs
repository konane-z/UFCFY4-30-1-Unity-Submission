using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int walkState;
    public int speedFloat;
    public int driveState;


    // Awake runs when the game is loaded but before it starts
    private void Awake()
    {
        walkState = Animator.StringToHash("Walk");
        driveState = Animator.StringToHash("Take 001");
        speedFloat = Animator.StringToHash("Speed");
    }
}
