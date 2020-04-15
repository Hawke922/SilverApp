import { Enemy } from './enemy';

export interface Area {
    id: number;
    name: string;
    codeName: string;
    description: string;
    thumbnailUrl: string;
    unlockOn: number;
    exploreMax: number;
    enemies: Enemy[];
}
