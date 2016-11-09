using UnityEngine;
using System.Collections;

public class PlatfromMover : MonoBehaviour {
    #region[Variables]
    public float moveSpeed;
    public string resetTriggerTag = "LevelEnd";
    public Quaternion targetRotation;
    private ScoreUpdater score;
    private Transform priorPlatform;
    private float offset = 2;
    private Quaternion newRotation;

    private bool hasReset = false;
    private float timer = 0;
    private float timerMax = 1.5f;


    #endregion
    // Use this for initialization
    void Start () {
        score = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreUpdater>();
        targetRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (timer >= timerMax )
        {
            hasReset = false;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        this.transform.position += this.transform.forward * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * 1 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == resetTriggerTag  && hasReset == false)
        {
            hasReset = true;

            score.score++;
            //reset position
            priorPlatform = score.lastPlatform;
            score.lastPlatform = this.transform;
            this.transform.position = new Vector3(0,0,offset + priorPlatform.position.z);

            //reset rotation
            float tmpRot = score.rotOut();
            newRotation = new Quaternion(0, 180, tmpRot + priorPlatform.transform.rotation.z, 0);
            this.transform.rotation = newRotation;

            //add rotation
            targetRotation = priorPlatform.transform.gameObject.GetComponent<PlatfromMover>().targetRotation;
            AddRotation(tmpRot);
        }
    }
    public void AddRotation(float degrees)
    {
        targetRotation *= Quaternion.AngleAxis(degrees, Vector3.forward);
    }
}
