using UnityEngine;
using UnityEngine.InputSystem;

public class NozzleController : MonoBehaviour
{
    private void Update()
    {
        // Check if the trigger is being held down
        if (Gamepad.current != null && Gamepad.current.rightTrigger.isPressed)
        {
            // Trigger is pressed, do something
            Debug.Log("Trigger is held down!");
        }
    }
}