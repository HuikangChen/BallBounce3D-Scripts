using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class VerticalJiggle
{
    #region Editor Variables
    [SerializeField]
	private float _period = 0.5f;
	[SerializeField]
	private float _amplitude = 1.25f;
	[SerializeField]
	private int _cycles = 2;
	[SerializeField]
	private float _decayRate = 0.5f;
    #endregion
    
    //Allows changing of initial values
    public void SetProperties(float period, float amplitude, int cycles, float decayRate)
    {
        _period = period;
        _amplitude = amplitude;
        _cycles = cycles;
        _decayRate = decayRate;
    }


    //Moves the object's transform according to a damped sine wave
    // y(Time) = Amplitude * e^(decay constant) * Cos(Angular Frequency * T + Phase Shift = pi)
    public IEnumerator Jiggle(Transform t) 
    { 
    	float timeElapsed = 0f;
        Vector3 _pivotPosition = t.position;
        float _angularFrequency = (Mathf.PI * _cycles) / _period;

    	while ( timeElapsed < _period ) {
			Vector3 nextPos = t.position;
	    	nextPos.y = _pivotPosition.y - _amplitude * Mathf.Exp( -_decayRate * timeElapsed ) * Mathf.Sin( _angularFrequency * timeElapsed );
    		timeElapsed += Time.deltaTime;
            t.position = nextPos;
	     	yield return null;
     	}

        t.position = new Vector3(t.position.x, _pivotPosition.y, t.position.z);
    }
    
}
