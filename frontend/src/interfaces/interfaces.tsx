
export interface FormDataDto {
    name: string;
    city: string;
    skillLevel: string;
    bio: string;
    avatar: File[]; 
}
export interface UseProfileInterface
{
    userName: string,
    city:string,
    bio:string,
    skillLevel:string,
    profilePhotoUrl: string
}