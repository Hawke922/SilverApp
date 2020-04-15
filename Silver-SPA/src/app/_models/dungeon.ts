import { Enemy } from './enemy';
import { Area } from './area';

export interface Dungeon {
    id: number;
    name: string;
    codeName: string;
    difficulty: number;
    descriptionLong: string;
    descriptionShort: string;
    backgroundUrl: string;
    thumbnailUrl: string;
    enemies: Enemy[];
    areas: Area[];
}
