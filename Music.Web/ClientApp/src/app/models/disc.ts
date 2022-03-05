import { Album } from './album';
import { BaseModel } from './base-model';

export interface Disc extends BaseModel {
  number: number;
  name: string;
  albumId: number;
  album?: Album;
}
