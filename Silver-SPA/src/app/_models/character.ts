import { Ability } from './ability';
import { Progress } from './progress';

export interface Character {
    id: number;
    name: string;
    class: string;
    classIcon: string;
    pictureUrl: string;
    activeDungeonId: number;
    hp: number;
    fastAttack: number;
    strongAttack: number;
    specialAttack: number;
    fastDefense: number;
    strongDefense: number;
    specialDefense: number;
    abilities: Ability[];
    progress: Progress;
}
