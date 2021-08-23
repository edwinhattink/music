import { BaseModel } from './base-model';

export interface Artist extends BaseModel{
  id?: number;
  name: string;
}
