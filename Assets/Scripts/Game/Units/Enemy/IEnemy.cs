using System.Collections.Generic;
public interface IEnemy
{
    void Jump();

    void Die(Enemy enemy, List<Enemy> enemyList);

    void Attack();

}
