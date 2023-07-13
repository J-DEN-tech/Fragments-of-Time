using Fungus;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactible : MonoBehaviour
{
    public float radius = 3f;

    public Camera cam;

    public Vector2 rawMousePos;

    public Vector3 mousePos;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnGUI()
    {
        Event currentEvent = Event.current;

        rawMousePos.x = currentEvent.mousePosition.x;
        rawMousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        mousePos = cam.ScreenToWorldPoint(new Vector3(rawMousePos.x, rawMousePos.y, 0));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (mousePos == transform.position)
        {
            //Debug.Log(Hash128 interacted)
        }
    }
}
