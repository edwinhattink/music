import { BaseModel } from './base-model';

export interface Genre extends BaseModel {
  name: string;
  parentGenre?: Genre;
  genres: Genre[];
}
