using System.Collections.Generic;
using UnityEngine;

public class ActiveAbilityContainer : MonoBehaviour 
{
    [SerializeField] private List<ActiveAbility> _abilities = new List<ActiveAbility>();
    [SerializeField] private int _selectedAbilityIndex;

    private void Update()
    {
        _abilities[_selectedAbilityIndex].UseAbility();
    }
}

