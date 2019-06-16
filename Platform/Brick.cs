using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(VerticalJiggle))]
public class Brick : MonoBehaviour
{
    [SerializeField] 
	int _hitPoints;
    
    [SerializeField]
	private VerticalJiggle vjiggle;

    public GameObject splashPrefab;
    public GameObject starCollectible;

    #region When Ball Hits Brick
    public void CallJiggle()
    {
        StopCoroutine("OnImpact");
        StartCoroutine("OnImpact");
    }

    IEnumerator OnImpact()
    {
        Instantiate(splashPrefab, transform);

        yield return StartCoroutine(vjiggle.Jiggle(gameObject.transform));
        yield return StartCoroutine(TakeHealth());
    }

    IEnumerator TakeHealth()
    {
    	if ( --_hitPoints < 1 ) {
    		Break();
    	}
        //test - If brick has one hit remaining, dip once and return to original position instead of "jiggling";
        if ( _hitPoints == 1 ) {
            vjiggle.SetProperties(0.5f, 0.5f, 1, 0.5f);
        }
    	yield return null;
    }

    void Break()
    {
        GameObject obj = ObjectPooler.instance.SpawnFromPool("ScorePopupText");
        obj.GetComponent<ScorePopup>().Init(10);
        //insert animation whatchamacallit here
        if (starCollectible != null)
        {
            starCollectible.GetComponent<CollectablePickup>().PickUp();
        }
        Destroy(gameObject);
    }

    #endregion

}
