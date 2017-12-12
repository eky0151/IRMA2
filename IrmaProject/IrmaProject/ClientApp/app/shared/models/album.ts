import { Image } from "./image";

export interface Album {
    name: string;
    urlFriendlyAlbumName: string;
    description?: string;
    createdAt: Date;
    modifiedAt: Date;
    filesCount: number;
    images: Image[];
    urlFriendlyUserName?: string;
}