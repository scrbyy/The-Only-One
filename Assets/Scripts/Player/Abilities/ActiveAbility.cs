using UnityEngine;

[System.Serializable]
public abstract class ActiveAbility : MonoBehaviour
{
    protected abstract string showingName { get; set; }
    protected abstract int manaUsage { get; set; }
    public abstract void UseAbility();
}
