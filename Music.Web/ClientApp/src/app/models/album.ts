import { BaseModel } from './base-model';

export interface Album extends BaseModel {
  name: string;
  releaseYear: number;
}
