using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollControllerForKnight : MonoBehaviour
{
    float redisplayTime = 2.0f;
    public GameObject BloodSplatter01; 
    public GameObject BloodSplatter02;
    public int killValueBase = 100;

    GameObject _bloodSplatInstance01;
    GameObject _bloodSplatInstance02;
    Score ScoreParentreference;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SetRidigbodyState(true);
        SetCollisionState(false);
        ScoreParentreference = GameObject.Find("ScoreParent").GetComponent<Score>();
    }

    public void Die(Vector3 dieVelocity)
    {
        GetComponent<Animator>().enabled = false;
        SetRidigbodyState(false);
        SetCollisionState(true);
        
        //Fling the body
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.velocity = dieVelocity;
        }
        
        //The spice/blood must FLOW!
        var positionToSplat = transform.position;
        positionToSplat.y += 1.1f;
        if(_bloodSplatInstance01==null)
        _bloodSplatInstance01 = Instantiate(BloodSplatter01, positionToSplat, Quaternion.identity);
        if(_bloodSplatInstance02==null)
        _bloodSplatInstance02 = Instantiate(BloodSplatter02, positionToSplat, Quaternion.identity);

        Debug.Log($" {dieVelocity.magnitude} and {killValueBase} ");
        var scoreTotalFloat = dieVelocity.magnitude * killValueBase;
        
        int scoreInt = (int) scoreTotalFloat;
        Debug.Log($" {scoreInt} and total {scoreTotalFloat} ");
        ScoreParentreference.AddScore(scoreInt);
        
        StartCoroutine(TimeToDie());
    }

    IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(_bloodSplatInstance01);
        Destroy(_bloodSplatInstance02);
        gameObject.SetActive(false);
    }

    void SetRidigbodyState(bool newState)
    {
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (var rb in rbs)
        {
            rb.isKinematic = newState;
        }
        GetComponent<Rigidbody>().isKinematic = !newState;
    }

    void SetCollisionState(bool newState)
    {
        Collider[] rbs = GetComponentsInChildren<Collider>();
        foreach (var col in rbs)
        {
            col.enabled = newState;
        }
        GetComponent<Collider>().enabled = !newState;
    }
    
    // Update is called once per frame
    void Update()
    {
        redisplayTime -= Time.deltaTime;
        if (redisplayTime < 0.0f)
        {
            redisplayTime = 1.0f;
        }
    }
}
