using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowableObject : MonoBehaviour
{
    //public Rigidbody obj;
    //public float throwForce = 50;
    //public Transform target, curvePoint;
    //private bool isReturning = false;
    //private Vector3 oldPos;
    //private float time = 0.0f;
    public Text score;
    public Text finalScore;
    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    ThrowObj();
        //}

        //if(Input.GetButtonUp("Fire2"))
        //{
        //    ReturnObj();
        //}

        //if(isReturning)
        //{
        //    //Return calc
        //    if(time < 1.0f)
        //    {
        //        obj.position = getBQCPoint(time, oldPos, curvePoint.position, target.position);
        //        obj.rotation = Quaternion.Slerp(obj.transform.rotation, target.rotation, 50 * Time.deltaTime);
        //        time += Time.deltaTime;
        //    }
        //    else
        //    {
        //        ResetObj();
        //    }
        //
        //
        //}
    }

    //Throw object
    //void ThrowObj()
    //{
    //    obj.transform.parent = null;
    //    obj.isKinematic = false;
    //    obj.AddForce(UnityEngine.Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
    //    obj.AddTorque(obj.transform.TransformDirection(Vector3.right)* 100, ForceMode.Impulse);
    //}
    //Return object
    //void ReturnObj()
    //{
    //    time = 0.0f;
    //    oldPos = obj.position;
    //    isReturning = true;
    //    obj.position += target.position - obj.position;
    //    obj.velocity = Vector3.zero;
    //    obj.isKinematic = true;
    //}
    //Reset object
    //void ResetObj()
    //{
    //    isReturning = false;
    //    obj.transform.parent = transform;
    //    obj.position = target.position;
    //    obj.rotation = target.rotation;
    //}

    //Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    //{
    //    float u = 1 - t;
    //    float tt = t * t;
    //    float uu = u * u;
    //    Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
    //    return p;
    //
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            finalScore.text = scoreValue.ToString();
            Destroy(other.gameObject);
        }
    }
}
