using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Serialization;

    
    [System.Serializable]
public class RotationSetList
{
    public float[] RotationOffsetList;
}

public class ScoreUpdater : MonoBehaviour {
    public int score;
    public Text scoreDis;
    public Transform lastPlatform;
    public RotationSetList[] rotations = new RotationSetList[1];
    public int rotListSelector;
    public int currectRot = 0;
	// Use this for initialization
	void Start () {
        scoreDis = this.GetComponent<Text>();
        rotListSelector = Random.Range(0,rotations.Length);
    }
	
	// Update is called once per frame
	void Update () {
        scoreDis.text = score.ToString();
    }
    public void nextRot()
    {
        if (currectRot >= rotations[rotListSelector].RotationOffsetList.Length -1)
        {
            currectRot = 0;
            rotListSelector = Random.Range(0, rotations.Length);
        }
        else
        {
            currectRot++;
        }
    }
    public float rotOut()
    {
        float tmp = rotations[rotListSelector].RotationOffsetList[currectRot];
        nextRot();
        return tmp;
    }
}
