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
    profilePhotoUrl: string,
    id:string
}
export interface UserPostProps {
  postId: string;
  userId: string;
  userName: string;
  postContent: string;
  skillLevel:string
  mediaUrl?: string;
  createdAt: string;
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



