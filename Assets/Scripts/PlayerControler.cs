using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    public float rotation = 30;
    public string platformTag = "Platform";
    public string platformHolderTag = "PlatformPivot";
    public float jumpHeight;

    private GameObject[] platforms = new GameObject[1];
    private Rigidbody rb;
    // Use this for initialization
    void Start () {
        platforms = GameObject.FindGameObjectsWithTag(platformHolderTag);
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        InputHandle();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == platformTag)
        {
            rb.AddForce(this.transform.up * jumpHeight, ForceMode.Impulse);
        }
    }

    void InputHandle()
    {
        if (Input.GetKeyDown(KeyCode.A) )
        {
            foreach (GameObject platform in platforms)
            {
                platform.GetComponent<PlatfromMover>().AddRotation(-rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (GameObject platform in platforms)
            {
                platform.GetComponent<PlatfromMover>().AddRotation(rotation);
            }
        }
    }
}
