using System;
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
    }
}
