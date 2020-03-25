import { Enemy } from './enemy';

export interface Dungeon {
    id: number;
    name: string;
    difficulty: number;
    descriptionLong: string;
    descriptionShort: string;
    backgroundUrl: string;
    thumbnailUrl: string;
    enemies: Enemy[];
}