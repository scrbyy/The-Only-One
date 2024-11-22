using UnityEngine;

[System.Serializable]
public abstract class ActiveAbility : MonoBehaviour
{
    protected abstract string _showingName { get; set; }
    protected abstract int _manaUsage { get; set; }
    public abstract void UseAbility();
}
