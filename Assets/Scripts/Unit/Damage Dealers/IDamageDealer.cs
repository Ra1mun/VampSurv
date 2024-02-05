using Assets.Scripts.Unit;

public interface IDamageDealer
{
    void Rest();
    void TryDamage(Unit.Unit target, int damage);
}