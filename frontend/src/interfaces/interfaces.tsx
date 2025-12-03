import { ReactNode } from "react";

export interface FormDataDtoProps {
    name: string;
    city: string;
    skillLevel: string;
    bio: string;
    avatar: File[]; 
}
export interface UseProfileProps
{
    userName: string,
    city:string,
    bio:string,
    skillLevel:string,
    profilePhotoUrl: string
}
export interface UserPostProps
{
    userName: string,
    postContent: string,
    mediaUrl?: string;
    createdAt: string;
    postId:string;
}
export interface pageProps
{
    title:string,
    children: ReactNode;
}
export interface PostFeedProps {
  post: any[];          
  error?: Error | null;
  loading?: boolean;
}