import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ArtistsComponent } from './components/artists/artists.component';
import { ArtistComponent } from './components/artist/artist.component';
import { AlbumComponent } from './components/album/album.component';
import { AlbumsComponent } from './components/albums/albums.component';
import { DiscComponent } from './components/disc/disc.component';
import { DiscsComponent } from './components/discs/discs.component';
import { GenreComponent } from './components/genre/genre.component';
import { GenresComponent } from './components/genres/genres.component';
import { TrackComponent } from './components/track/track.component';
import { TracksComponent } from './components/tracks/tracks.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

@NgModule({
  declarations: [
    AppComponent, NavMenuComponent, HomeComponent, ArtistsComponent, ArtistComponent, AlbumComponent, AlbumsComponent,
    DiscComponent, DiscsComponent, GenreComponent, GenresComponent, TrackComponent, TracksComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
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
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    MatChipsModule,
    MatAutocompleteModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
