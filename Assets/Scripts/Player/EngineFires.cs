using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFires : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] engineFires;
    [SerializeField] private int enginePower = 3;

    private void Update()
    {
        HandleFireEngineEmit();
    }

    private void HandleFireEngineEmit()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            EmitEngineFireParticle(2, enginePower);
            EmitEngineFireParticle(3, enginePower);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            EmitEngineFireParticle(4, enginePower);
            EmitEngineFireParticle(5, enginePower);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            EmitEngineFireParticle(1, enginePower);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            EmitEngineFireParticle(0, enginePower);
    }

    private void EmitEngineFireParticle(int index, int enginePower)
    {
        engineFires[index].Emit(enginePower);
    }
}
