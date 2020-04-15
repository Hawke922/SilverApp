import { DungeonProgress } from './dungeon-progress';
import { AreaProgress } from './area-progress';

export interface Progress {
    dungeonProgress: DungeonProgress[];
    areaProgress: AreaProgress[];
}
