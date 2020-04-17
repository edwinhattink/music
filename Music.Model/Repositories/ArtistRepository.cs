using System;
using System.Collections.Generic;
using System.Linq;
using Music.Model.Data;

namespace Music.Model.Repositories
{
    public class ArtistRepository
    {

        public static Artist GetById(int id)
        {
            Artist artist;
            using (ModelContext db = new ModelContext())
            {
                artist = db.Artists.Find(id);
            }
            return artist;
        }

        public static Artist SaveArtist(Artist artist)
        {
            using (ModelContext db = new ModelContext())
            {
                if (artist.Id > 0)
                {
                    db.Artists.Update(artist);
                } else
                {
                    db.Artists.Add(artist);
                }
                db.SaveChanges();
            }
            return artist;
                
        }

        public static List<Artist> GetList()
        {
            using (ModelContext db = new ModelContext())
            {
                return db.Artists.ToList();
            }
        }
    }
}