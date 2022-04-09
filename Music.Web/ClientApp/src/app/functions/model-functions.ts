import { BaseModel } from '../models';

export function findById<T extends BaseModel>(array: T[], id: number): T {
  const foundItem = array.find(item => item.id === id);
  if (foundItem !== undefined) {
    return foundItem;
  }
  throw new Error('Item not found');
}

