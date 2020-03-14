import { Character } from './character';

export interface User {
    id: number;
    username: string;
    characters: Character[];
}
