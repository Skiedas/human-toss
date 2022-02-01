using UnityEngine;
using DG.Tweening;

public class PlayerLookRotation : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.TryGetComponent(out Ground ground))
                {
                    transform.DOLookAt(hitInfo.point, .75f);
                }
            }
        }
    }
}
