import { CombatantData } from './combatant-data';

export class CombatData {
    strategyPhase?: boolean;
    battlePhase?: boolean;
    abilityPicking?: boolean;
    victory?: boolean;
    defeat?: boolean;
    combatComplete?: boolean;
    hero?: CombatantData;
    enemy?: CombatantData;
}
