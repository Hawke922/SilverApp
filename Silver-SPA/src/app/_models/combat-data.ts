import { CombatantData } from './combatant-data';

export class CombatData {
    strategyPhase?: boolean;
    battlePhase?: boolean;
    abilityPicking?: boolean;
    combatComplete?: boolean;
    hero?: CombatantData;
    enemy?: CombatantData;
}
