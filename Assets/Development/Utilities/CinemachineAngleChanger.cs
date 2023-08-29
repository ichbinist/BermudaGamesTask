using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineAngleChanger : MonoBehaviour
{
    public Vector3 NewBodyOffset = Vector3.zero;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Runner>())
        {
            StartCoroutine(SmoothOffset());
        }
    }

    IEnumerator SmoothOffset()
    {
        var transposer = (Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera).GetCinemachineComponent<CinemachineTransposer>();
        
        while(Vector3.Distance(transposer.m_FollowOffset, NewBodyOffset) > 0.1f)
        {
            transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, NewBodyOffset,Time.deltaTime * 4f);
            yield return null;
        }
        transposer.m_FollowOffset = NewBodyOffset;
        yield return null;
    }
}
