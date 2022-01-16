import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ArtistsComponent } from './artists/artists.component';
import { ArtistComponent } from './artist/artist.component';
import { AlbumComponent } from './album/album.component';
import { AlbumsComponent } from './albums/albums.component';
import { DiscComponent } from './disc/disc.component';
import { DiscsComponent } from './discs/discs.component';
import { GenreComponent } from './genre/genre.component';
import { GenresComponent } from './genres/genres.component';
import { TrackComponent } from './track/track.component';
import { TracksComponent } from './tracks/tracks.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent, NavMenuComponent, HomeComponent, ArtistsComponent, ArtistComponent, AlbumComponent, AlbumsComponent,
    DiscComponent, DiscsComponent, GenreComponent, GenresComponent, TrackComponent, TracksComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'albums', component: AlbumsComponent },
      { path: 'albums/:id', component: AlbumComponent },
      { path: 'artists', component: ArtistsComponent },
      { path: 'artists/:id', component: ArtistComponent },
      { path: 'discs', component: DiscsComponent },
      { path: 'discs/:id', component: DiscComponent },
      { path: 'genres', component: GenresComponent },
      { path: 'genres/:id', component: GenreComponent },
      { path: 'tracks', component: TracksComponent },
      { path: 'tracks/:id', component: TrackComponent },
    ]),
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
