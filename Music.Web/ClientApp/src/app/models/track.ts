import { BaseModel } from './base-model';
import { Genre } from './genre';

export interface Track extends BaseModel {
  number: number;
  name: string;
  fileName: string;
  genreId: number;
  genre?: Genre;
}
