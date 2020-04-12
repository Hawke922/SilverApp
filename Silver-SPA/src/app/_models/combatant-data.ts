import { Ability } from './ability';

export class CombatantData {
        offense?: Ability;
        defense?: Ability;
        damage?: number;
        health?: number;
        healthBarValue?: number;
        trueDamage?: number;
        blockedDamage?: number;
        damageUpdate?: boolean;
}
