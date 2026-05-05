using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Parent class for all buttons, containing basic utility for dragging and interacting.
 */
public class Button : MonoBehaviour
{
    public Vector2 defaultPosition;
    private InputAction interactAction;
    private PlayerInput playerInput;
    private bool isDragging;

    [SerializeField] Camera mainCamera;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = defaultPosition;
        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions.FindAction("Interact");

        interactAction.performed += OnInteract;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }
    }

    public virtual void OnMouseDown()
    {
        Debug.Log("started dragging");
        isDragging = true;
    }

    public virtual void OnMouseUp()
    {
        Debug.Log("stopped dragging");
        isDragging = false;
        transform.position = defaultPosition;
    }

    public virtual void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("right click pressed");
        if (isDragging)
        {
            Debug.Log("Button interacted");
            //Interaction here
        }
    }
}
