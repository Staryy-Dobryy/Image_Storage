import { IComment } from "./comment.model";
import { IUser } from "./user.model";

export interface IPublication {
  description: string;
  imageUrl: string;
  author: IUser;
  comments: IComment[];
}
