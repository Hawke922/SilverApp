import { Ability } from './ability';

export interface Enemy {
    id: number;
    name: string;
    pictureUrl: string;
    thumbnailUrl: string;
    descriptionLong: string;
    descriptionShort: string;
    hp: number;
    fastAttack: number;
    strongAttack: number;
    specialAttack: number;
    fastDefense: number;
    strongDefense: number;
    specialDefense: number;
    abilities: Ability[];
    isBoss: boolean;
    dungeonId: number;
}
