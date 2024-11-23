public class HealthBar : Bar
{
    private void OnEnable()
    {
        Player.PlayerTookDamageEvent += ChangeValue;
    }
    private void OnDisable()
    {
        Player.PlayerTookDamageEvent += ChangeValue;
    }
}