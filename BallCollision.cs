using System;
using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    Vector3 ballPositionOld;
    float currentBallSpeed = 0.0f;
    float countdownTillReplay = 0.0f;
    float FlyStrength = 0.05f;

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.name.Contains("ragdoll"))
        {
            if (countdownTillReplay < 0.01f)
            {
                countdownTillReplay = 1.0f;
                MasterAudio.PlaySoundAndForget("Bloody_punches_1");
            }

            var ragdollController = other.gameObject.GetComponent<RagDollControllerForKnight>();
                
            var FlySpeedPerAxis =  (other.transform.position - gameObject.transform.position);
            if (FlySpeedPerAxis.y < 0) FlySpeedPerAxis.y *= -1.0f; //Always fly up
            FlySpeedPerAxis.Normalize();
            FlySpeedPerAxis *= FlyStrength*currentBallSpeed;
            
            if (ragdollController != null) ragdollController.Die(FlySpeedPerAxis);
            
        }
        else
        {
            Debug.Log($"bash with {other.collider.name}");
        }
    }
    
    void Update()
    {
        if (countdownTillReplay > 0.0f)
        {
            countdownTillReplay -= Time.deltaTime;
        }
        var currentBallSpeedPerAxis = (transform.position - ballPositionOld);
        currentBallSpeed = currentBallSpeedPerAxis.magnitude;
    }
}
