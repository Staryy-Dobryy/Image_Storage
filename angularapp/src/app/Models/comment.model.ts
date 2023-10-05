import { IUser } from "./user.model";

export interface IComment {
  text: string;
  author: IUser;
  creationTime: Date;
}
