import { BaseModel } from './base-model';

export interface Track extends BaseModel {
  number: number;
  name: string;
  fileName: string;
}
