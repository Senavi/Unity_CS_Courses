using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBumps : MonoBehaviour
{
[SerializeField] public Text ScoreField;
int hits;
private void OnCollisionEnter(Collision other)
{
    hits++;
    ScoreField.text = hits.ToString();
    Debug.Log("Hitted! " + hits);

}
}
