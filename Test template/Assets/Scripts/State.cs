using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName ="State")]
public class State : ScriptableObject
{


    [TextArea(20, 20)] [SerializeField] string storyText;
    [SerializeField] State[] nextState;

    public string GetStateStory()
    { return storyText; }

    public State[] GetNextStates()

    { return nextState; }



}
