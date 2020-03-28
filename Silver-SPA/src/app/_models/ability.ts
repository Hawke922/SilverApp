export interface Ability {
    id: number;
    name: string;
    icon: string;
    description: string;
    baseDamage: number;
    typeId: number;
    isOffensive: boolean;
}
