
public interface IAttackable
{
    Enemy targetEnemy { get; set; }
    float attackDamage { get; set; }
    void Attack();
    void SetTarget(Enemy target);
   

}
