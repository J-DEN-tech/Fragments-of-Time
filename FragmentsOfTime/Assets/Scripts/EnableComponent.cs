using UnityEngine;
using Fungus;

[CommandInfo("Custom",
             "Enable Component",
             "Enables or disables a component")]

public class EnableComponent : Command
{
    [Tooltip("The GameObject that the component is attached to")]
    [SerializeField] protected GameObject targetObject;

    [Tooltip("The component to enable or disable")]
    [SerializeField] protected BoxCollider2D component;

    [Tooltip("Whether to enable or disable the component")]
    [SerializeField] protected BooleanData enable;

    public override void OnEnter()
    {
        if (targetObject != null && component != null)
        {
            component.enabled = enable.Value;
        }

        Continue();
    }

    public override string GetSummary()
    {
        if (targetObject == null)
        {
            return "Error: No target GameObject specified";
        }

        if (component == null)
        {
            return "Error: No component specified";
        }

        return targetObject.name + " - " + component.GetType().Name;
    }

    public override Color GetButtonColor()
    {
        return new Color32(235, 191, 217, 255);
    }
}
