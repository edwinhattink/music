import { Artist } from './artist';
import { BaseModel } from './base-model';
import { ContributionType } from './contribution-type';
import { Track } from './track';

export interface Contribution extends BaseModel {
  trackId: number;
  track: Track;
  artistId: number;
  artist: Artist;
  contributionType: ContributionType;
}
