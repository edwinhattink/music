import { BaseModel } from './base-model';
import { Disc } from './disc';
import { Genre } from './genre';

export interface Track extends BaseModel {
  number: number;
  name: string;
  fileName: string;
  genreId: number;
  genre?: Genre;
  discId: number;
  disc?: Disc;
}
