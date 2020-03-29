import { Character } from './character';

export interface User {
    id: number;
    username: string;
    activeCharacterId: number;
    characters: Character[];
}
